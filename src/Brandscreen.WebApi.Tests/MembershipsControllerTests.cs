using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Memberships;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Moq;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class MembershipsControllerTests : ApiControllerMockingTests<MembershipsController>
    {
        [Test]
        public async Task Get_ShouldReturnUserList()
        {
            // Arrange
            var applicationUser = new ApplicationUser {Email = "jwu@brandscreen.com"};
            var applicationUsers = new List<ApplicationUser> {applicationUser};

            Mock.Mock<IMembershipService>().Setup(x => x.GetUsers()).Returns(applicationUsers.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(new Pagination());

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
            Assert.That(retVal.Data.ElementAt(0).Email, Is.EqualTo(applicationUser.Email));
        }

        [Test]
        public async Task Get_ShouldReturnUserDetail()
        {
            // Arrange
            var id = Guid.NewGuid();
            var applicationUser = new ApplicationUser {Id = id.ToString(), Email = "jwu@brandscreen.com"};
            Mock.Mock<IMembershipService>().Setup(x => x.GetUser(id)).ReturnsAsync(applicationUser);

            // Act
            var retVal = await Controller.Get(id);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<ApplicationUserViewModel>>());
            var content = ((OkNegotiatedContentResult<ApplicationUserViewModel>) retVal).Content;
            Assert.That(content.Email, Is.EqualTo(content.Email));
        }

        [Test]
        public async Task GetByEmail_ShouldReturnUserDetail()
        {
            // Arrange
            var applicationUser = new ApplicationUser {Id = Guid.NewGuid().ToString(), Email = "jwu@brandscreen.com"};
            Mock.Mock<IMembershipService>().Setup(x => x.GetUser(applicationUser.Email)).ReturnsAsync(applicationUser);

            // Act
            var retVal = await Controller.Get(applicationUser.Email);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<ApplicationUserViewModel>>());
            var content = ((OkNegotiatedContentResult<ApplicationUserViewModel>) retVal).Content;
            Assert.That(content.Email, Is.EqualTo(content.Email));
        }

        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange
            var model = new ApplicationUserCreateViewModel();

            Mock.Mock<IMembershipService>().Setup(x => x.CreateUser(It.IsAny<ApplicationUserCreateOptions>()))
                .ReturnsAsync(IdentityResult.Success);
            Mock.Mock<IMembershipService>().Setup(x => x.GetUser(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            // Act
            var retVal = await Controller.Post(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<ApplicationUserViewModel>>());
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new ApplicationUserPatchViewModel();

            Mock.Mock<IMembershipService>().Setup(x => x.UpdateUser(It.IsAny<ApplicationUserUpdateOptions>()))
                .ReturnsAsync(IdentityResult.Success);
            Mock.Mock<IMembershipService>().Setup(x => x.GetUser(It.IsAny<Guid>()))
                .ReturnsAsync(new ApplicationUser());

            // Act
            var retVal = await Controller.Patch(id, model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkResult>());
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange
            var id = Guid.NewGuid();

            Mock.Mock<IMembershipService>().Setup(x => x.DeleteUser(id))
                .ReturnsAsync(IdentityResult.Success);
            Mock.Mock<IMembershipService>().Setup(x => x.GetUser(It.IsAny<Guid>()))
                .ReturnsAsync(new ApplicationUser());

            // Act
            var retVal = await Controller.Delete(id);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public async Task GetRoles_ShouldReturnRoleList()
        {
            // Arrange
            var identityRole = new IdentityRole {Name = "Admin"};
            var identityRoles = new List<IdentityRole> {identityRole};

            Mock.Mock<IMembershipService>().Setup(x => x.GetRoles()).Returns(identityRoles.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.GetRoles(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.TotalItemCount, Is.EqualTo(1));
            Assert.That(retVal.Data.ElementAt(0).Name, Is.EqualTo(identityRole.Name));
        }

        [Test]
        public async Task GetRoleById_ShouldReturnRoleDetail()
        {
            // Arrange
            var id = Guid.NewGuid();
            var identityRole = new IdentityRole {Id = id.ToString(), Name = "SuperJing"};
            Mock.Mock<IMembershipService>().Setup(x => x.GetRole(id)).ReturnsAsync(identityRole);

            // Act
            var retVal = await Controller.GetRole(id);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<ApplicationRoleViewModel>>());
            var content = ((OkNegotiatedContentResult<ApplicationRoleViewModel>) retVal).Content;
            Assert.That(content.Name, Is.EqualTo(content.Name));
        }

        [Test]
        public async Task GetRoleByName_ShouldReturnRoleDetail()
        {
            // Arrange
            var id = Guid.NewGuid();
            var identityRole = new IdentityRole {Id = id.ToString(), Name = "SuperJing"};
            Mock.Mock<IMembershipService>().Setup(x => x.GetRole(identityRole.Name)).ReturnsAsync(identityRole);

            // Act
            var retVal = await Controller.GetRole(identityRole.Name);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<ApplicationRoleViewModel>>());
            var content = ((OkNegotiatedContentResult<ApplicationRoleViewModel>) retVal).Content;
            Assert.That(content.Name, Is.EqualTo(content.Name));
        }

        [Test]
        public async Task PostRole_ShouldReturnOk()
        {
            // Arrange
            var model = new ApplicationRoleCreateViewModel();

            Mock.Mock<IMembershipService>().Setup(x => x.CreateRole(It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            Mock.Mock<IMembershipService>().Setup(x => x.GetRole(It.IsAny<string>()))
                .ReturnsAsync(new IdentityRole());

            // Act
            var retVal = await Controller.PostRole(model);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<CreatedAtRouteNegotiatedContentResult<ApplicationRoleViewModel>>());
        }


        [Test]
        public async Task DeleteRole_ShouldReturnOk()
        {
            // Arrange
            var id = Guid.NewGuid();

            Mock.Mock<IMembershipService>().Setup(x => x.DeleteRole(id))
                .ReturnsAsync(IdentityResult.Success);
            Mock.Mock<IMembershipService>().Setup(x => x.GetRole(It.IsAny<Guid>()))
                .ReturnsAsync(new IdentityRole());

            // Act
            var retVal = await Controller.DeleteRole(id);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<StatusCodeResult>());
            Assert.That(((StatusCodeResult) retVal).StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}