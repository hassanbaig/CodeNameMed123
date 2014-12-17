using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderServicesRepository : IRepository
    {
        public ProviderServicesRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderServicesRepository(MedicareDevEntities context)
        {
            _context = context;
        }
        public void AddProviderService(ProviderService entity)
        {
            var data = (from proSer in _context.ProviderServices
                        where proSer.ProviderId == entity.ProviderId && proSer.ServiceId == entity.ServiceId
                        select proSer).FirstOrDefault();

            if (data == null)
            { _context.ProviderServices.Add(entity); }
            else
            { throw new Exception("Service already added."); }
        }      
        public void Delete(ProviderService entity)
        {
            var data = (from proSer in _context.ProviderServices
                        where proSer.ProviderId == entity.ProviderId && proSer.ServiceId == entity.ServiceId
                        select proSer).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderServices.Remove(data);
            }
            else
            { throw new Exception("Service does not exist."); }
        }
    }
}
