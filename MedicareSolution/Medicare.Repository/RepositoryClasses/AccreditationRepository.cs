using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class AccreditationRepository : IRepository
    {
        public AccreditationRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public List<Medicare.DataModel.Models.Accreditation> Save(Accreditation entity)
        {

            var data = (from acc in _context.Accreditations
                        where acc.Title == entity.Title
                        select acc).FirstOrDefault();
            if (data == null)
            {
                _context.Accreditations.Add(entity);
                _context.SaveChanges();

                var accreditations = (from acc in _context.Accreditations
                                      select new Medicare.DataModel.Models.Accreditation
                                      {
                                          Description = acc.Description,
                                          AccreditationId = acc.AccreditationId,
                                          Title = acc.Title

                                      }).ToList();

                return accreditations;
            }
            else
            { throw new Exception("Accreditations already exist."); }            
        }   
        public List<Medicare.DataModel.Models.Accreditation> GetAll()
        {
            var data = (from acc in _context.Accreditations
                        select new Medicare.DataModel.Models.Accreditation
                        {
                            Description = acc.Description,
                            AccreditationId = acc.AccreditationId,
                            Title = acc.Title
                        }).ToList();

            return data;
        }     
    }
}
