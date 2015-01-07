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
    public class DoctorsSearchUOW : BaseUnitOfWork,IUnitOfWork
    {          
        private ProviderRepository providerRepository;        
        private CountryRepository countryRepository;
        private CityRepository cityRepository;
        private LocalityRepository localityRepository;
        private SpecialtyRepository specialtyRepository;        
        private TreatmentRepository treatmentRepository;
        private DoctorsSearch searchDoctor;
        public DoctorsSearchUOW ():base()
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
        public DoctorsSearchUOW(shiner49_medicareEntities context)
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
            cityRepository = (CityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(CityRepository));
            localityRepository = (LocalityRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(LocalityRepository));
            specialtyRepository = (SpecialtyRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(SpecialtyRepository));            
            treatmentRepository = (TreatmentRepository)base.Factory.RepositoryFactory.CreateRepository(typeof(TreatmentRepository));  
            
            providerRepository.DataContext = base.Context;            
            countryRepository.DataContext = base.Context;
            cityRepository.DataContext = base.Context;
            localityRepository.DataContext = base.Context;
            specialtyRepository.DataContext = base.Context;            
            treatmentRepository.DataContext = base.Context;
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
             searchDoctor = (DomainModel.Models.DoctorsSearch)domainModel;
             switch (searchDoctor.SearchType)
             {
                 case 1:
                     searchDoctor.Providers = providerRepository.GetProviderBySpecialty(searchDoctor.City, searchDoctor.Specialty);                     
                     break;
                 case 2:
                     searchDoctor.Providers = providerRepository.GetProviderBySpecialtyLocality(searchDoctor.City, searchDoctor.Specialty, searchDoctor.Locality);
                     break;
                 case 3:
                     searchDoctor.Providers = providerRepository.GetProviderByDoctor(searchDoctor.City, searchDoctor.Doctor);
                     break;
                 case 4:
                     searchDoctor.Providers = providerRepository.GetProviderByDoctorLocality(searchDoctor.City, searchDoctor.Doctor, searchDoctor.Locality);
                     break;
                 case 5:
                     searchDoctor.Providers = providerRepository.GetProviderByHospital(searchDoctor.City, searchDoctor.Hospital);
                     break;
                 case 6:
                     searchDoctor.Providers = providerRepository.GetProviderByHospitalLocality(searchDoctor.City, searchDoctor.Hospital, searchDoctor.Locality);
                     break;
                 case 7:
                     searchDoctor.Providers = providerRepository.GetProviderByLab(searchDoctor.City, searchDoctor.Lab);
                     break;
                 case 8:
                     searchDoctor.Providers = providerRepository.GetProviderByLabLocality(searchDoctor.City, searchDoctor.Lab, searchDoctor.Locality);
                     break;
                 case 9:
                     searchDoctor.Providers = providerRepository.GetProviderByPharmacist(searchDoctor.City, searchDoctor.Pharmacist);
                     break;
                 case 10:
                     searchDoctor.Providers = providerRepository.GetProviderByPharmacistLocality(searchDoctor.City, searchDoctor.Pharmacist, searchDoctor.Locality);
                     break;
                 case 11:
                     searchDoctor.Providers = providerRepository.GetProviderByNurse(searchDoctor.City, searchDoctor.Nurse);
                     break;
                 case 12:
                     searchDoctor.Providers = providerRepository.GetProviderByNurseLocality(searchDoctor.City, searchDoctor.Nurse, searchDoctor.Locality);
                     break;
                 case 13:
                     searchDoctor.Providers = providerRepository.GetProviderByTreatment(searchDoctor.City, searchDoctor.Treatment);
                     break;
                 case 14:
                     searchDoctor.Providers = providerRepository.GetProviderByTreatmentLocality(searchDoctor.City, searchDoctor.Treatment, searchDoctor.Locality);
                     break;
                 case 15:
                     searchDoctor.Cities = cityRepository.GetCitiesByCountry(searchDoctor.Country);
                     break;
                 case 16:
                     searchDoctor.Localities = localityRepository.GetLocalitiesByCountryCity(searchDoctor.Country,searchDoctor.City);
                     break;
                 default:
                     break;
             }

             return searchDoctor; 
         }
         public AbstractDomainModel GetAll(Core.Enumerations.SearchCriteriaEnum searchCriteria)
         {
             searchDoctor = new DomainModel.Models.DoctorsSearch();
             switch (searchCriteria)
             {
                 case Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES:
                     searchDoctor.Countries = countryRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES:
                     searchDoctor.Specialties = specialtyRepository.GetAll();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_DOCTORS:
                     searchDoctor.Doctors = providerRepository.GetAllDoctors();
                     break;                 
                 case Core.Enumerations.SearchCriteriaEnum.GET_PHARMACISTS:
                     searchDoctor.Pharmacists = providerRepository.GetAllPharmacists();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_NURSE:
                     searchDoctor.Nurses = providerRepository.GetAllNurses();
                     break;
                 case Core.Enumerations.SearchCriteriaEnum.GET_TREATMENTS:
                     searchDoctor.Treatments = treatmentRepository.GetAll();
                     break;
                 default:
                     break;
             }

             return searchDoctor; 
         }
    }
}