using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderLanguagesRepository : IRepository
    {
        public ProviderLanguagesRepository()
        {

        }
        private shiner49_medicareEntities _context;
        public shiner49_medicareEntities DataContext
        {
            set { _context = value; }
        }
        public ProviderLanguagesRepository(shiner49_medicareEntities context)
        {
            _context = context;
        }
        public void AddProviderLanguages(ProviderLanguage entity)
        {
            var data = (from proLan in _context.ProviderLanguages
                        where proLan.ProviderId == entity.ProviderId && proLan.LanguageId == entity.LanguageId
                        select proLan).FirstOrDefault();

            if (data == null)
            { _context.ProviderLanguages.Add(entity); }
            else
            { throw new Exception("Language already added."); }
        }      
        public void Delete(ProviderLanguage entity)
        {
            var data = (from proLan in _context.ProviderLanguages
                        where proLan.ProviderId == entity.ProviderId && proLan.LanguageId == entity.LanguageId
                        select proLan).FirstOrDefault();

            if (data != null)
            {
                _context.ProviderLanguages.Remove(data);
            }
            else
            { throw new Exception("Language does not exist."); }
        }
    }
}
