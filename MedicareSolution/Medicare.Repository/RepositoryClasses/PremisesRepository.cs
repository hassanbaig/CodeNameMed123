using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class PremisesRepository : IRepository
    {
        public PremisesRepository()
        {

        }
        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }      
        public List<Medicare.DataModel.Models.Premises> Save(Premis entity)
        {

            var data = (from pre in _context.Premises
                        where pre.Name == entity.Name
                        select pre).FirstOrDefault();
            if (data == null)
            {
                _context.Premises.Add(entity);
                _context.SaveChanges();

                var premises = (from pre in _context.Premises
                                select new Medicare.DataModel.Models.Premises
                                {
                                    Description = pre.Description,
                                    PremisesId = pre.PremisesId,
                                    Name = pre.Name
                                }).ToList();

                return premises;
            }
            else
            { throw new Exception("Premises already exist"); }
        }         
        public List<Medicare.DataModel.Models.Premises> GetAll()
        {
            var data = (from pre in _context.Premises
                        select new Medicare.DataModel.Models.Premises
                        {
                            Description = pre.Description,
                            PremisesId = pre.PremisesId,
                            Name = pre.Name
                        }).ToList();

            return data;
        }
    }
}
