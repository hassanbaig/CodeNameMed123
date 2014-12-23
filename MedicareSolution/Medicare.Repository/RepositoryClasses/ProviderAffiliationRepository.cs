using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderAffiliationRepository : IRepository
    {
        public ProviderAffiliationRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderAffiliationRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void Delete(ProviderAffiliation entity)
        {
            var data = (from proAff in _context.ProviderAffiliations
                        where proAff.ProviderId == entity.ProviderId && proAff.AffiliationId == entity.AffiliationId
                        select proAff).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderAffiliations.Remove(data);
            }
            else
            { throw new Exception("Affiliation does not exist."); }
        }
        public void AddProviderAffiliation(ProviderAffiliation entity)
        {
            var affiliation = (from proAff in _context.ProviderAffiliations
                               join aff in _context.Affiliations on proAff.AffiliationId equals aff.AffiliationId
                               where proAff.ProviderId == entity.ProviderId && aff.AffiliationId == entity.AffiliationId
                               select proAff).FirstOrDefault();
            if (affiliation == null)
            {
                _context.ProviderAffiliations.Add(entity);
            }
            else
            { throw new Exception("Affiliation already added"); }
        }      
        public List<Medicare.DataModel.Models.ProviderAffiliation> GetProviderAffiliations(long providerId)
        {
            var data = (from proAff in _context.ProviderAffiliations
                        join aff in _context.Affiliations on proAff.AffiliationId equals aff.AffiliationId
                        where proAff.ProviderId == providerId
                        select new Medicare.DataModel.Models.ProviderAffiliation
                        {
                            ProviderId = proAff.ProviderId,
                            ProviderAffiliationId = proAff.ProviderAffiliationId,
                            AffiliationId = aff.AffiliationId,
                            Name = aff.Name,
                            Description = aff.Description,
                            Year = proAff.Year                            
                        }).ToList();

            return data;
        }
    }
}
