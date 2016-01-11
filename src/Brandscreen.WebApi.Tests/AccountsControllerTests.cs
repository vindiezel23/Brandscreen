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
using Moq;
using NUnit.Framework;
using TimeZone = Brandscreen.Entities.TimeZone;

namespace Brandscreen.WebApi.Tests
{
    public class AccountsControllerTests : ApiControllerMockingTests<AccountsController>
    {
        [Test]
        public async Task Get_ShouldReturnListOfAccounts()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var account1 = new BuyerAccount {CompanyName = "Brandscreen"};
            var account2 = new BuyerAccount {CompanyName = "WJsHome"};
            var accounts = new List<BuyerAccount> {account1, account2};

            var model = new AccountQueryViewModel {UserId = userId};

            Mock.Mock<IAccountService>().Setup(x => x.GetAccounts(It.IsAny<AccountQueryOptions>()))
                .Returns(accounts.ToAsyncEnumerable());
            Mock.Mock<IUserService>().Setup(x => x.GetUser(userId)).Returns(Task.FromResult(new User()));

            // Act
            var retVal = await Controller.Get(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<AccountListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<AccountListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(2));
            var data = content.Data.ToList();
            Assert.That(data[0].CompanyName, Is.EqualTo(account1.CompanyName));
            Assert.That(data[1].CompanyName, Is.EqualTo(account2.CompanyName));
        }

        [Test]
        public async Task Get_ShouldReturnAccountDetails()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            var account = new BuyerAccount {BuyerAccountUuid = buyerAccountUuid, CompanyName = "Brandscreen"};
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid))
                .Returns(Task.FromResult(account));

            // Act
            var retVal = await Controller.Get(buyerAccountUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<AccountViewModel>>());
            var content = ((OkNegotiatedContentResult<AccountViewModel>) retVal).Content;
            Assert.That(content, Is.Not.Null);
            Assert.That(content.CompanyName, Is.EqualTo(account.CompanyName));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new AccountCreateViewModel {UserId = Guid.NewGuid(), CompanyName = "Brandscreen", CompanyType = "Other"};
            var owner = new User();
            Mock.Mock<IUserService>().Setup(x => x.GetUser(model.UserId))
                .Returns(Task.FromResult(owner));
            Mock.Mock<ICountryService>().Setup(x => x.GetCountry(It.IsAny<string>()))
                .Returns(Task.FromResult(new Country()));
            Mock.Mock<ICurrencyService>().Setup(x => x.GetCurrency(It.IsAny<string>()))
                .Returns(Task.FromResult(new Currency()));
            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguage(It.IsAny<string>()))
                .Returns(Task.FromResult(new Language()));
            Mock.Mock<ITimeZoneService>().Setup(x => x.GetTimeZone(It.IsAny<string>()))
                .Returns(Task.FromResult(new TimeZone()));

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<AccountViewModel>>());
            Mock.Mock<IAccountService>().Verify(x => x.CreateAccount(It.IsAny<BuyerAccount>(), owner), Times.Once);
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            var account = new BuyerAccount {BuyerAccountUuid = buyerAccountUuid, CompanyName = "Brandscreen"};
            var model = new AccountPatchViewModel {CompanyName = "WJsHome"};
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid))
                .ReturnsAsync(account);

            // Act
            var retVal = await Controller.Patch(buyerAccountUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IAccountService>().Verify(x => x.UpdateAccount(It.Is<BuyerAccount>(buyerAccount => buyerAccount.CompanyName == model.CompanyName)), Times.Once);
        }

        [Test]
        public async Task PatchTerms_ShouldReturnOk()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            var account = new BuyerAccount {BuyerAccountUuid = buyerAccountUuid, CompanyName = "Brandscreen"};
            var model = new AccountTermsPatchViewModel {CreditLimit = 1000};
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid))
                .ReturnsAsync(account);

            // Act
            var retVal = await Controller.PatchTerms(buyerAccountUuid, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IAccountService>().Verify(x => x.UpdateAccount(It.Is<BuyerAccount>(buyerAccount => buyerAccount.CreditLimit == model.CreditLimit)), Times.Once);
        }

        [Test]
        public async Task GetStatus_ShouldReturnAccountStatus()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            Mock.Mock<IAccountService>().Setup(x => x.GetAccountStatus(buyerAccountUuid))
                .Returns(Task.FromResult(AccountStatusEnum.Activated));

            // Act
            var retVal = await Controller.GetStatus(buyerAccountUuid);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.Status, Is.EqualTo(AccountStatusEnum.Activated.ToString()));
        }

        [Test]
        public async Task PutStatus_ShouldReturnOk()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            var model = new AccountStatusViewModel {Status = AccountStatusEnum.Suspended.ToString()};
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid))
                .Returns(Task.FromResult(new BuyerAccount()));

            // Act
            var retVal = await Controller.PutStatus(buyerAccountUuid, model);

            // Assert
            Assert.That(retVal, Is.TypeOf<OkResult>());
            Mock.Mock<IAccountService>().Verify(x => x.ChangeAccountStatus(buyerAccountUuid, AccountStatusEnum.Suspended), Times.Once);
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var buyerAccountUuid = Guid.NewGuid();
            Mock.Mock<IAccountService>().Setup(x => x.GetAccount(buyerAccountUuid))
                .Returns(Task.FromResult(new BuyerAccount()));

            // Act
            var retVal = await Controller.Delete(buyerAccountUuid);

            // Assert
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            Mock.Mock<IAccountService>().Verify(x => x.DeleteAccount(buyerAccountUuid), Times.Once);
        }
    }
}