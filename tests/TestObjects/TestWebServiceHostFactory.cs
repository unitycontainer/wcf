using Unity.Wcf.Hosting.Web;

namespace Unity.Wcf.Tests.TestObjects
{
    internal class TestWebServiceHostFactory : UnityWebServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container) => container.RegisterType<ITestService, TestService>();
    }
}
