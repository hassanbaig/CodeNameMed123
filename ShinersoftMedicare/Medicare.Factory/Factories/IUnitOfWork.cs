using Medicare.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.Factory.Factories
{
    
     public interface IUnitOfWork
    {
      void InitializeRepositories();
      AbstractDomainModel Get(AbstractDomainModel domainModel);
      AbstractDomainModel GetAll(SearchCriteriaEnum searchCriteria);
      void Save(AbstractDomainModel domainModel);
      void SaveAll();
      void Delete(AbstractDomainModel domainModel);
      void Update(AbstractDomainModel domainModel);

      void Commit();
      void Add(AbstractDomainModel domainModel);
      void Remove(AbstractDomainModel domainModel);
    }
}
