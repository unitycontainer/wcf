using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Unity.Wcf
{
    public abstract class UnityServiceHostFactory : ServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = new UnityContainer();

            ConfigureContainer(container);

            return new UnityServiceHost(container, serviceType, baseAddresses);
        }
    }
}
