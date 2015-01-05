using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class DegreeRepository : IRepository
    {
        public DegreeRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }

        public DegreeRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }     
        public List<CareHub.DataModel.Models.Degree> GetAll()
        {
            var degrees = (from deg in _context.Degrees
                             select new CareHub.DataModel.Models.Degree
                             {
                                 DegreeId = deg.DegreeId,
                                 Title = deg.Title,
                                 Description = deg.Description
                             }).ToList();
            return degrees;
        }
    }
}
