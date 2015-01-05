using System;
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
    public class DoctorsSearchDomainService : AbstractDomainService
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
            DomainModel.Models.DoctorsSearch searchDoctor = (DomainModel.Models.DoctorsSearch)domainModel;
            try
            {
                if (domainModel != null)
                {
                    FactoryFacade factory = new FactoryFacade();
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH:
                            unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                            searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.Get(searchDoctor);
                            searchDoctor.ResponseMessage = "Valid domain model";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (domainModelType)
                    {
                        case CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH:
                            searchDoctor.ResponseMessage = "Invalid domain model";
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
                    case CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    default:
                        break;
                }                
            }
            switch (domainModelType)
            {
                case CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH:
                    return searchDoctor;                    
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
            DomainModel.Models.DoctorsSearch searchDoctor = new DomainModel.Models.DoctorsSearch();

            FactoryFacade factory = new FactoryFacade();
            try
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_DOCTORS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;                    
                    case SearchCriteriaEnum.GET_PHARMACISTS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_NURSE:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;
                    case SearchCriteriaEnum.GET_TREATMENTS:
                        unitOfWork = factory.UnitOfWorkFactory.CreateUnitOfWork(typeof(CareHub.UnitOfWork.DoctorsSearchUOW));
                        searchDoctor = (DomainModel.Models.DoctorsSearch)unitOfWork.GetAll(searchCriteria);
                        break;  
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                switch (searchCriteria)
                {
                    case SearchCriteriaEnum.GET_COUNTRIES:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_SPECIALTIES:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_DOCTORS:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_PHARMACISTS:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_NURSE:
                        searchDoctor.ResponseMessage = ex.Message;
                        break;
                    case SearchCriteriaEnum.GET_TREATMENTS:
                        searchDoctor.ResponseMessage = ex.Message;
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
                case SearchCriteriaEnum.GET_COUNTRIES:
                    return searchDoctor;
                case SearchCriteriaEnum.GET_SPECIALTIES:
                    return searchDoctor;
                case SearchCriteriaEnum.GET_DOCTORS:
                    return searchDoctor;
                case SearchCriteriaEnum.GET_PHARMACISTS:
                    return searchDoctor;
                case SearchCriteriaEnum.GET_NURSE:
                    return searchDoctor;
                case SearchCriteriaEnum.GET_TREATMENTS:
                    return searchDoctor;
                default:
                    break;
            }
            return null;          
        }
    }
}
