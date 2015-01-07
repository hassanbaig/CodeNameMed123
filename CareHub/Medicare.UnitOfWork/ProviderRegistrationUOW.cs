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
    public class ProviderRegistrationUOW : BaseUnitOfWork, IUnitOfWork
    {
        private ProviderRepository providerRepository;
        private UserRepository userRepository;
        private ProviderRegistration providerRegistration;
        private PracticeRepository practiceRepository;
        private SpecialtyRepository specialtyRepository;
        private CountryRepository countryRepository;
        private CityRepository cityRepository;
        private LocalityRepository localityRepository;
        private ProviderPracticeRepository providerPracticeRepository;
        public ProviderRegistrationUOW()
            : base()
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
        public ProviderRegistrationUOW(shiner49_medicareEntities context)
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
            userRepository = (UserRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(UserRepository));
            specialtyRepository = (SpecialtyRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(SpecialtyRepository));
            countryRepository = (CountryRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CountryRepository));
            cityRepository = (CityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CityRepository));
            localityRepository = (LocalityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(LocalityRepository));
            practiceRepository = (PracticeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(PracticeRepository));
            providerPracticeRepository = (ProviderPracticeRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(ProviderPracticeRepository));
            providerRepository.DataContext = base.Context;
            userRepository.DataContext = base.Context;
            specialtyRepository.DataContext = base.Context;
            countryRepository.DataContext = base.Context;
            cityRepository.DataContext = base.Context;
            localityRepository.DataContext = base.Context;
            practiceRepository.DataContext = base.Context;
            providerPracticeRepository.DataContext = base.Context;
        }


        void IUnitOfWork.Save(AbstractDomainModel domainModel)
        {
            try
            {
                providerRegistration = (ProviderRegistration)domainModel;
                User user = null;
                Provider provider = null;
                ProviderPractice poviderPractice = new ProviderPractice();
                Practice practice = null;

                user = userRepository.GetByName(providerRegistration.Name);
                if (user == null)
                {
                    user = new User();
                    user.UserId = providerRegistration.Name;
                    user.Password = CareHub.Core.Common.Encryption.Encrypt("#", providerRegistration.Password);
                    user.UserRoleId = 1;
                    user.Enable = true;
                    user.Locked = false;
                    user.LastLoginDate = DateTime.Now;
                }
                else
                {
                    throw new Exception("User name already exist. Please login using the existing user name.");
                }

                provider = providerRepository.GetByName(providerRegistration.Name);
                if (provider == null)
                {
                    provider = new Provider();
                    provider.UserId = providerRegistration.Name;
                    provider.FirstName = providerRegistration.Name;
                    provider.ScreenName = providerRegistration.Name;
                    provider.GenderId = providerRegistration.Gender;
                    provider.MobileNumber = providerRegistration.MobileNumber;
                    provider.Email = providerRegistration.Email;
                    provider.IsActive = true;
                    provider.SignUpDate = DateTime.Now;
                }
                else
                {
                    throw new Exception("Provider name already exist. Please use different provider name.");
                }
                practice = practiceRepository.GetByName(providerRegistration.ClinicName);
                if (practice == null)
                {
                    practice = new Practice();
                    practice.Name = providerRegistration.ClinicName;
                    practice.CountryId = providerRegistration.CountryId;
                    practice.CityId = providerRegistration.CityId;
                    practice.LocalityId = providerRegistration.LocalityId;
                    practice.CreationDate = DateTime.Now;
                    practice.Address = providerRegistration.ClinicAddress;
                }


                poviderPractice = new ProviderPractice();
                poviderPractice.Provider = provider;
                poviderPractice.Practice = practice;


                userRepository.Save(user);
                providerRepository.Save(provider);
                practiceRepository.Save(practice);
                providerPracticeRepository.Save(poviderPractice);
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
            providerRegistration = (ProviderRegistration)domainModel;

            CareHub.DataModel.Models.Provider provider = null;
            provider = providerRepository.GetProviderByUserId(providerRegistration.UserId);
                if (provider != null)
                {
                    providerRegistration.Name = provider.FirstName;
                    providerRegistration.UserId = provider.UserId;
                    providerRegistration.Name = provider.FirstName;
                    providerRegistration.Name = provider.ScreenName;
                    providerRegistration.Gender = provider.GenderId;
                    providerRegistration.MobileNumber = provider.MobileNumber;
                    providerRegistration.Email = provider.Email;
                   
                }
                else
                {
                    throw new Exception("Provider not found"); 
                }
            return providerRegistration;
        }

        public AbstractDomainModel GetAll(SearchCriteriaEnum searchCriteria)
        {
            DomainModel.Models.ProviderRegistration providerRegistration = new DomainModel.Models.ProviderRegistration();

            switch (searchCriteria)
            {
                case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES:
                    providerRegistration.Specialties = specialtyRepository.GetAll();
                    break;
                case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES:
                    providerRegistration.Countries = countryRepository.GetAll();
                    break;
                case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_CITIES:
                    providerRegistration.Cities = cityRepository.GetAll();
                    break;
                case CareHub.Core.Enumerations.SearchCriteriaEnum.GET_LOCALITIES:
                    providerRegistration.Localities = localityRepository.GetAll();
                    break;
                default:
                    break;
            }
            return providerRegistration;
        }
    }
}