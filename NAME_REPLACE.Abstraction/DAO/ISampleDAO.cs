using IOC.FW.Core.Abstraction.Repository;

using NAME_REPLACE.Entities;

namespace NAME_REPLACE.Abstraction.DAO
{
    public interface ISampleDAO : IRepository<Sample>
    {
        Sample SampleDAOAction();
    }
}
