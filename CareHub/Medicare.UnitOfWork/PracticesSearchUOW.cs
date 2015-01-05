using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Data;
using CareHub.Factory.Factories;
using CareHub.UnitOfWork.Base;
using CareHub.DomainModel.Models;
using CareHub.Repository.RepositoryClasses;
using CareHub.Core.Common;
namespace CareHub.UnitOfWork
{
    public class PracticesSearchUOW : BaseUnitOfWork,IUnitOfWork
    {                 
        private PracticeRepository practiceRepository;        
        private PracticesSearch searchPractice;
        public PracticesSearchUOW ():base()
	    {            
            if (base.Context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            else
            {
                ((IUnitOfWork)this).InitializeRepositories();
            }
        }
        public PracticesSearchUOW(shiner49_CareHubEntities context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            else
            {
                ((IUnitOfWork)this).InitializeRepositories();
            }
        } 

        void IUnitOfWork.InitializeRepositories()
        {              
            practiceRepository = (PracticeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(PracticeRepository));
                      
            practiceRepository.DataContext = base.Context;            
        }
      
        
         void IUnitOfWork.Save(AbstractDomainModel domainModel)
         {
             throw new NotImplementedException();             
         }

         void IUnitOfWork.SaveAll()
         {
             throw new NotImplementedException();
         }

         void IUnitOfWork.Delete(AbstractDomainModel domainModel)
         {
             throw new NotImplementedException();
         }

         void IUnitOfWork.Update(AbstractDomainModel domainModel)
         {
             throw new NotImplementedException();
         }

         void IUnitOfWork.Commit()
         {
             base.Commit(); 
         }

         void IUnitOfWork.Add(AbstractDomainModel domainModel)
         {
             base.Add(domainModel);
         }

         void IUnitOfWork.Remove(AbstractDomainModel domainModel)
         {
             base.Remove(domainModel);
         }


         public AbstractDomainModel Get(AbstractDomainModel domainModel)
         {
             searchPractice = (DomainModel.Models.PracticesSearch)domainModel;
             switch (searchPractice.SearchType)
             {                 
                 case 1:
                     searchPractice.Practices = practiceRepository.GetPracticeByHospital(searchPractice.City, searchPractice.Hospital);
                     break;
                 case 2:
                     searchPractice.Practices = practiceRepository.GetPracticeByHospitalLocality(searchPractice.City, searchPractice.Hospital, searchPractice.Locality);
                     break;
                 case 3:
                     searchPractice.Practices = practiceRepository.GetPracticeByLab(searchPractice.City, searchPractice.Lab);
                     break;
                 case 4:
                     searchPractice.Practices = practiceRepository.GetPracticeByLabLocality(searchPractice.City, searchPractice.Lab, searchPractice.Locality);
                     break;
                 
                 default:
                     break;
             }

             return searchPractice; 
         }
         public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
         {
             searchPractice = new DomainModel.Models.PracticesSearch();
             switch (searchCriteria)
             {                
                 case Core.Enumerations.SearchCriteriaEnum.GET_HOSPITALS:
                     searchPractice.Hospitals = practiceRepository.GetAllHospitals();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_LABS:
                     searchPractice.Labs = practiceRepository.GetAllLabs();
                     break;                 
                 default:
                     break;
             }

             return searchPractice; 
         }
    }
}