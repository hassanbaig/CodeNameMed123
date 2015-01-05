using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Factory.Factories;
using CareHub.Core.Enumerations;
namespace CareHub.Factory.Factories
{
    public abstract class AbstractDomainService
    {
        public abstract AbstractDomainModel Save(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Update(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Delete(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Query(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType);
        public abstract AbstractDomainModel Query(AbstractDomainModel domainModel, Enumerations.DomainModelEnum domainModelType, CareHub.Core.Enumerations.SearchCriteriaEnum searchCriteria);
        //public abstract IQueryable<T> Query<T>(this IQueryable<T> domainModel,CareHub.Core.Enumerations.SearchCriteriaEnum searchCriteria);        
        public abstract AbstractDomainModel Query(CareHub.Core.Enumerations.SearchCriteriaEnum searchCriteria);        
    }
}