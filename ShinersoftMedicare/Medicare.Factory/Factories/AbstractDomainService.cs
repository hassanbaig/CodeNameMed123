using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Factory.Factories;
using Medicare.Core.Enumerations;
namespace Medicare.Factory.Factories
{
    public abstract class AbstractDomainService
    {
        public abstract AbstractDomainModel Save(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Update(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Delete(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Query(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Query(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType, Medicare.Core.Enumerations.SearchCriteriaEnum searchCriteria);
        //public abstract IQueryable<T> Query<T>(this IQueryable<T> domainModel,Medicare.Core.Enumerations.SearchCriteriaEnum searchCriteria);        
        public abstract AbstractDomainModel Query(Medicare.Core.Enumerations.SearchCriteriaEnum searchCriteria);        
    }
}