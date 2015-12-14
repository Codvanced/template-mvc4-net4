
using NAME_REPLACE.Abstraction.DAO;
using NAME_REPLACE.Entities;

using IOC.FW.Core.Abstraction.Repository;
using IOC.FW.Core.Implementation.Base;

namespace NAME_REPLACE.DAO
{
    public class SampleDAO : BaseRepository<Sample>, ISampleDAO
    {
        private readonly IRepository<Sample> _dao;

        public SampleDAO(IRepository<Sample> dao) 
            : base(dao)
        {
            _dao = dao;
        }

        public Sample SampleDAOAction()
        {
            var myQuery = _dao.ExecuteQuery(
                sql: "SELECT 1 AS ID, 'TESTE' AS NAME, CAST(1 AS BIT) AS FLAG",
                parameters: null
            );

            return myQuery != null ? myQuery[0] : null;
        }
    }
}
