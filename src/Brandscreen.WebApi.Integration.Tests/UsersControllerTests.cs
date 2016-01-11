using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Users;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class UsersControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Register_ShouldReturnHttpOk_WhenCorrectUserInfo()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/register";
            var postData = new
            {
                Email = "twu+test@brandscreen.com",
                Password = "abcd1234",
                ConfirmPassword = "abcd1234",
                FirstName = "Tim",
                LastName = "Wu",
                Mobile = "0411111111",
                CompanyName = "Brandscreen",
                CompanyType = "Other"
            };

            // Act
            var response = await url.AllowAnyHttpStatus().PostUrlEncodedAsync(postData);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Register_ShouldReturnBadRequest_WhenDismatchConfirmPassword()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/register";
            var postData = new
            {
                Email = "twu+test@brandscreen.com",
                Password = "abcd1234",
                ConfirmPassword = "abcd123",
                FirstName = "Tim",
                LastName = "Wu",
                Mobile = "0411111111",
                CompanyName = "Brandscreen",
                CompanyType = "Other"
            };

            // Act
            var response = await url.AllowAnyHttpStatus().PostUrlEncodedAsync(postData);
            var result = await Task.FromResult(response).ReceiveString();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.StringContaining("confirmation password do not match"));
        }


        [Test]
        public async Task Register_ShouldReturnBadRequest_WhenExistEmail()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/register";
            var postData = new
            {
                Email = "jwu@brandscreen.com",
                Password = "abcd1234",
                ConfirmPassword = "abcd1234",
                FirstName = "Tim",
                LastName = "Wu",
                Mobile = "0411111111",
                CompanyName = "Brandscreen",
                CompanyType = "Other"
            };

            // Act
            var response = await url.AllowAnyHttpStatus().PostUrlEncodedAsync(postData);
            var result = await Task.FromResult(response).ReceiveString();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.StringContaining("jwu@brandscreen.com is already taken"));
        }

        [Test]
        public async Task Post_ShouldReturnHttpOk_WhenCorrectUserInfo()
        {
            // Arrange 
            var buyerAccountUuid = (await Container.Resolve<IAccountService>().GetAccount(2)).BuyerAccountUuid;
            var url = HostServer.Url + "api/users";
            var postData = new
            {
                Email = "twu+test@brandscreen.com",
                BuyerAccountUuid = buyerAccountUuid,
                CostView = "AgencyCost",
                Role = "AgencyUser",
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token).AllowAnyHttpStatus().PostUrlEncodedAsync(postData);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Post_ShouldReturnBadRequest_WhenIncorrectRole()
        {
            // Arrange 
            var buyerAccountUuid = (await Container.Resolve<IAccountService>().GetAccount(2)).BuyerAccountUuid;
            var url = HostServer.Url + "api/users";
            var postData = new
            {
                Email = "twu+test@brandscreen.com",
                BuyerAccountUuid = buyerAccountUuid,
                CostView = "AgencyCost",
                Role = "NonUser",
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token).AllowAnyHttpStatus().PostUrlEncodedAsync(postData);
            var result = await Task.FromResult(response).ReceiveString();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(result, Is.StringContaining("The field Role is invalid."));
        }

        [Test]
        public async Task Get_ShouldReturnListOfUsers()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            var userQueryOptions = new UserQueryOptions();
            userQueryOptions.BuyerAccountIds.Add(account.BuyerAccountId);
            var totalCount = await Container.Resolve<IUserService>().GetUsers(userQueryOptions).CountAsync();
            var data = new
            {
                BuyerAccountUuid = account.BuyerAccountUuid,
                PageNumber = 2,
                PageSize = 5
            };

            // Act
            var response = await url.SetQueryParams(data)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.TotalItemCount, Is.EqualTo(totalCount));
        }

        [Test]
        public async Task Get_ShouldReturnUserDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/";
            var userService = Container.Resolve<IUserService>();
            var user = await userService.GetUsers().FirstAsync();

            // Act
            var response = await url.AppendPathSegment(user.UserId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.UserId, Is.EqualTo(user.UserId.ToString()));
            Assert.That(response.UserName, Is.EqualTo(user.UserName));
        }

        [Test]
        public async Task Get_ShouldReturnNotFound_WhenInvalidId()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/";

            // Act
            var response = await url.AppendPathSegment(Guid.NewGuid().ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowAnyHttpStatus()
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/users/";
            var userService = Container.Resolve<IUserService>();
            var user = await userService.GetUsers().FirstAsync();
            var data = new
            {
                FirstName = "testname"
            };

            // Act
            await url.AppendPathSegment(user.UserId.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(user.FirstName, Is.EqualTo(data.FirstName));
        }
    }
}