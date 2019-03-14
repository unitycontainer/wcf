using System.ServiceModel;
using System.Web.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Wcf.Tests
{
    [TestClass]
    public class AssemblyInit
    {
        [AssemblyInitialize]
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
    }
}
