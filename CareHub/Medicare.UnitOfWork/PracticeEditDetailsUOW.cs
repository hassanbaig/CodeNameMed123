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
    public class PracticeEditDetailsUOW : BaseUnitOfWork,IUnitOfWork
    {
        private PracticeEditDetails practiceEditDetails;
        private CountryRepository countryRepository;
        private BillingCurrencyRepository billingCurrencyRepository;
        private PracticeTypeRepository practiceTypeRepository;
        private PracticeRepository practiceRepository;
        private ProviderPracticeRepository providerPracticeRepository;
        private LanguageRepository languageRepository;
        private ProviderLanguagesRepository providerLanguagesRepository;
        private ProviderContactsRepository providerContactsRepository;
        private ProviderRepository providerRepository;
       private PremisesRepository premisRepository;
       private ProviderPremisesRepository providerPremisesRepository;               
       private AccreditationRepository accreditationRepository;
       private ProviderAccreditationsRepository providerAccreditationsRepository;
       private InsuranceRepository insuranceRepository;
       private ProviderInsurancesRepository  providerInsurancesRepository;
        private ServiceRepository serviceRepository;
       private ProviderServicesRepository providerServicesRepository;
       private ProviderTimingsRepository providerTimingsRepository;

         private ProviderLanguage providerLanguage = null;
         private ProviderPremis providerPremis = null;
         private ProviderAccreditation providerAccreditation = null;
         private ProviderInsurance providerInsurance = null;
         private ProviderService providerService = null;
         private ProviderService providerTravelService = null;
         private ProviderTiming providerTiming = null;
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
        public PracticeEditDetailsUOW(shiner49_CareHubEntities context)
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
            billingCurrencyRepository = (BillingCurrencyRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(BillingCurrencyRepository));
            practiceTypeRepository = (PracticeTypeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(PracticeTypeRepository));
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
            providerContactsRepository = (ProviderContactsRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderContactsRepository));
            providerPremisesRepository = (ProviderPremisesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderPremisesRepository));
            providerInsurancesRepository = (ProviderInsurancesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderInsurancesRepository));
            providerTimingsRepository = (ProviderTimingsRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderTimingsRepository));
            providerLanguagesRepository.DataContext = base.Context;
            providerContactsRepository.DataContext = base.Context;
            providerPremisesRepository.DataContext = base.Context;
            providerRepository.DataContext = base.Context;
            practiceRepository.DataContext = base.Context;
            countryRepository.DataContext = base.Context;
            billingCurrencyRepository.DataContext = base.Context;
            practiceTypeRepository.DataContext = base.Context;
            providerPracticeRepository.DataContext = base.Context;
            languageRepository.DataContext = base.Context;
            premisRepository.DataContext = base.Context;
            accreditationRepository.DataContext = base.Context;
            providerAccreditationsRepository.DataContext = base.Context;
            insuranceRepository.DataContext = base.Context;
            providerInsurancesRepository.DataContext = base.Context;
            serviceRepository.DataContext = base.Context;
            providerServicesRepository.DataContext = base.Context;
            providerTimingsRepository.DataContext = base.Context;
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
                         practice.TagLine = practiceEditDetails.PracticeDetailsTagline;
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

                     case 2:
                         ProviderContact providerContacts = new ProviderContact();
                         providerContacts.ProviderId = practiceEditDetails.ProviderId;
                         providerContacts.PrimaryPhone = practiceEditDetails.PracticeContactsPrimaryPhone;
                         providerContacts.PrimaryEmail = practiceEditDetails.PracticeContactsPrimaryEmail;
                         providerContacts.SecondaryPhone = practiceEditDetails.PracticeContactsSecondaryPhone;
                         providerContacts.SecondaryEmail = practiceEditDetails.PracticeContactsSecondaryEmail;
                         providerContacts.WebsiteAddress = practiceEditDetails.PracticeContactsWebsiteAddress;

                         providerContactsRepository.Update(providerContacts);
                         break;

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

                     case 14:
                      
                         if (practiceEditDetails.Monday == true)
                         {
                             providerTiming = new ProviderTiming();

                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Monday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.MonOpenHour1.ToLower() != "none" || practiceEditDetails.MonOpenHour1 != "" || practiceEditDetails.MonOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.MonOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.MonOpenMinute1.ToLower() != "none" || practiceEditDetails.MonOpenMinute1 != "" || practiceEditDetails.MonOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.MonOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.MonCloseHour1.ToLower() != "none" || practiceEditDetails.MonCloseHour1 != "" || practiceEditDetails.MonCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.MonCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.MonCloseMinute1.ToLower() != "none" || practiceEditDetails.MonCloseMinute1 != "" || practiceEditDetails.MonCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.MonCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.MonOpenHour2.ToLower() != "none" || practiceEditDetails.MonOpenHour2 != "" || practiceEditDetails.MonOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.MonOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.MonOpenMinute2.ToLower() != "none" || practiceEditDetails.MonOpenMinute2 != "" || practiceEditDetails.MonOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.MonOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.MonCloseHour2.ToLower() != "none" || practiceEditDetails.MonCloseHour2 != "" || practiceEditDetails.MonCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.MonCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.MonCloseMinute2.ToLower() != "none" || practiceEditDetails.MonCloseMinute2 != "" || practiceEditDetails.MonCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.MonCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                                                     
                         }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Monday"); }

                         if (practiceEditDetails.Tuesday == true)
                         {
                         
                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Tuesday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.TueOpenHour1.ToLower() != "none" || practiceEditDetails.TueOpenHour1 != "" || practiceEditDetails.TueOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.TueOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.TueOpenMinute1.ToLower() != "none" || practiceEditDetails.TueOpenMinute1 != "" || practiceEditDetails.TueOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.TueOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.TueCloseHour1.ToLower() != "none" || practiceEditDetails.TueCloseHour1 != "" || practiceEditDetails.TueCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.TueCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.TueCloseMinute1.ToLower() != "none" || practiceEditDetails.TueCloseMinute1 != "" || practiceEditDetails.TueCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.TueCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.TueOpenHour2.ToLower() != "none" || practiceEditDetails.TueOpenHour2 != "" || practiceEditDetails.TueOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.TueOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.TueOpenMinute2.ToLower() != "none" || practiceEditDetails.TueOpenMinute2 != "" || practiceEditDetails.TueOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.TueOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.TueCloseHour2.ToLower() != "none" || practiceEditDetails.TueCloseHour2 != "" || practiceEditDetails.TueCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.TueCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.TueCloseMinute2.ToLower() != "none" || practiceEditDetails.TueCloseMinute2 != "" || practiceEditDetails.TueCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.TueCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);                           
                         }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Tuesday"); }
                         if (practiceEditDetails.Wednesday == true)
                         {
                              providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Wednesday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.WedOpenHour1.ToLower() != "none" || practiceEditDetails.WedOpenHour1 != "" || practiceEditDetails.WedOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.WedOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.WedOpenMinute1.ToLower() != "none" || practiceEditDetails.WedOpenMinute1 != "" || practiceEditDetails.WedOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.WedOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.WedCloseHour1.ToLower() != "none" || practiceEditDetails.WedCloseHour1 != "" || practiceEditDetails.WedCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.WedCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.WedCloseMinute1.ToLower() != "none" || practiceEditDetails.WedCloseMinute1 != "" || practiceEditDetails.WedCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.WedCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.WedOpenHour2.ToLower() != "none" || practiceEditDetails.WedOpenHour2 != "" || practiceEditDetails.WedOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.WedOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.WedOpenMinute2.ToLower() != "none" || practiceEditDetails.WedOpenMinute2 != "" || practiceEditDetails.WedOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.WedOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.WedCloseHour2.ToLower() != "none" || practiceEditDetails.WedCloseHour2 != "" || practiceEditDetails.WedCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.WedCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.WedCloseMinute2.ToLower() != "none" || practiceEditDetails.WedCloseMinute2 != "" || practiceEditDetails.WedCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.WedCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                            }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Wednesday"); }
                         if (practiceEditDetails.Thursday == true)
                         {
                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Thursday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.ThuOpenHour1.ToLower() != "none" || practiceEditDetails.ThuOpenHour1 != "" || practiceEditDetails.ThuOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.ThuOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.ThuOpenMinute1.ToLower() != "none" || practiceEditDetails.ThuOpenMinute1 != "" || practiceEditDetails.ThuOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.ThuOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.ThuCloseHour1.ToLower() != "none" || practiceEditDetails.ThuCloseHour1 != "" || practiceEditDetails.ThuCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.ThuCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.ThuCloseMinute1.ToLower() != "none" || practiceEditDetails.ThuCloseMinute1 != "" || practiceEditDetails.ThuCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.ThuCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.ThuOpenHour2.ToLower() != "none" || practiceEditDetails.ThuOpenHour2 != "" || practiceEditDetails.ThuOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.ThuOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.ThuOpenMinute2.ToLower() != "none" || practiceEditDetails.ThuOpenMinute2 != "" || practiceEditDetails.ThuOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.ThuOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.ThuCloseHour2.ToLower() != "none" || practiceEditDetails.ThuCloseHour2 != "" || practiceEditDetails.ThuCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.ThuCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.ThuCloseMinute2.ToLower() != "none" || practiceEditDetails.ThuCloseMinute2 != "" || practiceEditDetails.ThuCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.ThuCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                                                         
                         }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Thursday"); }
                         if (practiceEditDetails.Friday == true)
                         {
                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Friday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.FriOpenHour1.ToLower() != "none" || practiceEditDetails.FriOpenHour1 != "" || practiceEditDetails.FriOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.FriOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.FriOpenMinute1.ToLower() != "none" || practiceEditDetails.FriOpenMinute1 != "" || practiceEditDetails.FriOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.FriOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.FriCloseHour1.ToLower() != "none" || practiceEditDetails.FriCloseHour1 != "" || practiceEditDetails.FriCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.FriCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.FriCloseMinute1.ToLower() != "none" || practiceEditDetails.FriCloseMinute1 != "" || practiceEditDetails.FriCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.FriCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.FriOpenHour2.ToLower() != "none" || practiceEditDetails.FriOpenHour2 != "" || practiceEditDetails.FriOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.FriOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.FriOpenMinute2.ToLower() != "none" || practiceEditDetails.FriOpenMinute2 != "" || practiceEditDetails.FriOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.FriOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.FriCloseHour2.ToLower() != "none" || practiceEditDetails.FriCloseHour2 != "" || practiceEditDetails.FriCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.FriCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.FriCloseMinute2.ToLower() != "none" || practiceEditDetails.FriCloseMinute2 != "" || practiceEditDetails.FriCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.FriCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                            }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Friday"); }
                         if (practiceEditDetails.Saturday == true)
                         {
                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Saturday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.SatOpenHour1.ToLower() != "none" || practiceEditDetails.SatOpenHour1 != "" || practiceEditDetails.SatOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.SatOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.SatOpenMinute1.ToLower() != "none" || practiceEditDetails.SatOpenMinute1 != "" || practiceEditDetails.SatOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.SatOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.SatCloseHour1.ToLower() != "none" || practiceEditDetails.SatCloseHour1 != "" || practiceEditDetails.SatCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.SatCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.SatCloseMinute1.ToLower() != "none" || practiceEditDetails.SatCloseMinute1 != "" || practiceEditDetails.SatCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.SatCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.SatOpenHour2.ToLower() != "none" || practiceEditDetails.SatOpenHour2 != "" || practiceEditDetails.SatOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.SatOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.SatOpenMinute2.ToLower() != "none" || practiceEditDetails.SatOpenMinute2 != "" || practiceEditDetails.SatOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.SatOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.SatCloseHour2.ToLower() != "none" || practiceEditDetails.SatCloseHour2 != "" || practiceEditDetails.SatCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.SatCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.SatCloseMinute2.ToLower() != "none" || practiceEditDetails.SatCloseMinute2 != "" || practiceEditDetails.SatCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.SatCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                           }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Saturday"); }
                         if (practiceEditDetails.Sunday == true)
                         {

                             providerTiming.ProviderId = practiceEditDetails.ProviderId;
                             providerTiming.DayoftheWeek = "Sunday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (practiceEditDetails.SunOpenHour1.ToLower() != "none" || practiceEditDetails.SunOpenHour1 != "" || practiceEditDetails.SunOpenHour1 != null)
                             {
                                 startTime1 = practiceEditDetails.SunOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.SunOpenMinute1.ToLower() != "none" || practiceEditDetails.SunOpenMinute1 != "" || practiceEditDetails.SunOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(practiceEditDetails.SunOpenMinute1);
                             }
                             providerTiming.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (practiceEditDetails.SunCloseHour1.ToLower() != "none" || practiceEditDetails.SunCloseHour1 != "" || practiceEditDetails.SunCloseHour1 != null)
                             {
                                 endTime1 = practiceEditDetails.SunCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (practiceEditDetails.SunCloseMinute1.ToLower() != "none" || practiceEditDetails.SunCloseMinute1 != "" || practiceEditDetails.SunCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(practiceEditDetails.SunCloseMinute1);
                             }
                             providerTiming.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (practiceEditDetails.SunOpenHour2.ToLower() != "none" || practiceEditDetails.SunOpenHour2 != "" || practiceEditDetails.SunOpenHour2 != null)
                             {
                                 startTime2 = practiceEditDetails.SunOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.SunOpenMinute2.ToLower() != "none" || practiceEditDetails.SunOpenMinute2 != "" || practiceEditDetails.SunOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(practiceEditDetails.SunOpenMinute2);
                             }
                             providerTiming.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (practiceEditDetails.SunCloseHour2.ToLower() != "none" || practiceEditDetails.SunCloseHour2 != "" || practiceEditDetails.SunCloseHour2 != null)
                             {
                                 endTime2 = practiceEditDetails.SunCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (practiceEditDetails.SunCloseMinute2.ToLower() != "none" || practiceEditDetails.SunCloseMinute2 != "" || practiceEditDetails.SunCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(practiceEditDetails.SunCloseMinute2);
                             }
                             providerTiming.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerTimingsRepository.Update(providerTiming);
                            }
                         else
                         { providerTimingsRepository.Remove(practiceEditDetails.ProviderId, "Sunday"); }

                         //providerFee.ProviderId = practiceEditDetails.ProviderId;
                         //providerFee.Fee = practiceEditDetails.DoctorConsultationFee;
                         //providerFee.Duration = practiceEditDetails.DoctorConsultationDuration;
                         //providerFee.Type = "paid";
                         //providerFee.Currency = "PKR";
                         //providerFeeRepository.Update(providerFee);
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
            CareHub.DataModel.Models.Practice practice = null;
            CareHub.DataModel.Models.Practice practiceLocation = null;
             CareHub.DataModel.Models.ProviderContact providerContacts = null;
             List<CareHub.DataModel.Models.Language> providerAddedLanguages = null;
             List<CareHub.DataModel.Models.Premises> providerAddedPremises = null;
             List<CareHub.DataModel.Models.Accreditation> providerAddedAccreditations = null;
             List<CareHub.DataModel.Models.Insurance>  providerAddedInsurances = null;
             List<CareHub.DataModel.Models.Service> providerAddedServices = null;
             List<CareHub.DataModel.Models.Service> providerAddedTravelServices = null;
             List<CareHub.DataModel.Models.ProviderTiming> providerAddedTimings = null;
             List<CareHub.DataModel.Models.ProviderPractice> providerPractices = null;

             practiceEditDetails = (PracticeEditDetails)domainModel;

             switch(practiceEditDetails.OperationType)
             {
                  case 1:
                     practice = providerRepository.GetPracticeDetailsById(practiceEditDetails.UserId, 6);
                     if (practice != null)
                     {
                         practiceEditDetails.PracticeDetailsPracticeName = practice.Name;
                         practiceEditDetails.PracticeDetailsTagline = practice.TagLine;
                         practiceEditDetails.PracticeDetailsPracticeDescription = practice.Description;
                         practiceEditDetails.PracticeDetailsBillingCurrencyName = practice.BillingCurrencyName;
                         practiceEditDetails.PracticeDetailsPracticeTypeName = practice.PracticeTypeName;
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;

                         case 2:
                     providerContacts = providerRepository.GetPracticeContactsById(practiceEditDetails.UserId, practiceEditDetails.ProviderId,practiceEditDetails.PracticeId);
                     if (providerContacts != null)
                     {
                         practiceEditDetails.PracticeContactsPrimaryPhone = providerContacts.PrimaryPhone;
                         practiceEditDetails.PracticeContactsSecondaryPhone = providerContacts.SecondaryPhone;
                         practiceEditDetails.PracticeContactsPrimaryEmail = providerContacts.PrimaryEmail;
                         practiceEditDetails.PracticeContactsSecondaryEmail = providerContacts.SecondaryEmail;
                         practiceEditDetails.PracticeContactsWebsiteAddress = providerContacts.WebsiteAddress;
                         
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;
                                                   
                 case 3:
                     providerAddedTimings = providerRepository.GetPracticeTimingsById(practiceEditDetails.ProviderId);
                     if (providerAddedTimings != null || providerAddedTimings.Count() > 0)
                     {
                         foreach (CareHub.DataModel.Models.ProviderTiming item in providerAddedTimings)
                         {
                             switch (item.DayoftheWeek)
                             {                                 
                                 case "Monday":
                                     practiceEditDetails.Monday = true;
                                     practiceEditDetails.MonOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.MonOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.MonCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.MonCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.MonOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.MonOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.MonCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.MonCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Tuesday":
                                     practiceEditDetails.Tuesday = true;
                                     practiceEditDetails.TueOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.TueOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.TueCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.TueCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.TueOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.TueOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.TueCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.TueCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Wednesday":
                                     practiceEditDetails.Wednesday = true;
                                     practiceEditDetails.WedOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.WedOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.WedCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.WedCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.WedOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.WedOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.WedCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.WedCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Thursday":
                                     practiceEditDetails.Thursday = true;
                                     practiceEditDetails.ThuOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.ThuOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.ThuCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.ThuCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.ThuOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.ThuOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.ThuCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.ThuCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Friday":
                                     practiceEditDetails.Friday = true;
                                     practiceEditDetails.FriOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.FriOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.FriCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.FriCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.FriOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.FriOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.FriCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.FriCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Saturday":
                                     practiceEditDetails.Saturday = true;
                                     practiceEditDetails.SatOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.SatOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.SatCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.SatCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.SatOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.SatOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.SatCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.SatCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Sunday":
                                     practiceEditDetails.Sunday = true;
                                     practiceEditDetails.SunOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     practiceEditDetails.SunOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     practiceEditDetails.SunCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     practiceEditDetails.SunCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     practiceEditDetails.SunOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     practiceEditDetails.SunOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     practiceEditDetails.SunCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     practiceEditDetails.SunCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 default:
                                     break;
                             }
                         }
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;

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
                 //return practiceEditDetails;
                 break;

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

                 case 11:
                 providerPractices = providerRepository.GetProviderPractices(practiceEditDetails.UserId, practiceEditDetails.ProviderId);
                 if (providerPractices != null)
                 {
                     practiceEditDetails.ProviderPractice = providerPractices;
                 }
                 else
                 {
                     throw new Exception("Provider not found");
                 }

                 break;

                 case 12:
                 practiceLocation = providerRepository.GetPracticeLocation(practiceEditDetails.UserId, 5);
                 if (practiceLocation != null)
                 {
                     practiceEditDetails.StreetAddress = practiceLocation.Address;
                     practiceEditDetails.CityName = practiceLocation.CityName;
                     practiceEditDetails.Landmark = practiceLocation.Landmark;
                     practiceEditDetails.StateName = practiceLocation.StateName;
                     practiceEditDetails.LocalityName = practiceLocation.LocalityName;
                     practiceEditDetails.ZipCode = practiceLocation.Zipcode;
                     practiceEditDetails.CountryName = practiceLocation.CountryName;

                 }
                 else
                 {
                     throw new Exception("Provider not found");
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
                 case Core.Enumerations.SearchCriteriaEnum.GET_BILLING_CURRENCY:
                     practiceEditDetails.BillingCurrency = billingCurrencyRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_PRACTICE_TYPE:
                     practiceEditDetails.PracticeType = practiceTypeRepository.GetAll();
                     break;       
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