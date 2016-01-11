using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Brandscreen.Framework.Environment;
using Brandscreen.Framework.Environment.AutofacUtil;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Brandscreen.WebApi.Integration.Tests
{
    [SetUpFixture]
    public class HostServer
    {
        public const string Port = "9000";
        public static string Url;

        /// <summary>
        /// Test host
        /// </summary>
        public static IHost Host;

        private IDisposable _webApp;

        [SetUp]
        public void SetUp()
        {
            // init container host for testing, web api will use different one
            AutofacAssemblyStore.LoadAssembly("Brandscreen.Framework");
            AutofacAssemblyStore.LoadAssembly("Brandscreen.Core");
            AutofacAssemblyStore.LoadAssembly("Brandscreen.WebApi");
            Host = HostStarter.CreateHost();
            AutofacAssemblyStore.ClearAssemblies(); // clear loaded assemblies so that it won't affect web api Startup

            // passes the test scope to web app, so it will use to activate RepositoryTestModule
            // the scope will be set again on the starting of each test case in IocSupportedTests
            // the scope is used for resolving same instance of objects as the ones in current running test case for each http request made through the test case
            // e.g. the database context must be the same both in the current running test case and web api current request context, 
            // then it is able to rollback all temporary data within the test scope.
            Startup.SetCurrentTestScope(Host.LifetimeScope);

            // init web app
            var ipAddress = LocalIpAddress();
            Url = $"http://{ipAddress?.ToString() ?? "localhost"}:{Port}/";
            Console.WriteLine("starting web app at {0}.", Url);
            _webApp = WebApp.Start<Startup>(Url);
            Console.WriteLine("started web app.");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("disposing web app.");
            _webApp.Dispose();
            Host.Dispose();
            Console.WriteLine("terminated web app.");
        }

        private static IPAddress LocalIpAddress()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}