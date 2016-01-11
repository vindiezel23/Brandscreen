using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Autofac;
using NUnit.Framework;
using Repository.Pattern.UnitOfWork;

namespace Brandscreen.WebApi.Integration.Tests
{
    /// <summary>
    /// Offers ablity of resoving components via IoC, and database transaction in each test case
    /// </summary>
    public class IocSupportedTests
    {
        private const string TagTestFixture = "TestScope_TestFixture";
        private const string TagTest = "TestScope_Test";

        private readonly Stack<ILifetimeScope> _scopes = new Stack<ILifetimeScope>();

        private IList<IUnitOfWorkAsync> _unitOfWorks;
        private DbContextTransaction _membershipDbContextTransaction;

        /// <summary>
        /// Current running autofac lifetime scope for resolving instances
        /// </summary>
        protected ILifetimeScope Container;

        [TestFixtureSetUp]
        public void IocSupportedTestFixtureSetUp()
        {
            // save root scope
            PushScope(HostServer.Host.LifetimeScope);

            // set current scope to test fixture
            var testFixtureScope = HostServer.Host.LifetimeScope.BeginLifetimeScope(TagTestFixture);
            PushScope(testFixtureScope);
        }

        [TestFixtureTearDown]
        public void IocSupportedTestFixtureTearDown()
        {
            PopScope();
        }

        [SetUp]
        public void IocSupportedSetUp()
        {
            // set current scope to test: starting a new autofac scope for each test
            Container = HostServer.Host.LifetimeScope.BeginLifetimeScope(TagTest);
            PushScope(Container);

            StartTransaction();
        }

        [TearDown]
        public void IocSupportedTearDown()
        {
            RollbackTransaction();

            PopScope();
        }

        /// <summary>
        /// Save database changes temporary
        /// </summary>
        protected void SaveDbChanges()
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                unitOfWork.SaveChanges();
            }
        }

        private void StartTransaction()
        {
            // starting a new transaction which will be rollback at the end of each test
            _unitOfWorks = Container.Resolve<IEnumerable<IUnitOfWorkAsync>>().ToList();
            foreach (var unitOfWork in _unitOfWorks)
            {
                unitOfWork.BeginTransaction();
            }

            var membershipDbContext = Container.ResolveNamed<DbContext>("membership");
            _membershipDbContextTransaction = membershipDbContext.Database.BeginTransaction();
        }

        private void RollbackTransaction()
        {
            foreach (var unitOfWork in _unitOfWorks)
            {
                unitOfWork.Rollback();
            }
            _membershipDbContextTransaction.Rollback();
        }

        private void PushScope(ILifetimeScope scope)
        {
            _scopes.Push(scope);
            Startup.SetCurrentTestScope(scope);
        }

        private void PopScope()
        {
            _scopes.Pop().Dispose();
            Startup.SetCurrentTestScope(_scopes.Peek());
        }
    }
}