using System;
using System.ServiceModel.Web;

namespace Unity.Wcf.Hosting.Web
{
    /// <summary>
    /// A <see cref="T:System.ServiceModel.ServiceHost" /> for WCF REST services. See <a href="https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/wcf-web-http-programming-object-model#webservicehost">here</a> for more information.
    /// </summary>
    public class UnityWebServiceHost : WebServiceHost
    {
        public UnityWebServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
                            : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            HostingUtils.ApplyServiceBehaviors(Description.Behaviors, container);
            HostingUtils.ApplyContractBehaviors(ImplementedContracts, container);
            HostingUtils.ApplyUnityContractBehavior(ImplementedContracts, container);
        }
    }
}
