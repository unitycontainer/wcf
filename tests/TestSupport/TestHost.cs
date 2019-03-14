using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace Unity.Wcf.Tests.TestSupport
{
    internal class TestHost<TContract, TService> where TService : class, TContract
    {
        private readonly ServiceHost _host;
        private ChannelFactory<TContract> _factory;

        public TestHost(IUnityContainer container = null, [CallerMemberName] string name = "")
        {
            BaseAddress = new Uri($"net.tcp://localhost/{TargetType.FullName}.{name}");
            Container = container ?? new UnityContainer();
            Container.RegisterType<TContract, TService>();
            _host = new UnityServiceHost(Container, TargetType, BaseAddress);
        }

        public Uri BaseAddress { get; }
        public IUnityContainer Container { get; }

        public Type TargetType => typeof(TService);

        public TContract GetProxy() => _factory.CreateChannel();

        public void Start()
        {
            _host.Open();

            var se = _host.Description.Endpoints.First();
            _factory = new ChannelFactory<TContract>(se.Binding, se.Address);
        }

        public void Stop()
        {
            _host.Close();
            _factory = null;
        }
    }
}
