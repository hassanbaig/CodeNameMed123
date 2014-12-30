using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class StateRepository : IRepository
    {
        public StateRepository()
        {

        }

        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }      
        public List<Medicare.DataModel.Models.State> GetAll()
        {
            var data = (from sta in _context.States
                        select new Medicare.DataModel.Models.State
                        {
                            CountryId = sta.CountryId,
                            StateId = sta.StateId,
                            Name = sta.Name
                        }).ToList();
            return data;
        }
    }
}
