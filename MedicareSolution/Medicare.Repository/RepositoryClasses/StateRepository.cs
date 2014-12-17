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

        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
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
