using System;
using System.ServiceModel;
using Unity.Wcf.Hosting;

namespace Unity.Wcf
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
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
