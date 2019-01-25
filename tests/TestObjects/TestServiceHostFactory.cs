namespace Unity.Wcf.Tests.TestObjects
{
    public class TestServiceHostFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ITestService, TestService>();
        }
    }
}
