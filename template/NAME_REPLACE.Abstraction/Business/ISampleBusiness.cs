using IOC.FW.Abstraction.Business;

using NAME_REPLACE.Entities;

namespace NAME_REPLACE.Abstraction.Business
{
    public interface ISampleBusiness 
        : IBaseBusiness<Sample>
    {
        void SampleFeature();
    }
}
