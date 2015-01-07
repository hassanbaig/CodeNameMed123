using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using CareHub.Factory.Factories;
using CareHub.UnitOfWork.Base;
using CareHub.DomainModel.Models;
using CareHub.Repository.RepositoryClasses;
using CareHub.Core.Common;
namespace CareHub.UnitOfWork
{
    public class StaffUOW : BaseUnitOfWork,IUnitOfWork
    {
        private Staff staff;       
        private ProviderRepository providerRepository;        
        private Provider provider = null;        
        public StaffUOW ():base()
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
        public StaffUOW(shiner49_medicareEntities context)
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
            providerRepository = (ProviderRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderRepository));
            
            providerRepository.DataContext = base.Context;
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
             staff = (Staff)domainModel;
             try
             {
                 switch (staff.OperationType)
                 {                    
                     case 17:                                                
                        providerRepository.Delete(staff.RemoveProviderId);
                         break;
                     default:
                         break;
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }     
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
             staff = (Staff)domainModel;
             List<CareHub.DataModel.Models.Provider> practiceDoctors = null;
             List<CareHub.DataModel.Models.Provider> practiceStaff = null;

             switch (staff.OperationType)
             {
                 case 11:
                     practiceDoctors = providerRepository.GetAllDoctorsByProviderPractice();
                     if (practiceDoctors != null)
                     {
                         staff.PracticeDoctors = practiceDoctors;
                     }
                     else
                     {
                         throw new Exception("Doctors not found");
                     }
                     break;
                 case 12:
                     practiceStaff = providerRepository.GetAllStaffByProviderPractice();
                     if (practiceStaff != null)
                     {
                         staff.PracticeStaff = practiceStaff;
                     }
                     else
                     {
                         throw new Exception("Doctors not found");
                     }
                     break;
                 default:
                     break;
             }
             return staff;
         }
         public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
         {
             throw new NotImplementedException();                  
         }
    }
}