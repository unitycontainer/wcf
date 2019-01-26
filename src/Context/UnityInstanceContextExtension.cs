using System;
using System.ServiceModel;

namespace Unity.Wcf
{
    public class UnityInstanceContextExtension : IExtension<InstanceContext>
    {
        private IUnityContainer _childContainer;

        public void Attach(InstanceContext owner)
        {
        }

        public void Detach(InstanceContext owner)
        {
        }

        public void DisposeOfChildContainer() => _childContainer?.Dispose();

        public IUnityContainer GetChildContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            return _childContainer ?? (_childContainer = container.CreateChildContainer());
        }
    }
}
