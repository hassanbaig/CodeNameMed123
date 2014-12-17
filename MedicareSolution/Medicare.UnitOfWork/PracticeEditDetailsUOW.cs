using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Data;
using Medicare.Factory.Factories;
using Medicare.UnitOfWork.Base;
using Medicare.DomainModel.Models;
using Medicare.Repository.RepositoryClasses;
using Medicare.Core.Common;
namespace Medicare.UnitOfWork
{
    public class PracticeEditDetailsUOW : BaseUnitOfWork,IUnitOfWork
    {
        private PracticeEditDetails practiceEditDetails;
        private CountryRepository countryRepository;
        private PracticeRepository practiceRepository;
        private ProviderPracticeRepository providerPracticeRepository;
        private LanguageRepository languageRepository;
        private ProviderLanguagesRepository providerLanguagesRepository;
        private ProviderRepository providerRepository;
       private PremisesRepository premisRepository;
       private ProviderPremisesRepository providerPremisesRepository;               
       private AccreditationRepository accreditationRepository;
       private ProviderAccreditationsRepository providerAccreditationsRepository;
       private InsuranceRepository insuranceRepository;
       private ProviderInsurancesRepository  providerInsurancesRepository;
        private ServiceRepository serviceRepository;
       private ProviderServicesRepository providerServicesRepository;

         private ProviderLanguage providerLanguage = null;
         private ProviderPremis providerPremis = null;
         private ProviderAccreditation providerAccreditation = null;
         private ProviderInsurance providerInsurance = null;
         private ProviderService providerService = null;
         private ProviderService providerTravelService = null;
        public PracticeEditDetailsUOW ():base()
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
        public PracticeEditDetailsUOW(MedicareDevEntities context)
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
            countryRepository = (CountryRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CountryRepository));
            practiceRepository = (PracticeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(PracticeRepository));
            providerPracticeRepository = (ProviderPracticeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderPracticeRepository));
            languageRepository = (LanguageRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(LanguageRepository));
            premisRepository = (PremisesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(PremisesRepository));
            accreditationRepository = (AccreditationRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(AccreditationRepository));
            insuranceRepository = (InsuranceRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(InsuranceRepository));
            serviceRepository = (ServiceRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ServiceRepository));
            providerServicesRepository = (ProviderServicesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderServicesRepository));
            providerAccreditationsRepository = (ProviderAccreditationsRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderAccreditationsRepository));
            providerLanguagesRepository = (ProviderLanguagesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderLanguagesRepository));
            providerPremisesRepository = (ProviderPremisesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderPremisesRepository));
            providerInsurancesRepository = (ProviderInsurancesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderInsurancesRepository));
            providerLanguagesRepository.DataContext = base.Context;
            providerPremisesRepository.DataContext = base.Context;
            providerRepository.DataContext = base.Context;
            practiceRepository.DataContext = base.Context;
            countryRepository.DataContext = base.Context;
            providerPracticeRepository.DataContext = base.Context;
            languageRepository.DataContext = base.Context;
            premisRepository.DataContext = base.Context;
           accreditationRepository.DataContext = base.Context;
            providerAccreditationsRepository.DataContext = base.Context;
            insuranceRepository.DataContext = base.Context;
            providerInsurancesRepository.DataContext = base.Context;
            serviceRepository.DataContext = base.Context;
            providerServicesRepository.DataContext = base.Context;
        }       
         void IUnitOfWork.Save(AbstractDomainModel domainModel)
         {
             practiceEditDetails = (PracticeEditDetails)domainModel;
             try
             {
                 switch (practiceEditDetails.OperationType)
                 {
                     case 1:
                         ProviderPractice poviderPractice = new ProviderPractice();
                         Practice practice = new Practice();

                         practice.Name = practiceEditDetails.PracticeDetailsPracticeName;
                         practice.CountryId = 1;
                         practice.CityId = 1;
                         practice.StateId = 1;
                         practice.LocalityId = 1;
                         practice.CreationDate = DateTime.Now;
                         practice.LogoPath = practiceEditDetails.PracticeDetailsLogoPath;
                         practice.TagLine = practiceEditDetails.PracticeDetailsPracticeTagline;
                         practice.Description = practiceEditDetails.PracticeDetailsPracticeDescription;
                         practice.BillingCurrencyId = practiceEditDetails.PracticeDetailsBillingCurrency;
                         practice.PracticeTypeId = practiceEditDetails.PracticeDetailsPracticeType;

                         poviderPractice = new ProviderPractice();
                         poviderPractice.ProviderId = practiceEditDetails.ProviderId;
                         poviderPractice.Practice = practice;

                         practiceRepository.Save(practice);
                         providerPracticeRepository.Save(poviderPractice);
                         break;
                     case 7:
                         Language language = new Language();
                         language.Name = practiceEditDetails.PracticeLanguagesLanguageName;

                         practiceEditDetails.Languages = languageRepository.Save(language);
                         break;

                     case 9:
                         Premis Premis = new Premis();
                         Premis.Name = practiceEditDetails.PracticePremisesPremisName;

                         practiceEditDetails.Premises = premisRepository.Save(Premis);
                         break;

                     case 12:
                         Accreditation Accreditation = new Accreditation();
                         Accreditation.Title = practiceEditDetails.PracticeAccreditationsAccreditationName;

                         practiceEditDetails.Accreditations = accreditationRepository.Save(Accreditation);
                         break;

                     case 13:
                         Insurance Insurance = new Insurance();
                         Insurance.Title = practiceEditDetails.PracticeInsurancesInsuranceName;

                         practiceEditDetails.Insurances = insuranceRepository.Save(Insurance);
                         break;

                     case 14:
                         Service Service = new Service();
                         Service.Title = practiceEditDetails.PracticeServicesServiceName;
                         Service.ServiceTypeId = practiceEditDetails.PracticeServicesServiceTypeId;
                         practiceEditDetails.Services = serviceRepository.Save(Service);
                         break;
                     case 15:
                         Service TravelService = new Service();
                         TravelService.Title = practiceEditDetails.PracticeServicesTravelServiceName;
                         TravelService.ServiceTypeId = practiceEditDetails.PracticeServicesServiceTypeId;

                         practiceEditDetails.TravelServices = serviceRepository.Save(TravelService);
                         break;

                     default:
                         break;
                 }
                  practiceEditDetails = (PracticeEditDetails)domainModel;
                 
             }
             catch (Exception ex)
             {
                 throw ex;
             }        
         }

         void IUnitOfWork.SaveAll()
         {
             throw new NotImplementedException();
         }

         void IUnitOfWork.Delete(AbstractDomainModel domainModel)
         {
            // throw new NotImplementedException();

             practiceEditDetails = (PracticeEditDetails)domainModel;
             try
             {
                 switch (practiceEditDetails.OperationType)
                 {
                     
                     case 8:
                         ProviderLanguage providerLanguage = new ProviderLanguage();
                         providerLanguage.LanguageId = practiceEditDetails.PracticeLanguagesLanguageId;
                         providerLanguage.ProviderId = practiceEditDetails.ProviderId;
                         providerLanguagesRepository.Delete(providerLanguage);
                         break;
                     case 10:
                         ProviderPremis providerPremis = new ProviderPremis();
                         providerPremis.PremisesId = practiceEditDetails.PracticePremisesPremisId;
                         providerPremis.ProviderId = practiceEditDetails.ProviderId;
                         providerPremisesRepository.Delete(providerPremis);           
                         break;

                     case 12:
                         ProviderAccreditation providerAcceridation = new ProviderAccreditation();
                         providerAcceridation.AccreditationId = practiceEditDetails.PracticeAccreditationsAccreditationId;
                         providerAcceridation.ProviderId = practiceEditDetails.ProviderId;
                         providerAccreditationsRepository.Delete(providerAcceridation);
                         break;

                     case 14:
                         ProviderInsurance providerInsurance = new ProviderInsurance();
                         providerInsurance.InsuranceId = practiceEditDetails.PracticeInsurancesInsuranceId;
                         providerInsurance.ProviderId = practiceEditDetails.ProviderId;
                         providerInsurancesRepository.Delete(providerInsurance);
                         break;
                     case 15:
                         ProviderService providerServices = new ProviderService();
                         providerServices.ServiceId = practiceEditDetails.PracticeServicesServiceId;
                         providerServices.ProviderId = practiceEditDetails.ProviderId;
                         providerServicesRepository.Delete(providerServices);
                         break;
                     case 16:
                         ProviderService providerTravelService = new ProviderService();
                         providerTravelService.ServiceId = practiceEditDetails.PracticeServicesTravelServiceId;
                         providerTravelService.ProviderId = practiceEditDetails.ProviderId;
                         providerServicesRepository.Delete(providerTravelService);
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
             practiceEditDetails = (PracticeEditDetails)domainModel;
             try
             {
                 switch (practiceEditDetails.OperationType)
                 {
                     case 8:
                         providerLanguage = new ProviderLanguage();
                         providerLanguage.ProviderId = practiceEditDetails.ProviderId;
                         providerLanguage.LanguageId = practiceEditDetails.PracticeLanguagesLanguageId;

                         providerLanguagesRepository.AddProviderLanguages(providerLanguage);
                         break;

                     case 9:
                         
                        providerPremis = new ProviderPremis();
                         providerPremis.ProviderId = practiceEditDetails.ProviderId;
                         providerPremis.PremisesId = practiceEditDetails.PracticePremisesPremisId;

                         providerPremisesRepository.AddProviderPremises(providerPremis);
                         break;

                     case 10:

                         providerAccreditation = new ProviderAccreditation();
                         providerAccreditation.ProviderId = practiceEditDetails.ProviderId;
                         providerAccreditation.AccreditationId = practiceEditDetails.PracticeAccreditationsAccreditationId;

                         providerAccreditationsRepository.AddProviderAccreditations(providerAccreditation);
                         break;
                     case 11:

                         providerInsurance = new ProviderInsurance();
                         providerInsurance.ProviderId = practiceEditDetails.ProviderId;
                         providerInsurance.InsuranceId = practiceEditDetails.PracticeInsurancesInsuranceId;

                         providerInsurancesRepository.AddProviderInsurances(providerInsurance);
                         break;

                     case 12:

                         providerService = new ProviderService();
                         providerService.ProviderId = practiceEditDetails.ProviderId;
                         providerService.ServiceId = practiceEditDetails.PracticeServicesServiceId;

                         providerServicesRepository.AddProviderService(providerService);
                         break;

                     case 13:

                         providerTravelService = new ProviderService();
                         providerTravelService.ProviderId = practiceEditDetails.ProviderId;
                         providerTravelService.ServiceId = practiceEditDetails.PracticeServicesTravelServiceId;

                         providerServicesRepository.AddProviderService(providerTravelService);
                         break;
                 }
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
             List<Medicare.DataModel.Models.Language> providerAddedLanguages = null;
             List<Medicare.DataModel.Models.Premises> providerAddedPremises = null;
             List<Medicare.DataModel.Models.Accreditation> providerAddedAccreditations = null;
             List<Medicare.DataModel.Models.Insurance>  providerAddedInsurances = null;
             List<Medicare.DataModel.Models.Service> providerAddedServices = null;
             List<Medicare.DataModel.Models.Service> providerAddedTravelServices = null;

             practiceEditDetails = (PracticeEditDetails)domainModel;
             switch(practiceEditDetails.OperationType)
             {
                 case 5:
                     providerAddedLanguages = providerRepository.GetAddedLanguages(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                 if (providerAddedLanguages != null)
                 {
                     practiceEditDetails.AddedLanguages = providerAddedLanguages;
                 }
                 else
                 {
                     throw new Exception("Languages not found");
                 }
                 return practiceEditDetails;

                 case 6:
                 providerAddedPremises =  providerRepository.GetAddedPremises(practiceEditDetails.UserId,practiceEditDetails.ProviderId);
                 if (providerAddedPremises != null)
                 {
                     practiceEditDetails.AddedPremises = providerAddedPremises;
                 }
                 else
                 {
                     throw new Exception(" Premises Languages not found");
                 }
                break;

                 case 7:

                providerAddedAccreditations = providerRepository.GetAddedAccreditations(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                if (providerAddedAccreditations != null)
                 {
                     practiceEditDetails.AddedAccreditations = providerAddedAccreditations;
                 }
                 else
                 {
                     throw new Exception("Accreditations Languages not found");
                 }

                 break;

                 case 8:
                 providerAddedInsurances = providerRepository.GetAddedInsurances(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                 if (providerAddedInsurances != null)
                 {
                     practiceEditDetails.AddedInsurances = providerAddedInsurances;
                 }
                 else
                 {
                     throw new Exception("Insurances Languages not found");
                 }

                 break;

                 case 9:
                 providerAddedServices = providerRepository.GetAddedServices(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                 if (providerAddedServices != null)
                 {
                     practiceEditDetails.AddedServices = providerAddedServices;
                 }
                 else
                 {
                     throw new Exception("Services Languages not found");
                 }

                 break;
                 case 10:
                 providerAddedTravelServices = providerRepository.GetAddedTravelServices(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                 if (providerAddedTravelServices != null)
                 {
                     practiceEditDetails.AddedTravelServices = providerAddedTravelServices;
                 }
                 else
                 {
                     throw new Exception("Services Languages not found");
                 }

                 break;
                 default:
                 break;
             }
             return practiceEditDetails;
         }    
         public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
         {
             practiceEditDetails = new DomainModel.Models.PracticeEditDetails();
             switch (searchCriteria)
             {
                 case Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES:
                     practiceEditDetails.Countries = countryRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES:
                     practiceEditDetails.Languages = languageRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_PREMISES:
                     practiceEditDetails.Premises = premisRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_ACCREDITATIONS:
                     practiceEditDetails.Accreditations = accreditationRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_INSURANCES:
                     practiceEditDetails.Insurances = insuranceRepository.GetAll();
                     break;

                 case Core.Enumerations.SearchCriteriaEnum.GET_SERVICES:
                     practiceEditDetails.Services = serviceRepository.GetAllServices();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_TRAVEL_SERVICES:
                     practiceEditDetails.TravelServices = serviceRepository.GetAllTravelServices();
                     break;


                 default:
                     break;
             }

             return practiceEditDetails; 
         }
    }
}