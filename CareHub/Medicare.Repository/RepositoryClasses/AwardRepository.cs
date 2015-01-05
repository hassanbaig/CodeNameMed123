using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class AwardRepository : IRepository
    {
        public AwardRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }      
        public List<CareHub.DataModel.Models.Award> GetAll()
        {
            var data = (from awa in _context.Awards
                        select new CareHub.DataModel.Models.Award 
                        {
                            AwardId = awa.AwardId,
                            Name = awa.Name
                        }).ToList();
            return data;
        }
    }
}
