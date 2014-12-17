using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;

namespace Medicare.Repository.RepositoryClasses
{
    public class ProviderPracticeRepository : IRepository
    {
        public ProviderPracticeRepository()
        {

        }
       private MedicareDevEntities _context;
        public MedicareDevEntities DataContext
        {
            set { _context = value; }
        }

        public ProviderPracticeRepository(MedicareDevEntities context)
        {
            _context = context;
        }
        public void Save(ProviderPractice entity)
        {
            _context.ProviderPractices.Add(entity);
        }
    }
}
