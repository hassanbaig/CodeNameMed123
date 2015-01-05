using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class CollegeRepository : IRepository
    {
        public CollegeRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }
        public CollegeRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public List<CareHub.DataModel.Models.College> GetAll()
        {
            var colleges = (from col in _context.Colleges
                             select new CareHub.DataModel.Models.College
                             {
                                 CollegeId = col.CollegeId,
                                 Name = col.Name,
                                 CreationDate = col.CreationDate
                             }).ToList();
            return colleges;
        }
    }
}
