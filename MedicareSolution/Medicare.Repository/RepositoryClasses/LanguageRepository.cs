using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class LanguageRepository : IRepository
    {
        public LanguageRepository()
        {

        }
        private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }      
        public List<Medicare.DataModel.Models.Language> Save(Language entity)
        {        
            var data = (from lan in _context.Languages
                        where lan.Name == entity.Name
                        select lan).FirstOrDefault();
            if (data == null)
            {
                _context.Languages.Add(entity);
                _context.SaveChanges();

                var languages = (from lan in _context.Languages
                                 select new Medicare.DataModel.Models.Language
                                 {
                                     Description = lan.Description,
                                     LanguageId = lan.LanguageId,
                                     Name = lan.Name
                                 }).ToList();

                return languages;
            }
            else
            { throw new Exception("Language already exist"); }
        }         
        public List<Medicare.DataModel.Models.Language> GetAll()
        {
            var data = (from lan in _context.Languages
                        select new Medicare.DataModel.Models.Language
                        {
                            Description = lan.Description,
                            LanguageId = lan.LanguageId,
                            Name = lan.Name
                        }).ToList();

            return data;
        }
    }
}
