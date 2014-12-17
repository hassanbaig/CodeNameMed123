using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderFeeRepository : IRepository
    {
        public ProviderFeeRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderFeeRepository(MedicareDevEntities context)
        {
            _context = context;
        }       
        public void Update(ProviderFee entity)
        {
            var providerFee = (from proFee in _context.ProviderFees
                               where proFee.ProviderId == entity.ProviderId
                               select proFee).FirstOrDefault();
            if (providerFee != null)
            {
                providerFee.ProviderId = entity.ProviderId;
                providerFee.Fee = entity.Fee;
                providerFee.Duration = entity.Duration;
                providerFee.Type = "paid";
                providerFee.Currency = "PKR";
            }
            else
            {
                _context.ProviderFees.Add(entity);
            }
        }
    }
}
