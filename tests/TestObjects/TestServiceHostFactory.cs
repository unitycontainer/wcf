using System;

namespace Unity.Wcf.Tests.TestObjects
{
    public class TestServiceHostFactory : UnityServiceHostFactory
    {
        public Action<IUnityContainer> Configure { get; set; }

        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ITestService, TestService>();
            Configure?.Invoke(container);
        }
    }
}
