using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class SpecialtyRepository : IRepository
    {
        public SpecialtyRepository()
        {

        }
        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }      
        public List<Medicare.DataModel.Models.Specialty> Save(Specialty entity)
        {

            var data = (from spe in _context.Specialties
                        where spe.Title == entity.Title
                        select spe).FirstOrDefault();
            if (data == null)
            {
                _context.Specialties.Add(entity);
                _context.SaveChanges();

                var specializations = (from spe in _context.Specialties
                                       select new Medicare.DataModel.Models.Specialty
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
        public List<Medicare.DataModel.Models.Specialty> GetAll()
        {
            var data = (from spe in _context.Specialties
                        select new Medicare.DataModel.Models.Specialty {
                            Description = spe.Description,
                            SpecialtyId = spe.SpecialtyId,
                            Title = spe.Title
                        }).ToList();

            return data;
        }
    }
}
