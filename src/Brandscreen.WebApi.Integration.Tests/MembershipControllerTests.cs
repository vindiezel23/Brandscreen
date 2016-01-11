using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Brandscreen.Core.Services.Memberships;
using Flurl;
using Flurl.Http;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [TestFixture]
    public class MembershipControllerTests : IocSupportedTests
    {
        [Test]
        public async Task Post_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users";
            var data = new
            {
                Email = "test@g.cn",
                Password = "abcd1234",
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();

            // Assert

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Email, Is.EqualTo(data.Email));
        }

        [Test]
        public async Task Patch_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users";
            var membershipService = Container.Resolve<IMembershipService>();
            var membership = membershipService.GetUsers().First();
            var data = new
            {
                Password = "abcd1234",
            };

            // Act
            var response = await url.AppendPathSegment(membership.Id)
                .WithOAuthBearerToken(await TestHelper.Token)
                .PatchUrlEncodedAsync(data);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Delete_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users";
            var data = new
            {
                Email = "test@g.cn",
                Password = "abcd1234",
            };

            // Act
            var newUser = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();
            var response = await $"{url}/{newUser.Id}"
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public async Task Get_ShouldReturnUserDetail()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users";
            var membershipService = Container.Resolve<IMembershipService>();
            var membership = membershipService.GetUsers().First();

            // Act
            var response = await url.AppendPathSegment(membership.Id)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(Guid.Parse(response.Id), Is.EqualTo(Guid.Parse(membership.Id)));
        }

        [Test]
        public async Task GetByEmail_ShouldReturnUserDetail()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users";
            var data = new
            {
                Email = "test@g.cn",
                Password = "abcd1234",
            };

            // Act
            await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data);
            var response = await $"{url}?Email={data.Email}"
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Email, Is.EqualTo(data.Email));
        }

        [Test]
        public async Task Get_ShouldReturnUserList()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/users/";
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
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }

        [Test]
        public async Task PostRole_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/roles";
            var data = new
            {
                RoleName = "TestUser"
            };

            // Act
            var response = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();

            // Assert

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Name, Is.EqualTo(data.RoleName));
        }

        [Test]
        public async Task DeleteRole_ShouldReturnOk()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/roles";
            var data = new
            {
                RoleName = "TestUser"
            };

            // Act
            var newRole = await url.WithOAuthBearerToken(await TestHelper.Token)
                .PostUrlEncodedAsync(data).ReceiveJson();
            var response = await $"{url}/{newRole.Id}"
                .WithOAuthBearerToken(await TestHelper.Token)
                .DeleteAsync();

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public async Task GetRoleById_ShouldReturnRoleDetail()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/roles";
            var membershipService = Container.Resolve<IMembershipService>();
            var role = membershipService.GetRoles().First();

            // Act
            var response = await url.AppendPathSegment(role.Id)
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(Guid.Parse(response.Id), Is.EqualTo(Guid.Parse(role.Id)));
        }

        [Test]
        public async Task GetRoleByName_ShouldReturnRoleDetail()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/roles";

            // Act
            var response = await $"{url}?Role=User"
                .WithOAuthBearerToken(await TestHelper.Token)
                .GetAsync()
                .ReceiveJson();

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Name, Is.EqualTo("User"));
        }

        [Test]
        public async Task GetRoles_ShouldReturnRoleList()
        {
            // Arrange 
            var url = HostServer.Url + "api/memberships/roles/";
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
            Assert.That(response.PageSize, Is.EqualTo(data.PageSize));
        }
    }
}