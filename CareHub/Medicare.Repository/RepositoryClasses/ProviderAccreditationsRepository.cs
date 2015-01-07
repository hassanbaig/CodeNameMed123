using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderAccreditationsRepository : IRepository
    {
        public ProviderAccreditationsRepository()
        {

        }
       private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderAccreditationsRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void AddProviderAccreditations(ProviderAccreditation entity)
        {
            var data = (from proAcc in _context.ProviderAccreditations
                        where proAcc.ProviderId == entity.ProviderId && proAcc.AccreditationId == entity.AccreditationId
                        select proAcc).FirstOrDefault();

            if (data == null)
            { _context.ProviderAccreditations.Add(entity); }
            else
            { throw new Exception("Accreditation already added."); }
        }
        public void Delete(ProviderAccreditation entity)
        {
            var data = (from proAcc in _context.ProviderAccreditations
                        where proAcc.ProviderId == entity.ProviderId && proAcc.AccreditationId == entity.AccreditationId
                        select proAcc).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderAccreditations.Remove(data);
            }
            else
            { throw new Exception("Accreditation does not exist."); }
        }
    }
}
