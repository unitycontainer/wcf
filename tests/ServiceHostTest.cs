using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Unity.Wcf.Tests.TestObjects;

namespace Unity.Wcf.Tests
{
    [TestClass]
    public class ServiceHostTest
    {

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            if (!HostingEnvironment.IsHosted)
            {
                // The instance constructor hooks up the singleton hosting environment, ewww...
                new HostingEnvironment();

                // Check the hosting environment is fully initialized
                ServiceHostingEnvironment.EnsureInitialized();
            }
        }

        [TestMethod]
        public void ShouldCreateServiceHost()
        {
            var fac = new TestServiceHostFactory();

            var host = fac.CreateServiceHost(typeof(TestService).AssemblyQualifiedName, new Uri[0]);

            Assert.IsInstanceOfType(host, typeof(UnityServiceHost));

            Assert.AreEqual(host.Description.ServiceType, typeof(TestService));
        }
    }
}
