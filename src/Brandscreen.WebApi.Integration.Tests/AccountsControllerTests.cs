using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;
using Flurl;
using Flurl.Http;
using NUnit.Framework;
using Repository.Pattern.Repositories;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class AccountsControllerTests : IocSupportedTests
    {
        private async Task PrepareNewAccount()
        {
            var url = HostServer.Url + "api/accounts/";
            var repository = Container.Resolve<IRepositoryAsync<UserBuyerRole>>();
            var record = repository.Queryable().First(x => x.RoleName == "AgencyAdministrator");
            var data = new
            {
                UserId = record.UserId,
                CompanyName = "TestCreateCompanyName",
                CompanyType = "Other",
                PostalCode = "2010"
            };
            await url.WithOAuthBearerToken(await TestHelper.Token).PostUrlEncodedAsync(data);
        }

        [Test]
        public async Task Get_ShouldReturnAcccounts()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var data = new
            {
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
            Assert.That(response.PageNumber, Is.EqualTo(data.PageNumber));
            Assert.That(response.Data.Count, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task Get_ShouldReturnAccountDetails()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var country = await Container.Resolve<IRepositoryAsync<Country>>().FindAsync(233);
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            account.CompanyName = "AccountsTest";
            account.CountryId = country.CountryId;
            await accountService.UpdateAccount(account);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(account.BuyerAccountUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response.BuyerAccountUuid, Is.EqualTo(account.BuyerAccountUuid.ToString()));
            Assert.That(response.CompanyName, Is.EqualTo(account.CompanyName));
            Assert.That(response.CountryCode, Is.EqualTo(country.Iso3166Code));
        }

        [Test]
        public async Task GetInvalidId_ShouldReturnNotFound()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";

            // Act
            var response = await url.AppendPathSegment("not_valid_id")
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowAnyHttpStatus()
                .GetAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        [Test]
        public async Task Patch_ShouldUpdateFields()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            var data = new
            {
                CompanyName = "TestCompanyName",
                PostalCode = "2000",
            };

            // Act
            await url.AppendPathSegment(account.BuyerAccountUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(data.CompanyName, Is.EqualTo(account.CompanyName));
            Assert.That(data.PostalCode, Is.EqualTo(account.PostalCode));
        }


        [Test]
        public async Task Patch_ShouldReturnNotFound_WhenInvalidId()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var data = new
            {
                CompanyName = "TestCompanyName",
                PostalCode = "2000",
            };

            // Act
            var response = await url.AppendPathSegment(Guid.NewGuid().ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .AllowAnyHttpStatus()
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Create_ShouldCreateNewAccount()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var repository = Container.Resolve<IRepositoryAsync<UserBuyerRole>>();
            var record = repository.Queryable().First(x => x.RoleName == "AgencyAdministrator");
            var data = new
            {
                UserId = record.UserId,
                CompanyName = "TestCreateCompanyName",
                CompanyType = "Other",
                PostalCode = "2010"
            };

            // Act
            await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data);

            // Assert
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync(x => x.CompanyName == data.CompanyName);
            Assert.That(account.CompanyName, Is.EqualTo(data.CompanyName));
            Assert.That(account.PostalCode, Is.EqualTo(data.PostalCode));
        }

        [Test]
        public async Task Delete_ShouldDeleteAccount()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            await PrepareNewAccount();
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync(x => x.CompanyName == "TestCreateCompanyName");

            // Act
            await url.AppendPathSegment(account.BuyerAccountUuid.ToString())
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(account.IsDeleted, Is.True);
        }

        [Test]
        public async Task GetStatus_ShouldReturnAccountStatus()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            account.CompanyName = "AccountsTest";
            account.IsActive = true;
            account.IsApproved = true;
            await accountService.UpdateAccount(account);
            SaveDbChanges();

            // Act
            var response = await url.AppendPathSegment(account.BuyerAccountUuid + "/status")
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync().ReceiveJson();

            // Assert
            Assert.That(response.Status, Is.EqualTo("Activated"));
        }

        [Test]
        public async Task PutStatus_ShouldChangeStatus()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            account.CompanyName = "AccountsTest";
            account.IsActive = true;
            account.IsApproved = true;
            await accountService.UpdateAccount(account);
            SaveDbChanges();
            var data = new
            {
                Status = 3
            };

            // Act
            await url.AppendPathSegment(account.BuyerAccountUuid + "/status")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PutUrlEncodedAsync(data);

            // Assert
            Assert.That(account.IsActive, Is.False);
            Assert.That(account.IsApproved, Is.True);
        }

        [Test]
        public async Task PatchTerms_ShouldChangeStatus()
        {
            // Arrange 
            var url = HostServer.Url + "api/accounts/";
            var accountService = Container.Resolve<IAccountService>();
            var account = await accountService.GetAccounts().FirstAsync();
            account.CompanyName = "AccountsTest";
            account.CreditLimit = 1;
            await accountService.UpdateAccount(account);
            SaveDbChanges();
            var data = new
            {
                CreditLimit = 3
            };

            // Act
            await url.AppendPathSegment(account.BuyerAccountUuid + "/terms")
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(account.CreditLimit, Is.EqualTo(data.CreditLimit));
        }
    }
}