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
using CareHub.Core.Enumerations;
namespace CareHub.UnitOfWork
{
    public class ForgotPasswordUOW : BaseUnitOfWork,IUnitOfWork
    {        
        private UserRepository userRepository;
        private ForgotPassword forgotPassword;        
        public ForgotPasswordUOW ():base()
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
        public ForgotPasswordUOW(shiner49_medicareEntities context)
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
            userRepository = (UserRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(UserRepository));            
            userRepository.DataContext = base.Context;            
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
             try
             {
                 forgotPassword = (ForgotPassword)domainModel;
                 userRepository.Update(forgotPassword.UserId, CareHub.Core.Common.Encryption.Encrypt("#", forgotPassword.NewPassword));                 
             }
             catch (Exception ex)
             {
                 throw ex;
             }
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
             throw new NotImplementedException();
         }

         public AbstractDomainModel GetAll(SearchCriteriaEnum searchCriteria)
         {
             throw new NotImplementedException();
         }
    }
}