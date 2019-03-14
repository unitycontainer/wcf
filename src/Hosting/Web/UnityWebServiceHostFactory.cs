using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Unity.Wcf.Hosting.Web
{
    /// <summary>
    /// A <see cref="T:System.ServiceModel.ServiceHostFactory" /> for WCF REST services. See <a href="https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/wcf-web-http-programming-object-model#webservicehost">here</a> for more information.
    /// </summary>
    public abstract class UnityWebServiceHostFactory : WebServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = new UnityContainer();

            ConfigureContainer(container);

            return new UnityWebServiceHost(container, serviceType, baseAddresses);
        }
    }
}
