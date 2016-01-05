using NAME_REPLACE.Abstraction.Business;
using NAME_REPLACE.Abstraction.DAO;
using NAME_REPLACE.Entities;

using IOC.FW.Core.Implementation.Base;

using System;

namespace NAME_REPLACE.Business
{
    public class SampleBusiness : BaseBusiness<Sample>, ISampleBusiness
    {
        private readonly ISampleDAO _dao;

        public SampleBusiness(ISampleDAO dao)
            : base(dao)
        {
            _dao = dao;
        }

        public void SampleFeature()
        {
            var mySample = _dao.SampleDAOAction();
            Console.WriteLine(mySample);
        }
    }
}
