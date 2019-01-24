using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Unity.Wcf.Tests.TestObjects
{
    public class TestServiceHostFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ITestService, TestService>();
        }

        //public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses) => base.CreateServiceHost(typeof(TestService), baseAddresses);
    }
}
