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
    public class DoctorEditDetailsUOW : BaseUnitOfWork,IUnitOfWork
    {
        private DoctorEditDetails doctorEditDetails;       
        private ProviderRepository providerRepository;
        private ProviderContactsRepository providerContactsRepository;
        private ProviderAvailabilityRepository providerAvailabilityRepository;
        private ProviderFeeRepository providerFeeRepository;
        private RegistrationCouncilRepository registrationCouncilRepository;
        private TreatmentRepository treatmentRepository;
        private SpecialtyRepository specialtyRepository;
        private ProviderSpecialtyRepository providerSpecialtyRepository;
        private LanguageRepository languageRepository;
        private ProviderLanguagesRepository providerLanguagesRepository;
        private ProviderTreatmentRepository providerTreatmentRepository;
        private DegreeRepository degreeRepository;
        private CollegeRepository collegeRepository;
        private AffiliationRepository affiliationRepository;
        private AwardRepository awardRepository;        
        private ProviderEducationRepository providerEducationRepository;
        private ProviderExperienceRepository providerExperienceRepository;
        private ProviderAffiliationRepository providerAffiliationRepository;
        private ProviderAwardRepository providerAwardRepository;

        private Provider provider = null;
        private ProviderContact providerContacts = null;
        private ProviderFee providerFee = null;
        private ProviderAvailability providerAvailability = null;
        private ProviderSpecialty providerSpecialty = null;
        private ProviderLanguage providerLanguage = null;
        private Treatment treatment = null;
        private ProviderTreatment providerTreatment = null;
        private ProviderEducation providerEducation = null;
        private ProviderExperience providerExperience = null;
        private ProviderAffiliation providerAffiliation = null;
        private ProviderAward providerAward = null;
        private Specialty specialty = null;
        private Language language = null;
        public DoctorEditDetailsUOW ():base()
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
        public DoctorEditDetailsUOW(MedicareDevEntities context)
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
            providerContactsRepository = (ProviderContactsRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderContactsRepository));
            providerAvailabilityRepository = (ProviderAvailabilityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderAvailabilityRepository));
            providerFeeRepository = (ProviderFeeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderFeeRepository));
            registrationCouncilRepository = (RegistrationCouncilRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(RegistrationCouncilRepository));
            treatmentRepository = (TreatmentRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(TreatmentRepository));
            specialtyRepository = (SpecialtyRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(SpecialtyRepository));
            providerSpecialtyRepository = (ProviderSpecialtyRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderSpecialtyRepository));
            languageRepository = (LanguageRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(LanguageRepository));
            providerLanguagesRepository = (ProviderLanguagesRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderLanguagesRepository));
            providerTreatmentRepository = (ProviderTreatmentRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderTreatmentRepository));
            degreeRepository = (DegreeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(DegreeRepository));
            collegeRepository = (CollegeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CollegeRepository));
            affiliationRepository = (AffiliationRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(AffiliationRepository));
            awardRepository = (AwardRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(AwardRepository));
            providerEducationRepository = (ProviderEducationRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderEducationRepository));
            providerExperienceRepository = (ProviderExperienceRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderExperienceRepository));
            providerAffiliationRepository = (ProviderAffiliationRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderAffiliationRepository));
            providerAwardRepository = (ProviderAwardRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderAwardRepository));

            providerRepository.DataContext = base.Context;
            providerContactsRepository.DataContext = base.Context;
            providerAvailabilityRepository.DataContext = base.Context;
            providerFeeRepository.DataContext = base.Context;
            registrationCouncilRepository.DataContext = base.Context;
            treatmentRepository.DataContext = base.Context;
            specialtyRepository.DataContext = base.Context;
            providerSpecialtyRepository.DataContext = base.Context;
            languageRepository.DataContext = base.Context;
            providerLanguagesRepository.DataContext = base.Context;
            providerTreatmentRepository.DataContext = base.Context;
            degreeRepository.DataContext = base.Context;
            collegeRepository.DataContext = base.Context;
            affiliationRepository.DataContext = base.Context;
            awardRepository.DataContext = base.Context;
            providerEducationRepository.DataContext = base.Context;
            providerExperienceRepository.DataContext = base.Context;
            providerAffiliationRepository.DataContext = base.Context;
            providerAwardRepository.DataContext = base.Context;
        }       
         void IUnitOfWork.Save(AbstractDomainModel domainModel)
         {
             doctorEditDetails = (DoctorEditDetails)domainModel;
             try
             {
                 switch (doctorEditDetails.OperationType)
                 {
                     case 4:
                         specialty = new Specialty();
                         specialty.Title = doctorEditDetails.DoctorSpecializationsSpecializationName;

                         doctorEditDetails.Specialties = specialtyRepository.Save(specialty);
                         break;
                     case 7:
                         language = new Language();
                         language.Name = doctorEditDetails.DoctorLanguagesLanguageName;

                         doctorEditDetails.Languages = languageRepository.Save(language);
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

         void IUnitOfWork.SaveAll()
         {
             throw new NotImplementedException();
         }

         void IUnitOfWork.Delete(AbstractDomainModel domainModel)
         {
             doctorEditDetails = (DoctorEditDetails)domainModel;
             try
             {
                 switch (doctorEditDetails.OperationType)
                 {
                     case 6:
                         providerSpecialty = new ProviderSpecialty();
                         providerSpecialty.SpecialtyId = doctorEditDetails.DoctorSpecializationsSpecializationId;
                         providerSpecialty.ProviderId = doctorEditDetails.ProviderId;
                         providerSpecialtyRepository.Delete(providerSpecialty);
                         break;
                     case 9:
                         providerLanguage = new ProviderLanguage();
                         providerLanguage.LanguageId = doctorEditDetails.DoctorSpecializationsLanguageId;
                         providerLanguage.ProviderId = doctorEditDetails.ProviderId;
                         providerLanguagesRepository.Delete(providerLanguage);
                         break;
                     case 12:                                                  
                         providerTreatment = new ProviderTreatment();
                         providerTreatment.TreatmentId = doctorEditDetails.DoctorTreatmentsTreatmentId;
                         providerTreatment.ProviderId = doctorEditDetails.ProviderId;
                         providerTreatmentRepository.Delete(providerTreatment);
                         break;
                     case 13:
                         providerEducation = new ProviderEducation();
                         providerEducation.ProviderId = doctorEditDetails.ProviderId;
                         providerEducation.DegreeTitle = doctorEditDetails.DoctorProfessionalDetailsEducationDegree;
                         providerEducation.SchoolTitle = doctorEditDetails.DoctorProfessionalDetailsEducationCollege;                         
                         providerEducationRepository.Delete(providerEducation);
                         break;
                     case 14:
                         providerExperience = new ProviderExperience();
                         providerExperience.ProviderId = doctorEditDetails.ProviderId;
                         providerExperience.Designation = doctorEditDetails.DoctorProfessionalDetailsExperienceDesignation;
                         providerExperience.Organization = doctorEditDetails.DoctorProfessionalDetailsExperienceOrganization;
                         providerExperience.CityId = doctorEditDetails.DoctorProfessionalDetailsExperienceCity;
                         providerExperienceRepository.Delete(providerExperience);
                         break;
                     case 15:
                         providerAffiliation = new ProviderAffiliation();
                         providerAffiliation.ProviderId = doctorEditDetails.ProviderId;
                         providerAffiliation.AffiliationId = doctorEditDetails.DoctorProfessionalDetailsAffiliationId;

                         providerAffiliationRepository.Delete(providerAffiliation);
                         break;
                     case 16:
                         providerAward = new ProviderAward();
                         providerAward.ProviderId = doctorEditDetails.ProviderId;
                         providerAward.AwardId = doctorEditDetails.DoctorProfessionalDetailsAwardId;
                         providerAwardRepository.Delete(providerAward);
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
             doctorEditDetails = (DoctorEditDetails)domainModel;             
             try
             {
                 switch (doctorEditDetails.OperationType)
                 {
                     case 1:
                         provider = new Provider();
                         string[] doctorName = doctorEditDetails.DoctorDetailsDoctorName.Split(' ');
                         string firstName = doctorName[0];
                         string lastName = string.Empty;
                         for (int i = 1; i < doctorName.Count(); i++)
                         {
                             lastName += doctorName[i] + ' ';
                         }
                         provider.ProviderId = doctorEditDetails.ProviderId;
                         provider.UserId = doctorEditDetails.UserId;
                         provider.FirstName = firstName;
                         provider.LastName = lastName;
                         provider.GenderId = (int)doctorEditDetails.DoctorDetailsGender;
                         provider.RegistrationDetails = doctorEditDetails.DoctorDetailsRegistrationDetails;
                         provider.RegistrationYear = doctorEditDetails.DoctorDetailsRegistrationYear;
                         provider.RegistrationCouncilId = doctorEditDetails.DoctorDetailsRegistrationCouncil;
                         provider.TagLine = doctorEditDetails.DoctorDetailsTagline;
                         provider.TotalExperienceYears = doctorEditDetails.DoctorDetailsExperienceYears;
                         provider.Description = doctorEditDetails.DoctorDetailsDoctorDescription;

                         providerRepository.UpdateDoctorDetails(provider);
                         break;
                     case 2:
                         providerContacts = new ProviderContact();
                         providerContacts.ProviderId = doctorEditDetails.ProviderId;
                         providerContacts.PrimaryPhone = doctorEditDetails.DoctorContactsPrimaryPhone;
                         providerContacts.PrimaryEmail = doctorEditDetails.DoctorContactsPrimaryEmail;
                         providerContacts.SecondaryPhone = doctorEditDetails.DoctorContactsSecondaryPhone;
                         providerContacts.SecondaryEmail = doctorEditDetails.DoctorContactsSecondaryEmail;
                         providerContacts.WebsiteAddress = doctorEditDetails.DoctorContactsWebsiteAddress;

                         providerContactsRepository.Update(providerContacts);
                         break;
                     case 3:
                         providerFee = new ProviderFee();
                         if (doctorEditDetails.Monday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Monday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.MonOpenHour1.ToLower() != "none" || doctorEditDetails.MonOpenHour1 != "" || doctorEditDetails.MonOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.MonOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.MonOpenMinute1.ToLower() != "none" || doctorEditDetails.MonOpenMinute1 != "" || doctorEditDetails.MonOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.MonOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.MonCloseHour1.ToLower() != "none" || doctorEditDetails.MonCloseHour1 != "" || doctorEditDetails.MonCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.MonCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.MonCloseMinute1.ToLower() != "none" || doctorEditDetails.MonCloseMinute1 != "" || doctorEditDetails.MonCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.MonCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.MonOpenHour2.ToLower() != "none" || doctorEditDetails.MonOpenHour2 != "" || doctorEditDetails.MonOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.MonOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.MonOpenMinute2.ToLower() != "none" || doctorEditDetails.MonOpenMinute2 != "" || doctorEditDetails.MonOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.MonOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.MonCloseHour2.ToLower() != "none" || doctorEditDetails.MonCloseHour2 != "" || doctorEditDetails.MonCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.MonCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.MonCloseMinute2.ToLower() != "none" || doctorEditDetails.MonCloseMinute2 != "" || doctorEditDetails.MonCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.MonCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Monday"); }

                         if (doctorEditDetails.Tuesday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Tuesday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.TueOpenHour1.ToLower() != "none" || doctorEditDetails.TueOpenHour1 != "" || doctorEditDetails.TueOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.TueOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.TueOpenMinute1.ToLower() != "none" || doctorEditDetails.TueOpenMinute1 != "" || doctorEditDetails.TueOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.TueOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.TueCloseHour1.ToLower() != "none" || doctorEditDetails.TueCloseHour1 != "" || doctorEditDetails.TueCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.TueCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.TueCloseMinute1.ToLower() != "none" || doctorEditDetails.TueCloseMinute1 != "" || doctorEditDetails.TueCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.TueCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.TueOpenHour2.ToLower() != "none" || doctorEditDetails.TueOpenHour2 != "" || doctorEditDetails.TueOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.TueOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.TueOpenMinute2.ToLower() != "none" || doctorEditDetails.TueOpenMinute2 != "" || doctorEditDetails.TueOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.TueOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.TueCloseHour2.ToLower() != "none" || doctorEditDetails.TueCloseHour2 != "" || doctorEditDetails.TueCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.TueCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.TueCloseMinute2.ToLower() != "none" || doctorEditDetails.TueCloseMinute2 != "" || doctorEditDetails.TueCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.TueCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Tuesday"); }
                         if (doctorEditDetails.Wednesday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Wednesday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.WedOpenHour1.ToLower() != "none" || doctorEditDetails.WedOpenHour1 != "" || doctorEditDetails.WedOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.WedOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.WedOpenMinute1.ToLower() != "none" || doctorEditDetails.WedOpenMinute1 != "" || doctorEditDetails.WedOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.WedOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.WedCloseHour1.ToLower() != "none" || doctorEditDetails.WedCloseHour1 != "" || doctorEditDetails.WedCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.WedCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.WedCloseMinute1.ToLower() != "none" || doctorEditDetails.WedCloseMinute1 != "" || doctorEditDetails.WedCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.WedCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.WedOpenHour2.ToLower() != "none" || doctorEditDetails.WedOpenHour2 != "" || doctorEditDetails.WedOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.WedOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.WedOpenMinute2.ToLower() != "none" || doctorEditDetails.WedOpenMinute2 != "" || doctorEditDetails.WedOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.WedOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.WedCloseHour2.ToLower() != "none" || doctorEditDetails.WedCloseHour2 != "" || doctorEditDetails.WedCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.WedCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.WedCloseMinute2.ToLower() != "none" || doctorEditDetails.WedCloseMinute2 != "" || doctorEditDetails.WedCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.WedCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Wednesday"); }
                         if (doctorEditDetails.Thursday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Thursday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.ThuOpenHour1.ToLower() != "none" || doctorEditDetails.ThuOpenHour1 != "" || doctorEditDetails.ThuOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.ThuOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.ThuOpenMinute1.ToLower() != "none" || doctorEditDetails.ThuOpenMinute1 != "" || doctorEditDetails.ThuOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.ThuOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.ThuCloseHour1.ToLower() != "none" || doctorEditDetails.ThuCloseHour1 != "" || doctorEditDetails.ThuCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.ThuCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.ThuCloseMinute1.ToLower() != "none" || doctorEditDetails.ThuCloseMinute1 != "" || doctorEditDetails.ThuCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.ThuCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.ThuOpenHour2.ToLower() != "none" || doctorEditDetails.ThuOpenHour2 != "" || doctorEditDetails.ThuOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.ThuOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.ThuOpenMinute2.ToLower() != "none" || doctorEditDetails.ThuOpenMinute2 != "" || doctorEditDetails.ThuOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.ThuOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.ThuCloseHour2.ToLower() != "none" || doctorEditDetails.ThuCloseHour2 != "" || doctorEditDetails.ThuCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.ThuCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.ThuCloseMinute2.ToLower() != "none" || doctorEditDetails.ThuCloseMinute2 != "" || doctorEditDetails.ThuCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.ThuCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Thursday"); }
                         if (doctorEditDetails.Friday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Friday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.FriOpenHour1.ToLower() != "none" || doctorEditDetails.FriOpenHour1 != "" || doctorEditDetails.FriOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.FriOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.FriOpenMinute1.ToLower() != "none" || doctorEditDetails.FriOpenMinute1 != "" || doctorEditDetails.FriOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.FriOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.FriCloseHour1.ToLower() != "none" || doctorEditDetails.FriCloseHour1 != "" || doctorEditDetails.FriCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.FriCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.FriCloseMinute1.ToLower() != "none" || doctorEditDetails.FriCloseMinute1 != "" || doctorEditDetails.FriCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.FriCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.FriOpenHour2.ToLower() != "none" || doctorEditDetails.FriOpenHour2 != "" || doctorEditDetails.FriOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.FriOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.FriOpenMinute2.ToLower() != "none" || doctorEditDetails.FriOpenMinute2 != "" || doctorEditDetails.FriOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.FriOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.FriCloseHour2.ToLower() != "none" || doctorEditDetails.FriCloseHour2 != "" || doctorEditDetails.FriCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.FriCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.FriCloseMinute2.ToLower() != "none" || doctorEditDetails.FriCloseMinute2 != "" || doctorEditDetails.FriCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.FriCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Friday"); }
                         if (doctorEditDetails.Saturday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Saturday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.SatOpenHour1.ToLower() != "none" || doctorEditDetails.SatOpenHour1 != "" || doctorEditDetails.SatOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.SatOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.SatOpenMinute1.ToLower() != "none" || doctorEditDetails.SatOpenMinute1 != "" || doctorEditDetails.SatOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.SatOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.SatCloseHour1.ToLower() != "none" || doctorEditDetails.SatCloseHour1 != "" || doctorEditDetails.SatCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.SatCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.SatCloseMinute1.ToLower() != "none" || doctorEditDetails.SatCloseMinute1 != "" || doctorEditDetails.SatCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.SatCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.SatOpenHour2.ToLower() != "none" || doctorEditDetails.SatOpenHour2 != "" || doctorEditDetails.SatOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.SatOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.SatOpenMinute2.ToLower() != "none" || doctorEditDetails.SatOpenMinute2 != "" || doctorEditDetails.SatOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.SatOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.SatCloseHour2.ToLower() != "none" || doctorEditDetails.SatCloseHour2 != "" || doctorEditDetails.SatCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.SatCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.SatCloseMinute2.ToLower() != "none" || doctorEditDetails.SatCloseMinute2 != "" || doctorEditDetails.SatCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.SatCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Saturday"); }
                         if (doctorEditDetails.Sunday == true)
                         {
                             providerAvailability = new ProviderAvailability();
                             providerAvailability.ProviderId = doctorEditDetails.ProviderId;
                             providerAvailability.DayoftheWeek = "Sunday";

                             string[] startTime1;
                             int OpenHour1 = 0;
                             int OpenMinute1 = 0;
                             if (doctorEditDetails.SunOpenHour1.ToLower() != "none" || doctorEditDetails.SunOpenHour1 != "" || doctorEditDetails.SunOpenHour1 != null)
                             {
                                 startTime1 = doctorEditDetails.SunOpenHour1.Split(' ');
                                 OpenHour1 = Convert.ToInt32(startTime1[0]);

                                 if (startTime1[1].ToLower() == "pm" && OpenHour1 != 12)
                                 {
                                     OpenHour1 = OpenHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.SunOpenMinute1.ToLower() != "none" || doctorEditDetails.SunOpenMinute1 != "" || doctorEditDetails.SunOpenMinute1 != null)
                             {
                                 OpenMinute1 = Convert.ToInt32(doctorEditDetails.SunOpenMinute1);
                             }
                             providerAvailability.StartTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour1, OpenMinute1, 00);

                             string[] endTime1;
                             int CloseHour1 = 0;
                             int CloseMinute1 = 0;
                             if (doctorEditDetails.SunCloseHour1.ToLower() != "none" || doctorEditDetails.SunCloseHour1 != "" || doctorEditDetails.SunCloseHour1 != null)
                             {
                                 endTime1 = doctorEditDetails.SunCloseHour1.Split(' ');
                                 CloseHour1 = Convert.ToInt32(endTime1[0]);

                                 if (endTime1[1].ToLower() == "pm" && CloseHour1 != 12)
                                 {
                                     CloseHour1 = CloseHour1 + 12;
                                 }
                             }
                             if (doctorEditDetails.SunCloseMinute1.ToLower() != "none" || doctorEditDetails.SunCloseMinute1 != "" || doctorEditDetails.SunCloseMinute1 != null)
                             {
                                 CloseMinute1 = Convert.ToInt32(doctorEditDetails.SunCloseMinute1);
                             }
                             providerAvailability.EndTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour1, CloseMinute1, 00);

                             string[] startTime2;
                             int OpenHour2 = 0;
                             int OpenMinute2 = 0;
                             if (doctorEditDetails.SunOpenHour2.ToLower() != "none" || doctorEditDetails.SunOpenHour2 != "" || doctorEditDetails.SunOpenHour2 != null)
                             {
                                 startTime2 = doctorEditDetails.SunOpenHour2.Split(' ');
                                 OpenHour2 = Convert.ToInt32(startTime2[0]);

                                 if (startTime2[1].ToLower() == "pm" && OpenHour2 != 12)
                                 {
                                     OpenHour2 = OpenHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.SunOpenMinute2.ToLower() != "none" || doctorEditDetails.SunOpenMinute2 != "" || doctorEditDetails.SunOpenMinute2 != null)
                             {
                                 OpenMinute2 = Convert.ToInt32(doctorEditDetails.SunOpenMinute2);
                             }
                             providerAvailability.StartTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, OpenHour2, OpenMinute2, 00);

                             string[] endTime2;
                             int CloseHour2 = 0;
                             int CloseMinute2 = 0;
                             if (doctorEditDetails.SunCloseHour2.ToLower() != "none" || doctorEditDetails.SunCloseHour2 != "" || doctorEditDetails.SunCloseHour2 != null)
                             {
                                 endTime2 = doctorEditDetails.SunCloseHour2.Split(' ');
                                 CloseHour2 = Convert.ToInt32(endTime2[0]);

                                 if (endTime2[1].ToLower() == "pm" && CloseHour2 != 12)
                                 {
                                     CloseHour2 = CloseHour2 + 12;
                                 }
                             }
                             if (doctorEditDetails.SunCloseMinute2.ToLower() != "none" || doctorEditDetails.SunCloseMinute2 != "" || doctorEditDetails.SunCloseMinute2 != null)
                             {
                                 CloseMinute2 = Convert.ToInt32(doctorEditDetails.SunCloseMinute2);
                             }
                             providerAvailability.EndTime2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, CloseHour2, CloseMinute2, 00);

                             providerAvailabilityRepository.Update(providerAvailability);
                         }
                         else
                         { providerAvailabilityRepository.Remove(doctorEditDetails.ProviderId, "Sunday"); }

                         providerFee.ProviderId = doctorEditDetails.ProviderId;
                         providerFee.Fee = doctorEditDetails.DoctorConsultationFee;
                         providerFee.Duration = doctorEditDetails.DoctorConsultationDuration;
                         providerFee.Type = "paid";
                         providerFee.Currency = "PKR";
                         providerFeeRepository.Update(providerFee);
                         break;
                     case 5:
                         providerSpecialty = new ProviderSpecialty();
                         providerSpecialty.ProviderId = doctorEditDetails.ProviderId;
                         providerSpecialty.SpecialtyId = doctorEditDetails.DoctorSpecializationsSpecializationId;

                         providerSpecialtyRepository.AddProviderSpecialties(providerSpecialty);

                         break;
                     case 8:
                         providerLanguage = new ProviderLanguage();
                         providerLanguage.ProviderId = doctorEditDetails.ProviderId;
                         providerLanguage.LanguageId = doctorEditDetails.DoctorSpecializationsLanguageId;

                         providerLanguagesRepository.AddProviderLanguages(providerLanguage);
                         break;
                     case 10:
                         treatment = new Treatment();
                         treatment.Name = doctorEditDetails.DoctorTreatmentsTreatmentName;
                         treatment.Cost = doctorEditDetails.DoctorTreatmentsTreatmentCost;
                         treatment.Tax = doctorEditDetails.DoctorTreatmentsTreatmentTax; ;
                         treatment.ParentId = doctorEditDetails.DoctorTreatmentsIsSubcategory; ;
                         treatment.Notes = doctorEditDetails.DoctorTreatmentsNotes;

                         long treatmentId = treatmentRepository.AddTreatmentGetId(treatment);

                         if (treatmentId != 0)
                         {
                             providerTreatment = new ProviderTreatment();
                             providerTreatment.TreatmentId = treatmentId;
                             providerTreatment.ProviderId = doctorEditDetails.ProviderId;
                             providerTreatmentRepository.AddProviderTreatments(providerTreatment);
                         }
                         break;
                     case 11:
                         treatment = new Treatment();

                         treatment.TreatmentId = doctorEditDetails.DoctorTreatmentsTreatmentId;
                         treatment.Name = doctorEditDetails.DoctorTreatmentsTreatmentName;
                         treatment.Cost = doctorEditDetails.DoctorTreatmentsTreatmentCost;
                         treatment.Tax = doctorEditDetails.DoctorTreatmentsTreatmentTax; ;
                         treatment.ParentId = doctorEditDetails.DoctorTreatmentsIsSubcategory; ;
                         treatment.Notes = doctorEditDetails.DoctorTreatmentsNotes;

                         treatmentRepository.Update(treatment);
                         break;
                     case 12:
                         providerEducation = new ProviderEducation();

                         providerEducation.ProviderId = doctorEditDetails.ProviderId;
                         providerEducation.DegreeTitle = doctorEditDetails.DoctorProfessionalDetailsEducationDegree;
                         providerEducation.SchoolTitle = doctorEditDetails.DoctorProfessionalDetailsEducationCollege;
                         providerEducation.DegreeYear = doctorEditDetails.DoctorProfessionalDetailsEducationYear;
                         
                         providerEducationRepository.AddProviderEducation(providerEducation);
                         break;
                     case 13:
                         providerExperience = new ProviderExperience();

                         providerExperience.ProviderId = doctorEditDetails.ProviderId;
                         providerExperience.Designation = doctorEditDetails.DoctorProfessionalDetailsExperienceDesignation;
                         providerExperience.Organization = doctorEditDetails.DoctorProfessionalDetailsExperienceOrganization;
                         providerExperience.CityId = doctorEditDetails.DoctorProfessionalDetailsExperienceCity;
                         providerExperience.StartYear = doctorEditDetails.DoctorProfessionalDetailsExperienceStartYear;
                         providerExperience.EndYear = doctorEditDetails.DoctorProfessionalDetailsExperienceEndYear;
                         providerExperience.TotalYears = providerExperience.EndYear - providerExperience.StartYear;

                         providerExperienceRepository.AddProviderExperience(providerExperience);
                         break;
                     case 14:
                         providerAffiliation = new ProviderAffiliation();
                         
                         providerAffiliation.ProviderId = doctorEditDetails.ProviderId;
                         providerAffiliation.AffiliationId = doctorEditDetails.DoctorProfessionalDetailsAffiliationId;
                         providerAffiliation.Year = doctorEditDetails.DoctorProfessionalDetailsAffiliationYear;

                         providerAffiliationRepository.AddProviderAffiliation(providerAffiliation);
                         break;
                     case 15:
                         providerAward = new ProviderAward();
                                                  
                         providerAward.ProviderId = doctorEditDetails.ProviderId;
                         providerAward.AwardId = doctorEditDetails.DoctorProfessionalDetailsAwardId;
                         providerAward.Year = doctorEditDetails.DoctorProfessionalDetailsAwardYear;

                         providerAwardRepository.AddProviderAward(providerAward);
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
            Medicare.DataModel.Models.Provider provider = null;
            Medicare.DataModel.Models.ProviderContact providerContact = null;
            List<Medicare.DataModel.Models.ProviderAvailability> providerAvailability = null;
            Medicare.DataModel.Models.ProviderFee providerFee = null;
            List<Medicare.DataModel.Models.Specialty> providerAddedSpecializations = null;
            List<Medicare.DataModel.Models.Language> providerAddedLanguages = null;
            List<Medicare.DataModel.Models.Treatment> providerAddedTreatments = null;
            List<Medicare.DataModel.Models.ProviderEducation> providerAddedEducation = null;
            List<Medicare.DataModel.Models.ProviderExperience> providerAddedExperience = null;
            List<Medicare.DataModel.Models.ProviderAffiliation> providerAddedAffiliations = null;
            List<Medicare.DataModel.Models.ProviderAward> providerAddedAwards = null;

             doctorEditDetails = (DoctorEditDetails)domainModel;
             switch (doctorEditDetails.OperationType)
             {
                 case 1:                    
                    provider = providerRepository.GetDoctorDetailsById(doctorEditDetails.UserId, doctorEditDetails.ProviderId);
                     if (provider != null)
                     {
                         doctorEditDetails.DoctorDetailsDoctorName = provider.FirstName + ' ' + provider.LastName;
                         doctorEditDetails.DoctorDetailsGender = provider.GenderId;
                         doctorEditDetails.DoctorDetailsRegistrationDetails = provider.RegistrationDetails;
                         doctorEditDetails.DoctorDetailsRegistrationYear = provider.RegistrationYear;
                         doctorEditDetails.DoctorDetailsRegistrationCouncil = provider.RegistrationCouncilId;
                         doctorEditDetails.DoctorDetailsExperienceYears = provider.TotalExperienceYears;
                         doctorEditDetails.DoctorDetailsTagline = provider.TagLine;
                         doctorEditDetails.DoctorDetailsDoctorDescription = provider.Description;
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;
                 case 2:
                     providerContact = providerRepository.GetDoctorContactsById(doctorEditDetails.ProviderId);
                     if (providerContact != null)
                     {
                         doctorEditDetails.DoctorContactsPrimaryPhone = providerContact.PrimaryPhone;
                         doctorEditDetails.DoctorContactsSecondaryPhone = providerContact.SecondaryPhone;
                         doctorEditDetails.DoctorContactsPrimaryEmail = providerContact.PrimaryEmail;
                         doctorEditDetails.DoctorContactsSecondaryEmail = providerContact.SecondaryEmail;
                         doctorEditDetails.DoctorContactsWebsiteAddress = providerContact.WebsiteAddress;                         
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;
                 case 3:
                     providerAvailability = providerRepository.GetDoctorTimingsById(doctorEditDetails.ProviderId);
                     if (providerAvailability != null || providerAvailability.Count() > 0)
                     {
                         foreach (Medicare.DataModel.Models.ProviderAvailability item in providerAvailability)
                         {
                             switch (item.DayoftheWeek)
                             {
                                 case "Monday":
                                     doctorEditDetails.Monday = true;
                                     doctorEditDetails.MonOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.MonOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.MonCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.MonCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.MonOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.MonOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.MonCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.MonCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Tuesday":
                                     doctorEditDetails.Tuesday = true;
                                     doctorEditDetails.TueOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.TueOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.TueCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.TueCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.TueOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.TueOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.TueCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.TueCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Wednesday":
                                     doctorEditDetails.Wednesday = true;
                                     doctorEditDetails.WedOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.WedOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.WedCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.WedCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.WedOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.WedOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.WedCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.WedCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Thursday":
                                     doctorEditDetails.Thursday = true;
                                     doctorEditDetails.ThuOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.ThuOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.ThuCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.ThuCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.ThuOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.ThuOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.ThuCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.ThuCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Friday":
                                     doctorEditDetails.Friday = true;
                                     doctorEditDetails.FriOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.FriOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.FriCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.FriCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.FriOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.FriOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.FriCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.FriCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Saturday":
                                     doctorEditDetails.Saturday = true;
                                     doctorEditDetails.SatOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.SatOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.SatCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.SatCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.SatOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.SatOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.SatCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.SatCloseMinute2 = item.EndTime2.Value.Minute.ToString();
                                     break;
                                 case "Sunday":
                                     doctorEditDetails.Sunday = true;
                                     doctorEditDetails.SunOpenHour1 = item.StartTime1.Value.Hour.ToString();
                                     doctorEditDetails.SunOpenMinute1 = item.StartTime1.Value.Minute.ToString();
                                     doctorEditDetails.SunCloseHour1 = item.EndTime1.Value.Hour.ToString();
                                     doctorEditDetails.SunCloseMinute1 = item.EndTime1.Value.Minute.ToString();
                                     doctorEditDetails.SunOpenHour2 = item.StartTime2.Value.Hour.ToString();
                                     doctorEditDetails.SunOpenMinute2 = item.StartTime2.Value.Minute.ToString();
                                     doctorEditDetails.SunCloseHour2 = item.EndTime2.Value.Hour.ToString();
                                     doctorEditDetails.SunCloseMinute2 = item.EndTime2.Value.Minute.ToString();
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
                     providerFee = providerRepository.GetDoctorFeeById(doctorEditDetails.ProviderId);
                     if (providerFee != null)
                     {
                         doctorEditDetails.DoctorConsultationDuration = providerFee.Duration;
                         doctorEditDetails.DoctorConsultationFee = providerFee.Fee;
                     }
                     else
                     {
                         throw new Exception("Provider not found");
                     }
                     break;
                 case 4:
                     providerAddedSpecializations = providerRepository.GetAddedSpecializations(doctorEditDetails.UserId, doctorEditDetails.ProviderId);
                     if (providerAddedSpecializations != null)
                     {
                         doctorEditDetails.AddedSpecialties = providerAddedSpecializations;
                     }
                     else
                     {
                         throw new Exception("Specialties not found");
                     }
                     break;
                 case 5:
                     providerAddedLanguages = providerRepository.GetAddedLanguages(doctorEditDetails.UserId, doctorEditDetails.ProviderId);
                     if (providerAddedLanguages != null)
                     {
                         doctorEditDetails.AddedLanguages = providerAddedLanguages;
                     }
                     else
                     {
                         throw new Exception("Languages not found");
                     }
                     break;
                 case 6:
                     providerAddedTreatments = providerRepository.GetAddedTreatments(doctorEditDetails.UserId, doctorEditDetails.ProviderId);
                     if (providerAddedTreatments != null)
                     {
                         doctorEditDetails.AddedTreatments = providerAddedTreatments;
                     }
                     else
                     {
                         throw new Exception("Languages not found");
                     }
                     break;
                 case 7:
                     providerAddedEducation = providerEducationRepository.GetProviderEducation(doctorEditDetails.ProviderId);
                     if (providerAddedEducation != null)
                     {
                         doctorEditDetails.AddedEducation = providerAddedEducation;
                     }
                     else
                     {
                         throw new Exception("Education not found");
                     }
                     break;
                 case 8:
                     providerAddedExperience = providerExperienceRepository.GetProviderExperience(doctorEditDetails.ProviderId);
                     if (providerAddedExperience != null)
                     {
                         doctorEditDetails.AddedExperience = providerAddedExperience;
                     }
                     else
                     {
                         throw new Exception("Experience not found");
                     }
                     break;
                 case 9:
                     providerAddedAffiliations = providerAffiliationRepository.GetProviderAffiliations(doctorEditDetails.ProviderId);
                     if (providerAddedAffiliations != null)
                     {
                         doctorEditDetails.AddedAffiliations = providerAddedAffiliations;
                     }
                     else
                     {
                         throw new Exception("Affiliation not found");
                     }
                     break;
                 case 10:
                     providerAddedAwards = providerAwardRepository.GetProviderAwards(doctorEditDetails.ProviderId);
                     if (providerAddedAwards != null)
                     {
                         doctorEditDetails.AddedAwards = providerAddedAwards;
                     }
                     else
                     {
                         throw new Exception("Award not found");
                     }
                     break;
                 default:
                     break;
             }
             return doctorEditDetails;              
         }
         public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
         {
             doctorEditDetails = new DomainModel.Models.DoctorEditDetails();
             switch (searchCriteria)
             {
                 case Core.Enumerations.SearchCriteriaEnum.GET_REGISTRATION_COUNCILS:
                     doctorEditDetails.RegistrationCouncils = registrationCouncilRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES:
                     doctorEditDetails.Specialties = specialtyRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES:
                     doctorEditDetails.Languages = languageRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_PARENT_TREATMENTS:
                     doctorEditDetails.ParentTreatments = treatmentRepository.GetAllParentTreatments();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_TREATMENTS:
                     doctorEditDetails.Treatments = treatmentRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_DEGREES:
                     doctorEditDetails.Degrees = degreeRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_COLLEGES:
                     doctorEditDetails.Colleges = collegeRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_AFFILIATIONS:
                     doctorEditDetails.Affiliations = affiliationRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_AWARDS:
                     doctorEditDetails.Awards = awardRepository.GetAll();
                     break;                 
                 default:
                     break;
             }
             return doctorEditDetails;              
         }
    }
}