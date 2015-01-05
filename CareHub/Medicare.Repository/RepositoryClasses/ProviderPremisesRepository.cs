using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderPremisesRepository : IRepository
    {
        public ProviderPremisesRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderPremisesRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public void AddProviderPremises(ProviderPremis entity)
        {
            var data = (from proPre in _context.ProviderPremises
                        where proPre.ProviderId == entity.ProviderId && proPre.PremisesId == entity.PremisesId
                        select proPre).FirstOrDefault();

            if (data == null)
            { _context.ProviderPremises.Add(entity); }
            else
            { throw new Exception("Premises already added."); }
        }
        public void Delete(ProviderPremis entity)
        {
            var data = (from proPre in _context.ProviderPremises
                        where proPre.ProviderId == entity.ProviderId && proPre.PremisesId == entity.PremisesId
                        select proPre).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderPremises.Remove(data);
            }
            else
            { throw new Exception("Premises does not exist."); }
        }
    }
}
