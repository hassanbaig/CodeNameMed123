using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class InsuranceRepository : IRepository
    {
        public InsuranceRepository()
        {

        }
        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }    
        public List<Medicare.DataModel.Models.Insurance> Save(Insurance entity)
        {

            var data = (from ins in _context.Insurances
                        where ins.Title == entity.Title
                        select ins).FirstOrDefault();
            if (data == null)
            {
                _context.Insurances.Add(entity);
                _context.SaveChanges();

                var insurances = (from ins in _context.Insurances
                                  select new Medicare.DataModel.Models.Insurance
                                  {
                                      Description = ins.Description,
                                      InsuranceId = ins.InsuranceId,
                                      Title = ins.Title

                                  }).ToList();

                return insurances;
            }
            else
            { throw new Exception("Insurance already exist"); }
        }         
        public List<Medicare.DataModel.Models.Insurance> GetAll()
        {
            var data = (from ins in _context.Insurances
                        select new Medicare.DataModel.Models.Insurance
                        {
                            Description = ins.Description,
                            InsuranceId = ins.InsuranceId,
                            Title = ins.Title
                        }).ToList();

            return data;
        }     
    }
}
