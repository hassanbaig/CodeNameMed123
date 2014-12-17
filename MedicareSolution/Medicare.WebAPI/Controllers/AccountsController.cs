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
using Medicare.Core.Common;
using Medicare.Core.Enumerations;
using System.Collections;
using Medicare.Factory.Factories;
using Medicare.DomainModel.Models;
using Medicare.DomainService;
using Medicare.DataModel.Models;

namespace Medicare.WebAPI.Controllers
{
    [Authorize]
    [BreezeController]
    public class AccountsController : BaseController
    {        
        private AbstractDomainModel domainModel;
        private AbstractDomainService domainService;
        
        [AllowAnonymous]
        [HttpGet]
        public string Metadata()
        {
            return base.Metadata;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Logout()
        {
            try
            {
                TicketHelper.Logout(); 
                return Ok("Logout successfully");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Authenticate(string userId, string password)
        {            
            if(userId==null || password==null)
            {
                return Ok("Please check login credentials and then try again.");
            }
            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(Authenticate));
            domainModel.Fill(HashHelper.Authenticate(userId,password));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            domainModel = domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.AUTHENTICATE);
            DomainModel.Models.Authenticate authenticate = (DomainModel.Models.Authenticate)domainModel;
            if (authenticate.ResponseMessage != "User id is required" && authenticate.ResponseMessage != "Password is required" && authenticate.ResponseMessage != "Invalid domain model" && authenticate.ResponseMessage != "Please check login credentials and then try again.")
            {
                UserData userData = new UserData(userId,authenticate.ProviderId.ToString(),"");                
                TicketHelper.CreateAuthCookie(userData.UserId, userData.GetProviderUserData(), false);
            }           
            return Ok(authenticate.ResponseMessage);
        }

        [AllowAnonymous]
        [HttpGet]
        public IQueryable GetSpecialties()
        {            
            FactoryFacade factory = new FactoryFacade();                                
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            return ((DomainModel.Models.ProviderRegistration)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES)).Specialties.AsQueryable();            
        }
        [AllowAnonymous]
        [HttpGet]
        public IQueryable GetCountries()
        {            
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            return ((DomainModel.Models.ProviderRegistration)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES)).Countries.AsQueryable();            
        }
        [AllowAnonymous]
        [HttpGet]
        public IQueryable GetCities()
        {            
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            return ((DomainModel.Models.ProviderRegistration)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_CITIES)).Cities.AsQueryable();            
        }
        [AllowAnonymous]
        [HttpGet]
        public IQueryable GetLocalities()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            return ((DomainModel.Models.ProviderRegistration)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LOCALITIES)).Localities.AsQueryable();            
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult ProviderRegistration(string name, int gender, string phone, string email, string password, string clinicName, long majorSpecialty,int country, long city, long area, string clinicAddress)
        {
            string response = string.Empty;
                FactoryFacade factory = new FactoryFacade();
                ProviderRegistration providerRegistration = null;
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(ProviderRegistration));
                domainModel.Fill(HashHelper.ProviderRegistration(name, gender, phone, email, password, clinicName, majorSpecialty, country, city, area, clinicAddress));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
                providerRegistration = (ProviderRegistration)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PROVIDER_REGISTRATION);

                return Ok(providerRegistration.ResponseMessage);
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult ChangePassword(string currentPassword, string newPassword)
        {
            ChangePassword changePassword = null;
            string data = TicketHelper.GetDecryptedUserId();
            string [] dataList = data.Split(',');
            FactoryFacade factory = new FactoryFacade();

            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(ChangePassword));
            domainModel.Fill(HashHelper.ChangePassword(currentPassword, newPassword, dataList[0]));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            changePassword = (ChangePassword)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.CHANGE_PASSWORD);
            return Ok(changePassword.ResponseMessage);          
        }
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult ForgotPassword(string newPassword,string userId)
        {
            ForgotPassword forgotPassword = null;         
            FactoryFacade factory = new FactoryFacade();

            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(ForgotPassword));
            domainModel.Fill(HashHelper.ForgotPassword(newPassword, userId));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(AccountsDomainService));
            return Ok(((ForgotPassword)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.FORGOT_PASSWORD)).ResponseMessage);            
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