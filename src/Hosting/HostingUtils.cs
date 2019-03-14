using System.Collections.Generic;
using System.ServiceModel.Description;

namespace Unity.Wcf.Hosting
{
    internal static class HostingUtils
    {
        public static void ApplyContractBehaviors(IDictionary<string, ContractDescription> implementedContracts, IUnityContainer container)
        {
            var registeredContractBehaviors = container.ResolveAll<IContractBehavior>();

            foreach (var contractBehavior in registeredContractBehaviors)
            {
                foreach (var contractDescription in implementedContracts.Values)
                {
                    contractDescription.Behaviors.Add(contractBehavior);
                }
            }
        }

        public static void ApplyUnityContractBehavior(IDictionary<string, ContractDescription> implementedContracts, IUnityContainer container)
        {
            foreach (var contractDescription in implementedContracts.Values)
            {
                var contractBehavior =
                    new UnityContractBehavior(new UnityInstanceProvider(container, contractDescription.ContractType));

                contractDescription.Behaviors.Add(contractBehavior);
            }
        }

        public static void ApplyServiceBehaviors(KeyedByTypeCollection<IServiceBehavior> behaviors, IUnityContainer container)
        {
            var registeredServiceBehaviors = container.ResolveAll<IServiceBehavior>();

            foreach (var serviceBehavior in registeredServiceBehaviors)
            {
                behaviors.Add(serviceBehavior);
            }
        }
    }
}
