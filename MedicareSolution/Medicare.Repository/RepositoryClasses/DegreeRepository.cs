using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class DegreeRepository : IRepository
    {
        public DegreeRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }

        public DegreeRepository(MedicareDevEntities context)
        {
            _context = context;
        }     
        public List<Medicare.DataModel.Models.Degree> GetAll()
        {
            var degrees = (from deg in _context.Degrees
                             select new Medicare.DataModel.Models.Degree
                             {
                                 DegreeId = deg.DegreeId,
                                 Title = deg.Title,
                                 Description = deg.Description
                             }).ToList();
            return degrees;
        }
    }
}
