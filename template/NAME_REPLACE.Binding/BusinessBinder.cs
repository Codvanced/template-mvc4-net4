using IOC.FW.Abstraction.Container;
using IOC.FW.Abstraction.Container.Binding;
using IOC.FW.Shared.Enumerators;

using NAME_REPLACE.Abstraction.Business;
using NAME_REPLACE.Business;

namespace NAME_REPLACE.Binding
{
    public class BusinessBinder : IBinding
    {
        public void SetBinding(IAdapter adapter)
        {
            adapter.Register(
                typeof(ISampleBusiness),
                typeof(SampleBusiness),
                ContainerEnumerator.LifeCycle.Transient
            );
        }
    }
}
