using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class CollegeRepository : IRepository
    {
        public CollegeRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }
        public CollegeRepository(MedicareDevEntities context)
        {
            _context = context;
        }
        public List<Medicare.DataModel.Models.College> GetAll()
        {
            var colleges = (from col in _context.Colleges
                             select new Medicare.DataModel.Models.College
                             {
                                 CollegeId = col.CollegeId,
                                 Name = col.Name,
                                 CreationDate = col.CreationDate
                             }).ToList();
            return colleges;
        }
    }
}
