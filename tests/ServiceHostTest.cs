using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [TestMethod]
        public void TestCall()
        {

            var host = new TestSupport.TestHost<ITestService, TestService>();
            try
            {
                using (var container = new UnityContainer())
                //using (var http = new HttpClient { BaseAddress = baseAddress })
                {
                    // Enable metadata publishing.
                    //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    //smb.HttpGetEnabled = true;
                    //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    //host.Description.Behaviors.Add(smb);

                    // Open the ServiceHost to start listening for messages. Since
                    // no endpoints are explicitly configured, the runtime will create
                    // one endpoint per base address for each service contract implemented
                    // by the service.
                    host.Start();

                    Console.WriteLine("The service is ready at {0}", host.BaseAddress);
                    //Console.WriteLine("Press <Enter> to stop the service.");
                    //Console.ReadLine();

                    var proxy = host.GetProxy();
                    var res = proxy.GetData(5);


                }
            }
            finally
            {
                host.Stop();
            }
        }
    }
}
