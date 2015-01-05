using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class AffiliationRepository : IRepository
    {
        public AffiliationRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }      
        public List<CareHub.DataModel.Models.Affiliation> GetAll()
        {
            var data = (from aff in _context.Affiliations
                        select new CareHub.DataModel.Models.Affiliation 
                        {
                            AffiliationId = aff.AffiliationId,
                            Name = aff.Name
                        }).ToList();
            return data;
        }
    }
}
