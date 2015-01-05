using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class LanguageRepository : IRepository
    {
        public LanguageRepository()
        {

        }
        private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }      
        public List<CareHub.DataModel.Models.Language> Save(Language entity)
        {        
            var data = (from lan in _context.Languages
                        where lan.Name == entity.Name
                        select lan).FirstOrDefault();
            if (data == null)
            {
                _context.Languages.Add(entity);
                _context.SaveChanges();

                var languages = (from lan in _context.Languages
                                 select new CareHub.DataModel.Models.Language
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
        public List<CareHub.DataModel.Models.Language> GetAll()
        {
            var data = (from lan in _context.Languages
                        select new CareHub.DataModel.Models.Language
                        {
                            Description = lan.Description,
                            LanguageId = lan.LanguageId,
                            Name = lan.Name
                        }).ToList();

            return data;
        }
    }
}
