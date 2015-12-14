using IOC.FW.Core.Abstraction.Business;

using NAME_REPLACE.Entities;

namespace NAME_REPLACE.Abstraction.Business
{
    public interface ISampleBusiness 
        : IBaseBusiness<Sample>
    {
        void SampleFeature();
    }
}
