using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderInsurancesRepository : IRepository
    {
        public ProviderInsurancesRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderInsurancesRepository(MedicareDevEntities context)
        {
            _context = context;
        }
        public void AddProviderInsurances(ProviderInsurance entity)
        {
            var data = (from proIns in _context.ProviderInsurances
                        where proIns.ProviderId == entity.ProviderId && proIns.InsuranceId == entity.InsuranceId
                        select proIns).FirstOrDefault();

            if (data == null)
            { _context.ProviderInsurances.Add(entity); }
            else
            { throw new Exception("Insurance already added."); }
        }        
        public void Delete(ProviderInsurance entity)
        {
            var data1 = (from proIns in _context.ProviderInsurances
                         where proIns.ProviderId == entity.ProviderId && proIns.InsuranceId == entity.InsuranceId
                         select proIns).FirstOrDefault();

            if (data1 != null)
            {
                _context.ProviderInsurances.Remove(data1);
            }
            else
            { throw new Exception("Insurance does not exist."); }
        }
    }
}
