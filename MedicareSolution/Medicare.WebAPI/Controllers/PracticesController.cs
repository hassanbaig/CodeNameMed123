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
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using Medicare.Factory.Factories;
using Medicare.DomainService;
using Medicare.DomainModel.Models;
using Medicare.Core.Common;

namespace Medicare.WebAPI.Controllers
{
    [BreezeController]
    public class PracticesController : BaseController
    {
        private AbstractDomainModel domainModel;
        private AbstractDomainService domainService;

        [HttpGet]
        public string Metadata()
        {
            return base.Metadata;
        }


        //Practice Detail

        [HttpGet]
        public PracticeEditDetails GetPracticeDetails(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            PracticeEditDetails practiceEditDetails = null;

            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),22, 1)); }
                else
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], (long)providerId,22, 1)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_DETAILS)).PracticeInfo;
            }
            return practiceEditDetails;
        }        
        
        [HttpGet]
        public IHttpActionResult AddPracticeDetails(string uploadLogo, string name, string tagLine, string description, int billingCurrency, long type)
        {
            string response = string.Empty;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            PracticeEditDetails practiceEditDetails = null;


            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
            domainModel.Fill(HashHelper.PracticeEditDetailsAddPracticeDetails(1, Convert.ToInt64(dataList[1]), uploadLogo, name, tagLine, description, billingCurrency, type));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            practiceEditDetails = (PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_DETAILS);
            return Ok(practiceEditDetails.ResponseMessage);
        }

         //Currency
        [HttpGet]
        public IQueryable GetPracticeBillingCurrency()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_BILLING_CURRENCY)).BillingCurrency.AsQueryable();
        }

        //PracticeType
    [HttpGet]
        public IQueryable GetPracticeType()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_PRACTICE_TYPE)).PracticeType.AsQueryable();
        }

        //PracticeCountries
        [HttpGet]
        public IQueryable GetCountries()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES)).Countries.AsQueryable();
        }

        //Contacts
        [HttpGet]
        public PracticeEditDetails GetPracticeContacts(long? providerId,long? practiceId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            PracticeEditDetails practiceEditDetails = null;

            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 2)); }
                else
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], (long)providerId, (long)practiceId, 2)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_CONTACTS)).PracticeInfo;

                   }
            return practiceEditDetails;
        }    



        [HttpGet]
        public IHttpActionResult AddPracticeLocation(string streetAddress, string landmark, string locality, string city, string state, string zipcode, int countryId)
        {
            string response = string.Empty;

            response = "Location added successfully";

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult AddPracticeContacts(string primaryPhone, string primaryEmailId, string websiteAddress, string secondaryPhone, string secondaryEmailId)
        {
            string response = string.Empty;
            response = "Contacts added successfully";
            return Ok(response);
        }

                      
   
        //Timing

        [HttpGet]
        public IHttpActionResult AddPracticeTimings(long providerId, bool monday = true, string monOpenHour1 = "", string monOpenMinute1 = "", string monCloseHours1 = "", string monCloseMinutes1 = "",
                                                        string monOpenHour2 = "", string monOpenMinute2 = "", string monCloseHours2 = "", string monCloseMinutes2 = "",
                                                            bool tuesday = true, string tueOpenHour1 = "", string tueOpenMinute1 = "", string tueCloseHours1 = "", string tueCloseMinutes1 = "",
                                                                string tueOpenHour2 = "", string tueOpenMinute2 = "", string tueCloseHours2 = "", string tueCloseMinutes2 = "",
                                                                    bool wednesday = true, string wedOpenHour1 = "", string wedOpenMinute1 = "", string wedCloseHours1 = "", string wedCloseMinutes1 = "",
                                                                        string wedOpenHour2 = "", string wedOpenMinute2 = "", string wedCloseHours2 = "", string wedCloseMinutes2 = "",
                                                                            bool thursday = true, string thuOpenHour1 = "", string thuOpenMinute1 = "", string thuCloseHours1 = "", string thuCloseMinutes1 = "",
                                                                                string thuOpenHour2 = "", string thuOpenMinute2 = "", string thuCloseHours2 = "", string thuCloseMinutes2 = "",
                                                                                    bool friday = true, string friOpenHour1 = "", string friOpenMinute1 = "", string friCloseHours1 = "", string friCloseMinutes1 = "",
                                                                                        string friOpenHour2 = "", string friOpenMinute2 = "", string friCloseHours2 = "", string friCloseMinutes2 = "",
                                                                                            bool saturday = true, string satOpenHour1 = "", string satOpenMinute1 = "", string satCloseHours1 = "", string satCloseMinutes1 = "",
                                                                                                string satOpenHour2 = "", string satOpenMinute2 = "", string satCloseHours2 = "", string satCloseMinutes2 = "",
                                                                                                    bool sunday = true, string sunOpenHour1 = "", string sunOpenMinute1 = "", string sunCloseHours1 = "", string sunCloseMinutes1 = "",
                                                                                                        string sunOpenHour2 = "", string sunOpenMinute2 = "", string sunCloseHours2 = "", string sunCloseMinutes2 = "")
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
            if (providerId == 0)
            {
                domainModel.Fill(HashHelper.PracticeEditDetailsAddPracticeTimings(14, dataList[0], Convert.ToInt64(dataList[1]),
                                                        monday, monOpenHour1, monOpenMinute1, monCloseHours1, monCloseMinutes1,
                                                            monOpenHour2, monOpenMinute2, monCloseHours2, monCloseMinutes2,
                                                                tuesday, tueOpenHour1, tueOpenMinute1, tueCloseHours1, tueCloseMinutes1,
                                                                    tueOpenHour2, tueOpenMinute2, tueCloseHours2, tueCloseMinutes2,
                                                                        wednesday, wedOpenHour1, wedOpenMinute1, wedCloseHours1, wedCloseMinutes1,
                                                                            wedOpenHour2, wedOpenMinute2, wedCloseHours2, wedCloseMinutes2,
                                                                                thursday, thuOpenHour1, thuOpenMinute1, thuCloseHours1, thuCloseMinutes1,
                                                                                    thuOpenHour2, thuOpenMinute2, thuCloseHours2, thuCloseMinutes2,
                                                                                        friday, friOpenHour1, friOpenMinute1, friCloseHours1, friCloseMinutes1,
                                                                                            friOpenHour2, friOpenMinute2, friCloseHours2, friCloseMinutes2,
                                                                                                saturday, satOpenHour1, satOpenMinute1, satCloseHours1, satCloseMinutes1,
                                                                                                    satOpenHour2, satOpenMinute2, satCloseHours2, satCloseMinutes2,
                                                                                                        sunday, sunOpenHour1, sunOpenMinute1, sunCloseHours1, sunCloseMinutes1,
                                                                                                            sunOpenHour2, sunOpenMinute2, sunCloseHours2, sunCloseMinutes2));
            }
            else
            {
                domainModel.Fill(HashHelper.PracticeEditDetailsAddPracticeTimings(14, dataList[0], (long)providerId, 
                                                        monday, monOpenHour1, monOpenMinute1, monCloseHours1, monCloseMinutes1,
                                                            monOpenHour2, monOpenMinute2, monCloseHours2, monCloseMinutes2,
                                                                tuesday, tueOpenHour1, tueOpenMinute1, tueCloseHours1, tueCloseMinutes1,
                                                                    tueOpenHour2, tueOpenMinute2, tueCloseHours2, tueCloseMinutes2,
                                                                        wednesday, wedOpenHour1, wedOpenMinute1, wedCloseHours1, wedCloseMinutes1,
                                                                            wedOpenHour2, wedOpenMinute2, wedCloseHours2, wedCloseMinutes2,
                                                                                thursday, thuOpenHour1, thuOpenMinute1, thuCloseHours1, thuCloseMinutes1,
                                                                                    thuOpenHour2, thuOpenMinute2, thuCloseHours2, thuCloseMinutes2,
                                                                                        friday, friOpenHour1, friOpenMinute1, friCloseHours1, friCloseMinutes1,
                                                                                            friOpenHour2, friOpenMinute2, friCloseHours2, friCloseMinutes2,
                                                                                                saturday, satOpenHour1, satOpenMinute1, satCloseHours1, satCloseMinutes1,
                                                                                                    satOpenHour2, satOpenMinute2, satCloseHours2, satCloseMinutes2,
                                                                                                        sunday, sunOpenHour1, sunOpenMinute1, sunCloseHours1, sunCloseMinutes1,
                                                                                                            sunOpenHour2, sunOpenMinute2, sunCloseHours2, sunCloseMinutes2));
            }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_TIMINGS);
            return Ok(practiceEditDetails.ResponseMessage);
        }

       [HttpGet]
        public PracticeEditDetails GetPracticeTimings(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            PracticeEditDetails practiceEditDetails = null;
             if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 3)); }
                else
                { domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], (long)providerId,6, 3)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_TIMINGS)).PracticeInfo;
            }
             return practiceEditDetails;
        }     

        //Services Methods
        [HttpGet]
        public IQueryable GetServices()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SERVICES)).Services.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetAddedServices()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 9));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_SERVICES)).AddedServices.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticeServices(string title)
        {
            if (title != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddServices(14, dataList[0], Convert.ToInt64(dataList[1]), title, 1));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_SERVICES)).Services.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SERVICES)).Services.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToPracticeServices(long serviceId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToServices(12, datalist[0], Convert.ToInt64(datalist[1]), serviceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_SERVICES);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        //Delete
        [HttpGet]
        public IHttpActionResult RemovePracticeServices(long serviceId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromServices(15, dataList[0], Convert.ToInt64(dataList[1]), serviceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_SERVICES);
            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        //Travel Services Methods
        [HttpGet]
        public IQueryable GetTravelServices()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_TRAVEL_SERVICES)).TravelServices.AsQueryable();

            // return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SERVICES)).Services.AsQueryable();
        }


        [HttpGet]
        public IQueryable GetAddedTravelServices()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 10));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_TRAVEL_SERVICES)).AddedTravelServices.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticeTravelServices(string title)
        {
            if (title != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddTravelServices(15, dataList[0], Convert.ToInt64(dataList[1]), title, 2));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TRAVEL_SERVICES)).TravelServices.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_TRAVEL_SERVICES)).TravelServices.AsQueryable();
            }
            return null;
        }


        [HttpGet]
        public IHttpActionResult AddToPracticeTravelServices(long serviceId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToTravelServices(13, datalist[0], Convert.ToInt64(datalist[1]), serviceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_TRAVEL_SERVICES);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IHttpActionResult RemovePracticeTravelServices(long travelserviceId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromTravelServices(16, dataList[0], Convert.ToInt64(dataList[1]), travelserviceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_TRAVEL_SERVICES);
            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        //premises methods
        [HttpGet]
        public IQueryable GetPremises()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_PREMISES)).Premises.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetAddedPremises()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 6));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_PREMISES)).AddedPremises.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticePremises(string name)
        {
            if (name != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddPremises(9, dataList[0], Convert.ToInt64(dataList[1]), name));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_PREMISES)).Premises.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_PREMISES)).Premises.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToPracticePremises(long premisesId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToPremises(9, datalist[0], Convert.ToInt64(datalist[1]), premisesId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_PREMISES);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IHttpActionResult RemovePracticePremises(long premisesId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromPremises(10, dataList[0], Convert.ToInt64(dataList[1]), premisesId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_PREMISES);
            }
            return Ok(practiceEditDetails.ResponseMessage);

        }

        //Practices Pagee Method Language
        [HttpGet]
        public IQueryable GetLanguages()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES)).Languages.AsQueryable();
        }
        [HttpGet]
        public IQueryable GetAddedLanguages()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 5));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_LANGUAGES)).AddedLanguages.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticeLanguages(string name)
        {
            if (name != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddLanguages(7, dataList[0], Convert.ToInt64(dataList[1]), name));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_LANGUAGES)).Languages.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES)).Languages.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToPracticeLanguages(long languageId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToLanguages(8, datalist[0], Convert.ToInt64(datalist[1]), languageId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_LANGUAGES);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IHttpActionResult RemovePracticeLanguages(long languageId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromLanguages(8, dataList[0], Convert.ToInt64(dataList[1]), languageId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_LANGUAGES);
            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        // Accerrdiation Start

        [HttpGet]
        public IQueryable GetAccreditations()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_ACCREDITATIONS)).Accreditations.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetAddedAccreditations()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 7));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_ACCREDITATIONS)).AddedAccreditations.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticeAccreditations(string title)
        {
            if (title != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddAccreditations(12, dataList[0], Convert.ToInt64(dataList[1]), title));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_ACCREDITATIONS)).Accreditations.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_ACCREDITATIONS)).Accreditations.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToPracticeAccreditations(long accreditationId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToAccreditations(10, datalist[0], Convert.ToInt64(datalist[1]), accreditationId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_ACCREDITATIONS);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IHttpActionResult RemovePracticeAccreditations(long accreditationId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromAccreditations(12, dataList[0], Convert.ToInt64(dataList[1]), accreditationId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_ACCREDITATIONS);
            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        // Insurance Start

        [HttpGet]
        public IQueryable GetInsurances()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
            return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_INSURANCES)).Insurances.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetAddedInsurances()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]),6, 8));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_GET_ADDED_INSURANCES)).AddedInsurances.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddPracticeInsurances(string title)
        {
            if (title != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                    domainModel.Fill(HashHelper.PracticeEditDetailsAddInsurances(13, dataList[0], Convert.ToInt64(dataList[1]), title));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                    return ((DomainModel.Models.PracticeEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_INSURANCES)).Insurances.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                return ((DomainModel.Models.PracticeEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_INSURANCES)).Insurances.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToPracticeInsurances(long insuranceId)
        {
            PracticeEditDetails practiceEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] datalist = data.Split(',');
            if (data != null)
            {

                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsAddToInsurances(11, datalist[0], Convert.ToInt64(datalist[1]), insuranceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_ADD_TO_INSURANCES);

            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IHttpActionResult RemovePracticeInsurances(long insuranceId)
        {
            PracticeEditDetails practiceEditDetails = new PracticeEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(PracticeEditDetails));
                domainModel.Fill(HashHelper.PracticeEditDetailsRemoveFromInsurances(14, dataList[0], Convert.ToInt64(dataList[1]), insuranceId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(PracticesDomainService));
                practiceEditDetails = (PracticeEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PRACTICE_EDIT_DETAILS_REMOVE_FROM_INSURANCES);
            }
            return Ok(practiceEditDetails.ResponseMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {                //db.Dispose();            }
                base.Dispose(disposing);
            }

            //private bool UserExists(string id)
            //{
            //    return db.User.Count(e => e.UserId == id) > 0;
            //}
        }
    }
}