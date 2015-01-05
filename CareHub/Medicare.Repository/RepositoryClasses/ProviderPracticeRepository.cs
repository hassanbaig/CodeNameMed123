using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;

namespace CareHub.Repository.RepositoryClasses
{
    public class ProviderPracticeRepository : IRepository
    {
        public ProviderPracticeRepository()
        {

        }
       private shiner49_CareHubEntities _context;
        public shiner49_CareHubEntities DataContext
        {
            set { _context = value; }
        }

        public ProviderPracticeRepository(shiner49_CareHubEntities context)
        {
            _context = context;
        }
        public void Save(ProviderPractice entity)
        {
            _context.ProviderPractices.Add(entity);
        }
    }
}
