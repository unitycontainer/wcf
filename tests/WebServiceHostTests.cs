using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Wcf.Hosting.Web;
using Unity.Wcf.Tests.TestObjects;

namespace Unity.Wcf.Tests
{
    [TestClass]
    public class WebServiceHostTests
    {
        [TestMethod]
        public void ShouldCreateWebServiceHost()
        {
            var fac = new TestWebServiceHostFactory();

            var host = fac.CreateServiceHost(typeof(TestService).AssemblyQualifiedName, new Uri[0]);

            Assert.IsInstanceOfType(host, typeof(UnityWebServiceHost));

            Assert.AreEqual(host.Description.ServiceType, typeof(TestService));
        }
    }
}
