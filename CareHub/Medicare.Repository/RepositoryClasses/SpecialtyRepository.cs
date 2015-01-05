using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class SpecialtyRepository : IRepository
    {
        public SpecialtyRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }      
        public List<CareHub.DataModel.Models.Specialty> Save(Specialty entity)
        {

            var data = (from spe in _context.Specialties
                        where spe.Title == entity.Title
                        select spe).FirstOrDefault();
            if (data == null)
            {
                _context.Specialties.Add(entity);
                _context.SaveChanges();

                var specializations = (from spe in _context.Specialties
                                       select new CareHub.DataModel.Models.Specialty
                                       {
                                           Description = spe.Description,
                                           SpecialtyId = spe.SpecialtyId,
                                           Title = spe.Title
                                       }).ToList();

                return specializations;
            }
            else
            { throw new Exception("Specialty already exist"); }
        }  
        public List<CareHub.DataModel.Models.Specialty> GetAll()
        {
            var data = (from spe in _context.Specialties
                        select new CareHub.DataModel.Models.Specialty {
                            Description = spe.Description,
                            SpecialtyId = spe.SpecialtyId,
                            Title = spe.Title
                        }).ToList();

            return data;
        }
    }
}
