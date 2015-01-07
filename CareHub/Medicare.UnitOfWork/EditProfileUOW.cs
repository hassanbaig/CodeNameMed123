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
    public class EditProfileUOW : BaseUnitOfWork,IUnitOfWork
    {
        private EditProfile editProfile;                
        private ProviderRepository providerRepository;       
        private CountryRepository countryRepository;
        private StateRepository stateRepository;
        private CityRepository cityRepository;
        private LocalityRepository localityRepository;
        public EditProfileUOW ():base()
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
        public EditProfileUOW(shiner49_medicareEntities context)
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
            stateRepository = (StateRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(StateRepository));            
            countryRepository = (CountryRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CountryRepository));
            cityRepository = (CityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CityRepository));
            localityRepository = (LocalityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(LocalityRepository));
            
            providerRepository.DataContext = base.Context;
            stateRepository.DataContext = base.Context;
            countryRepository.DataContext = base.Context;
            cityRepository.DataContext = base.Context;
            localityRepository.DataContext = base.Context;            
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
                 editProfile = (EditProfile)domainModel;
                 //string[] fullName = editProfile.FullName.Split(' ');
                 //string firstName = fullName[0];
                 //string lastName = string.Empty;
                 //for (int i = 1; i < fullName.Length; i++)
                 //{
                 //    if (i > 1)
                 //    { lastName += " "; }
                 //    else { lastName += fullName[i]; }
                 //}
                 Provider provider = new Provider();
                 provider.UserId = editProfile.UserId;
                 provider.ProviderId = editProfile.ProviderId;
                 provider.FirstName = editProfile.FirstName;
                 provider.LastName = editProfile.LastName;                 
                 provider.GenderId = editProfile.Gender;
                 provider.TimeZone = editProfile.TimeZone;
                 provider.MobileNumber = editProfile.MobileNumber;
                 //provider.CountryId = editProfile.CountryId;
                 //provider.CityId = editProfile.CityId;
                 //provider.LocalityId = editProfile.LocalityId;
                 provider.ZipCode = editProfile.ZipCode;

                 providerRepository.Update(provider);
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
             DomainModel.Models.EditProfile editProfile = (DomainModel.Models.EditProfile)domainModel;
             CareHub.DataModel.Models.Provider provider = new CareHub.DataModel.Models.Provider(); 
             provider = providerRepository.GetProviderByUserId(editProfile.UserId);
             editProfile.ProviderId = provider.ProviderId;
             editProfile.FirstName = provider.FirstName;
             editProfile.LastName = provider.LastName;
             editProfile.Gender = provider.GenderId;
             editProfile.Email = provider.Email;
             //editProfile.CountryName = countryRepository.GetNameById(provider.CountryId)
             editProfile.TimeZone = provider.TimeZone;
             editProfile.MobileNumber = provider.MobileNumber;
             //editProfile.CountryId = provider.CountryId;
             //editProfile.CityId = provider.CityId;
             //editProfile.LocalityId = provider.LocalityId;
             editProfile.ZipCode = provider.ZipCode;

             return editProfile; 
         }

         public AbstractDomainModel GetAll(SearchCriteriaEnum searchCriteria)
         {
             DomainModel.Models.EditProfile editProfile = new DomainModel.Models.EditProfile();
             
             switch (searchCriteria)
             {                 
                 case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES:
                     editProfile.Countries = countryRepository.GetAll();
                     break;
                 case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_STATES:
                     editProfile.States = stateRepository.GetAll();
                     break;
                 case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_CITIES:
                     editProfile.Cities = cityRepository.GetAll();
                     break;
                 case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_LOCALITIES:
                     editProfile.Localities = localityRepository.GetAll();
                     break;
                 default:
                     break;
             }
             return editProfile;
         }
    }
}