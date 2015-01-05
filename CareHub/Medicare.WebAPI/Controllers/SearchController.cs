using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using Breeze.WebApi2;
using CareHub.Core.Common;
using CareHub.Core.Enumerations;
using System.Collections;
using CareHub.Factory.Factories;
using CareHub.DomainModel.Models;
using CareHub.DomainService;
using CareHub.DataModel.Models;

namespace CareHub.WebAPI.Controllers
{ 
    [BreezeController]
    public class SearchController : BaseController
    {        
        private AbstractDomainModel domainModel;
        private AbstractDomainService domainService;
               
        [HttpGet]
        public string Metadata()
        {
            return base.Metadata;
        }
      
        [HttpGet]
        public IQueryable SearchProvider(long city, string locality, string specialty, string doctor, string hospital, string lab, string pharmacist, string nurse, string treatment, int searchType)
        {
            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorsSearch));
            domainModel.Fill(HashHelper.SearchDoctor(city, locality, specialty, doctor, hospital, lab, pharmacist, nurse, treatment, searchType));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            domainModel = domainService.Query(domainModel, CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH);
            return ((DomainModel.Models.DoctorsSearch)domainModel).Providers.AsQueryable();            
        }

         [HttpGet]
        public IQueryable SearchPractice(long city, string locality, string hospital, string lab, int searchType)
        {
            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticesSearch));
            domainModel.Fill(HashHelper.SearchPractice(city, locality, hospital, lab, searchType));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesSearchDomainService));
            domainModel = domainService.Query(domainModel, CareHub.Factory.Enumerations.DomainModelEnum.PRACTICE_SEARCH);
            return ((DomainModel.Models.PracticesSearch)domainModel).Practices.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetCountries()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES)).Countries.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetSpecialties()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES)).Specialties.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetDoctors()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_DOCTORS)).Doctors.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetHospitals()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesSearchDomainService));
            return ((DomainModel.Models.PracticesSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_HOSPITALS)).Hospitals.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetLabs()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesSearchDomainService));
            return ((DomainModel.Models.PracticesSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_LABS)).Labs.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetPharmacists()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_PHARMACISTS)).Pharmacists.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetNurse()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_NURSE)).Nurses.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetTreatments()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            return ((DomainModel.Models.DoctorsSearch)domainService.Query(CareHub.Core.Enumerations.SearchCriteriaEnum.GET_TREATMENTS)).Treatments.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetCities(int country, int searchType)
        {
            FactoryFacade factory = new FactoryFacade();            
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorsSearch));
            domainModel.Fill(HashHelper.GetCitiesByCountry(country,searchType));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            domainModel = domainService.Query(domainModel, CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH);
            return ((DomainModel.Models.DoctorsSearch)domainModel).Cities.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetLocalities(int country, long city, int searchType)
        {
            FactoryFacade factory = new FactoryFacade();            
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorsSearch));
            domainModel.Fill(HashHelper.GetLocalitiesByCountryCity(country,city, searchType));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(DoctorsSearchDomainService));
            domainModel = domainService.Query(domainModel, CareHub.Factory.Enumerations.DomainModelEnum.DOCTOR_SEARCH);
            return ((DomainModel.Models.DoctorsSearch)domainModel).Localities.AsQueryable();
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        //private bool UserExists(string id)
        //{
        //    return db.User.Count(e => e.UserId == id) > 0;
        //}
    }
}