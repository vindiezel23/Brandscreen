using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Core.Services.Users;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using TimeZone = Brandscreen.Entities.TimeZone;

namespace Brandscreen.WebApi.Tests
{
    public class UsersControllerTests : ApiControllerMockingTests<UsersController>
    {
        [Test]
        public async Task Get_ShouldReturnUserList()
        {
            // Arrange
            var buyerAccountId = 1;
            var buyerAccountUuid = Guid.NewGuid();
            var buyerAccount = new BuyerAccount {BuyerAccountId = buyerAccountId, BuyerAccountUuid = buyerAccountUuid};
            var model = new UserQueryViewModel {BuyerAccountUuid = buyerAccountUuid};
            var user = new User {UserId = Guid.NewGuid()};
            var userBuyerRole = new UserBuyerRole {UserId = user.UserId, BuyerAccountId = buyerAccountId, RoleName = "Role"};
            user.UserBuyerRoles.Add(userBuyerRole);
            var users = new List<User> {user};

            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid)).Returns(Task.FromResult(buyerAccount));
            Mock.Mock<IUserService>().Setup(x => x.GetUsers(It.IsAny<UserQueryOptions>())).Returns(users.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<UserListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<UserListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).UserId, Is.EqualTo(user.UserId));
        }

        [Test]
        public async Task Get_ShouldReturnUserDetail()
        {
            // Arrange
            var user = new User {UserId = Guid.NewGuid(), Email = "jwu@brandscreen.com"};
            Mock.Mock<IUserService>().Setup(x => x.GetUser(user.UserId)).Returns(Task.FromResult(user));

            // Act
            var retVal = await Controller.Get(user.UserId);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<UserViewModel>>());
            var content = ((OkNegotiatedContentResult<UserViewModel>) retVal).Content;
            Assert.That(content.Email, Is.EqualTo(user.Email));
        }

        [Test]
        public async Task Create_ShouldReturnHttpOk()
        {
            // Arrange
            var model = new UserRegisterViewModel
            {
                Email = "jwu@brandscreen.com",
                CompanyType = "Other"
            };

            Mock.Mock<IUserService>().Setup(x => x.RegisterUser(It.IsAny<User>(),
                It.IsAny<string>(),
                It.IsAny<BuyerAccount>()))
                .Returns(Task.FromResult(IdentityResult.Failed("failed")));
            Mock.Mock<IUserService>().Setup(x => x.RegisterUser(It.Is<User>(user => user.Email == model.Email),
                model.Password,
                It.Is<BuyerAccount>(account => account.CompanyName == model.CompanyName)))
                .Returns(Task.FromResult(IdentityResult.Success));

            Mock.Mock<ICountryService>().Setup(x => x.GetCountry(It.IsAny<string>()))
                .Returns(Task.FromResult(new Country()));
            Mock.Mock<ICurrencyService>().Setup(x => x.GetCurrency(It.IsAny<string>()))
                .Returns(Task.FromResult(new Currency()));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ITimeZoneService>().Setup(x => x.GetTimeZone(It.IsAny<string>()))
                .Returns(Task.FromResult(new TimeZone()));

            // Act
            var result = await Controller.Register(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkResult>());
        }

        [Test]
        public async Task Post_ShouldReturnHttpOk()
        {
            // Arrange
            var model = new UserCreateViewModel
            {
                BuyerAccountUuid = Guid.NewGuid(),
                Email = "jwu@brandscreen.com",
                Role = "AgencyAdministrator",
                CostView = "AgencyCost"
            };
            var costView = (CostViewEnum) Enum.Parse(typeof (CostViewEnum), model.CostView, true);
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(model.BuyerAccountUuid.Value)).Returns(Task.FromResult(new BuyerAccount()));

            // Act
            var result = await Controller.Post(model);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkResult>());
            Mock.Mock<IUserService>().Verify(x =>
                x.AssignUserToBuyerAccount(model.BuyerAccountUuid.Value, model.Email, model.Role, costView, Guid.Parse(Controller.User.Identity.GetUserId())),
                Times.Once());
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var user = new User {UserId = Guid.NewGuid(), Email = "jwu@brandscreen.com", FirstName = "Jing"};
            var model = new UserPatchViewModel {FirstName = "SuperJing"};

            Mock.Mock<IUserService>().Setup(x => x.GetUser(user.UserId)).Returns(Task.FromResult(user));

            // Act
            var retVal = await Controller.Patch(user.UserId, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IUserService>().Verify(x => x.UpdateUser(It.Is<User>(y => y.FirstName == model.FirstName)), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var user = new User {UserId = Guid.NewGuid(), Email = "jwu@brandscreen.com", FirstName = "Jing"};
            var model = new UserDeleteViewModel {BuyerAccountUuid = Guid.NewGuid()};

            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(model.BuyerAccountUuid.Value)).Returns(Task.FromResult(new BuyerAccount()));
            Mock.Mock<IUserService>().Setup(x => x.GetUser(user.UserId)).Returns(Task.FromResult(user));

            // Act
            var retVal = await Controller.Delete(user.UserId, model);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IUserService>().Verify(x => x.RemoveUserFromBuyerAccount(model.BuyerAccountUuid.Value, user.UserId), Times.Once);
        }
    }
}