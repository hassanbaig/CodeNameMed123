using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class AwardRepository : IRepository
    {
        public AwardRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }      
        public List<Medicare.DataModel.Models.Award> GetAll()
        {
            var data = (from awa in _context.Awards
                        select new Medicare.DataModel.Models.Award 
                        {
                            AwardId = awa.AwardId,
                            Name = awa.Name
                        }).ToList();
            return data;
        }
    }
}
