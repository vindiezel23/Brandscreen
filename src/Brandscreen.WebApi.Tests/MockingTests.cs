using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Extras.Moq;
using Brandscreen.Core.Security;
using Brandscreen.Framework.Environment.AutofacUtil;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Brandscreen.WebApi.Tests
{
    /// <summary>
    /// This is the base class using Autofac AutoMocking
    /// Usage REF: http://docs.autofac.org/en/latest/integration/moq.html
    /// </summary>
    public class MockingTests
    {
        /// <summary>
        /// AutoMock object offers mocking object abilities within its context
        /// </summary>
        protected AutoMock Mock;

        [TestFixtureSetUp]
        public virtual void MockingTestFixtureSetUp()
        {
            AutofacAssemblyStore.LoadAssembly("Brandscreen.WebApi"); // AutoMapperModule needs assemblies to find mapper profiles
        }

        [TestFixtureTearDown]
        public virtual void MockingTestFixtureTearDown()
        {
            AutofacAssemblyStore.ClearAssemblies();
        }

        [SetUp]
        public virtual void MockingSetUp()
        {
            Mock = AutoMock.GetLoose();
            new UnitTestModule().Configure(Mock.Container.ComponentRegistry);
        }

        [TearDown]
        public virtual void MockingTearDown()
        {
            Mock.Dispose();
            Mock = null;
        }

        /// <summary>
        /// Returns a mocking repository object for setup when retrieve from IUnitOfWorkAsync.RepositoryAsync
        /// </summary>
        protected Mock<IRepositoryAsync<TEntity>> MockUnitOfWorkRepository<TEntity>() where TEntity : class, IObjectState
        {
            Mock.Mock<IUnitOfWorkAsync>()
                .Setup(x => x.RepositoryAsync<TEntity>())
                .Returns(Mock.Container.Resolve<IRepositoryAsync<TEntity>>());
            return Mock.Mock<IRepositoryAsync<TEntity>>();
        }
    }

    public class ApiControllerMockingTests : MockingTests
    {
        private const string OwinEnvironmentKey = "MS_OwinEnvironment";
        private const string OwinContextKey = "MS_OwinContext";
        private const string IdentityKeyPrefix = "AspNet.Identity.Owin:";

        private readonly GenericPrincipal _genericPrincipal = new GenericPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "63ef2ec5-4a6a-4f24-8eac-404848a2bd4c")
        }), new[] {string.Empty});

        /// <summary>
        /// Creates a Controller to be tested by simulating a logged in user
        /// </summary>
        protected virtual T CreateControllerWithPrincipal<T>(params Parameter[] parameters) where T : ApiController
        {
            var controller = Mock.Create<T>(parameters);
            controller.User = _genericPrincipal; // ApiController.User.Identity.GetUserId() returns "63ef2ec5-4a6a-4f24-8eac-404848a2bd4c"
            return controller;
        }

        /// <summary>
        /// Creates a mocked IOwinContext for HttpRequestMessage so that Request.GetOwinContext() returns it
        /// </summary>
        protected virtual Mock<IOwinContext> MockOwinContext(HttpRequestMessage request)
        {
            var mockedOwinContext = Mock.Mock<IOwinContext>();
            request.Properties.Add(OwinContextKey, mockedOwinContext.Object);
            return mockedOwinContext;
        }

        /// <summary>
        /// Creates a mocked uesr manager in owin context so that Request.GetOwinContext().GetUserManager<T/>() returns it
        /// </summary>
        protected virtual void MockUserManager<T>(Mock<IOwinContext> mockedOwinContext)
        {
            var userManager = Mock.Create<T>();
            mockedOwinContext.Setup(x => x.Get<T>(IdentityKeyPrefix + typeof (T).AssemblyQualifiedName))
                .Returns(userManager);
        }

        /// <summary>
        /// Creates a mocked authentication manager in owin context so that Request.GetOwinContext().Authentication returns it
        /// </summary>
        protected virtual Mock<IAuthenticationManager> MockAuthenticationManager(Mock<IOwinContext> mockedOwinContext)
        {
            var mockedAuthenticationManager = Mock.Mock<IAuthenticationManager>();
            mockedOwinContext.SetupGet(x => x.Authentication).Returns(mockedAuthenticationManager.Object);
            mockedAuthenticationManager.SetupGet(x => x.User).Returns(_genericPrincipal);
            return mockedAuthenticationManager;
        }
    }

    public class ApiControllerMockingTests<T> : ApiControllerMockingTests where T : ApiController
    {
        protected T Controller;
        protected HttpRequestMessage Request;
        protected HttpConfiguration Configuration;

        /// <summary>
        /// Mocked owin context object
        /// </summary>
        protected Mock<IOwinContext> MockedOwinContext;

        [SetUp]
        public virtual void ApiControllerMockingSetUp()
        {
            Controller = CreateControllerWithPrincipal<T>();

            Request = new HttpRequestMessage();
            Controller.Request = Request;

            Configuration = new HttpConfiguration();
            Controller.Request.SetConfiguration(Configuration);

            MockedOwinContext = MockOwinContext(Request);
            MockUserManager<ApplicationUserManager>(MockedOwinContext);
            MockAuthenticationManager(MockedOwinContext);
        }

        [TearDown]
        public virtual void ApiControllerMockingTearDown()
        {
            // Controller.Dispose(); // no need to dispose the controller since it is created by Autofac, it will get disposed when Autofac container disposes
            Controller = null;
        }
    }
}