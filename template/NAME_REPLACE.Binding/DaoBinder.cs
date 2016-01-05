using IOC.FW.Core.Abstraction.Container;
using IOC.FW.Core.Abstraction.Container.Binding;
using IOC.FW.Shared.Enumerators;

using NAME_REPLACE.Abstraction.DAO;
using NAME_REPLACE.DAO;

namespace NAME_REPLACE.Binding
{
    public class DaoBinder : IBinding
    {
        public void SetBinding(IAdapter adapter)
        {
            adapter.Register(
                typeof(ISampleDAO), 
                typeof(SampleDAO), 
                ContainerEnumerator.LifeCycle.Transient
            );
        }
    }
}
