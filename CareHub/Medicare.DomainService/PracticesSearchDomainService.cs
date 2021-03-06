﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.UnitOfWork.Base;
using CareHub.Factory.Factories;
using CareHub.UnitOfWork;
using CareHub.Core.Enumerations;
namespace CareHub.DomainService
{
    public class PracticesSearchDomainService : AbstractDomainService
    {
        
        private IUnitOfWork unitOfWork;
        public override AbstractDomainModel Save(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Update(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Delete(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Query(AbstractDomainModel domainModel, CareHub.Factory.Enumerations.DomainModelEnum domainModelType)
        {
            DomainModel.Models.PracticesSearch searchPractice = (DomainModel.Models.PracticesSearch)domainModel;
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.PRACTICE_SEARCH:
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.PracticesSearchUOW));
                            searchPractice = (DomainModel.Models.PracticesSearch)unitOfWork.Get(searchPractice);
                            searchPractice.ResponseMessage = "Valid domain model";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.PRACTICE_SEARCH:
                            searchPractice.ResponseMessage = "Invalid domain model";
                            break;
                        default:
                            break;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                switch (domainModelType)
                {
                    case CareHub.Factory.Enumerations.DomainModelEnum.PRACTICE_SEARCH:
                        searchPractice.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
                
            }
            switch (domainModelType)
            {
                case CareHub.Factory.Enumerations.DomainModelEnum.PRACTICE_SEARCH:
                    return searchPractice;
                default:
                    break;
            }

            return null;
        }

        public override AbstractDomainModel Query(AbstractDomainModel domainModel, Factory.Enumerations.DomainModelEnum domainModelType, SearchCriteriaEnum searchCriteria)
        {
            throw new NotImplementedException();
        }

        public override AbstractDomainModel Query(SearchCriteriaEnum searchCriteria)
        {
            DomainModel.Models.PracticesSearch searchPractice = new DomainModel.Models.PracticesSearch();

            FactoryFacade factory = new FactoryFacade();
            try
            {
                switch (searchCriteria)
                {                    
                    case SearchCriteriaEnum.GET_HOSPITALS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.PracticesSearchUOW));
                        searchPractice = (DomainModel.Models.PracticesSearch)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_LABS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.PracticesSearchUOW));
                        searchPractice = (DomainModel.Models.PracticesSearch)unitOfWork.GetAll(searchCriteria);
                        break;                 
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_HOSPITALS:
                        searchPractice.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_LABS:
                        searchPractice.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                factory = null;
            }
            switch (searchCriteria)
            {
                case SearchCriteriaEnum.GET_HOSPITALS:
                    return searchPractice;
                case SearchCriteriaEnum.GET_LABS:
                    return searchPractice;
                default:
                    break;
            }
            return null;          
        }
    }
}
