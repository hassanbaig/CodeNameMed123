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
using Medicare.Factory.Factories;
using Medicare.Core.Common;
using Medicare.DomainModel.Models;
using Medicare.DomainService;

namespace Medicare.WebAPI.Controllers
{
    //[Authorize]
    [BreezeController]
    public class StaffController : BaseController
    {
        private AbstractDomainModel domainModel;
        private AbstractDomainService domainService;

        //[AllowAnonymous]
        [HttpGet]
        public string Metadata()
        {
            return base.Metadata;
        }
                
        [HttpGet]
        public IHttpActionResult EditProfile(string firstName,string lastName, int gender, string dob, string bloodGroup, string timeZone, string mobileNumber, string extraPhoneNumber,
                                                string streetAddress, int countryId, int stateId, long cityId, long localityId, int zipCode)
        {
            EditProfile editProfile = null;            
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            FactoryFacade factory = new FactoryFacade();

            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(EditProfile));
            domainModel.Fill(HashHelper.EditProfile(dataList[0], Convert.ToInt64(data[1]),firstName,lastName, gender, dob, bloodGroup, timeZone, mobileNumber, extraPhoneNumber, streetAddress, countryId, stateId, cityId, localityId, zipCode));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            editProfile = (EditProfile)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.EDIT_PROFILE);
            return Ok(editProfile.ResponseMessage);
        }

        [HttpGet]
        public IQueryable GetRegistrationCouncils()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_REGISTRATION_COUNCILS)).RegistrationCouncils.AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult AddDoctorDetails(string doctorName, int? gender, int? year, long? registrationCouncilId,
                                                    int? numberOfYears, long? providerId, string registrationDetails="", string doctorTagLine="", string doctorDescription="")
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            {
                domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorDetails(1, dataList[0], Convert.ToInt64(dataList[1]), doctorName, gender, registrationDetails, year, registrationCouncilId,
                   numberOfYears, doctorTagLine, doctorDescription));
            }
            else
            {
                domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorDetails(1, dataList[0], (long)providerId, doctorName, gender, registrationDetails, year, registrationCouncilId,
                    numberOfYears, doctorTagLine, doctorDescription));
            }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return Ok(((DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_DETAILS)).ResponseMessage);            
        }

        [HttpGet]
        public DoctorEditDetails GetDoctorDetails(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            DoctorEditDetails doctorEditDetails = null;
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], Convert.ToInt64(dataList[1]), 1)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], (long)providerId, 1)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_DETAILS)).DoctorInfo;
            }
            return doctorEditDetails;
        }        

        [HttpGet]
        public IHttpActionResult AddDoctorContacts(string primaryPhone, string primaryEmailId, long? providerId, string websiteAddress="", string secondaryPhone="", string secondaryEmailId="")
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorContacts(2, dataList[0], Convert.ToInt64(dataList[1]), primaryPhone, primaryEmailId, websiteAddress, secondaryPhone, secondaryEmailId)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorContacts(2, dataList[0], (long)providerId, primaryPhone, primaryEmailId, websiteAddress, secondaryPhone, secondaryEmailId)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONTACTS);
            return Ok(doctorEditDetails.ResponseMessage);
        }

        [HttpGet]
        public DoctorEditDetails GetDoctorContacts(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            DoctorEditDetails doctorEditDetails = null;
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], Convert.ToInt64(dataList[1]), 2)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], (long)providerId, 2)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONTACTS)).DoctorInfo;
            }
            return doctorEditDetails;
        }        

        [HttpGet]
        public IHttpActionResult AddDoctorConsultation(int consultationFee, int consultationDuration, long providerId, bool monday = true, string monOpenHour1 = "", string monOpenMinute1 = "", string monCloseHours1 = "", string monCloseMinutes1 = "",
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
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            {
                domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorConsultation(3, dataList[0], Convert.ToInt64(dataList[1]), consultationFee, consultationDuration,
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
                domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorConsultation(3, dataList[0], (long)providerId, consultationFee, consultationDuration,
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
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_CONSULTATION);
            return Ok(doctorEditDetails.ResponseMessage);
        }

        [HttpGet]
        public DoctorEditDetails GetDoctorConsultation(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            DoctorEditDetails doctorEditDetails = null;
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], Convert.ToInt64(dataList[1]), 3)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetDoctorInfo(dataList[0], (long)providerId, 3)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_CONSULTATION)).DoctorInfo;
            }
            return doctorEditDetails;
        }        

        //[AllowAnonymous]
        [HttpGet]
        public EditProfile GetProfileDetails()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            EditProfile profile = null;
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(EditProfile));
                domainModel.Fill(HashHelper.ProfileDetails(dataList[0], Convert.ToInt64(dataList[1])));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                profile= ((DomainModel.Models.EditProfile)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.PROFILE_DETAILS)).ProfileDetails;
            }
            return profile;
        }

        //[AllowAnonymous]
        [HttpGet]
        public IQueryable GetCountries()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.EditProfile)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_COUNTRIES)).Countries.AsQueryable();
        }
        //[AllowAnonymous]
        [HttpGet]
        public IQueryable GetStates()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.EditProfile)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_STATES)).States.AsQueryable();
        }
        //[AllowAnonymous]
        [HttpGet]
        public IQueryable GetCities()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.EditProfile)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_CITIES)).Cities.AsQueryable();
        }
        //[AllowAnonymous]
        [HttpGet]
        public IQueryable GetLocalities()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.EditProfile)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LOCALITIES)).Localities.AsQueryable();
        }
        
        [HttpGet]
        public IQueryable GetSpecializations()
        {          
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES)).Specialties.AsQueryable();        
        }        

        [HttpGet]
        public IQueryable GetAddedSpecializations(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 4)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 4)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_SPECIALIZATIONS)).AddedSpecialties.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddDoctorSpecializations(string name)
        {
            if (name != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                    domainModel.Fill(HashHelper.DoctorEditDetailsAddSpecializations(4, dataList[0], Convert.ToInt64(dataList[1]), name));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                    return ((DomainModel.Models.DoctorEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_SPECIALIZATIONS)).Specialties.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_SPECIALTIES)).Specialties.AsQueryable();        
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddToDoctorSpecializations(long specialtyId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if(data != null)
            { 
            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddToSpecializations(5, dataList[0], Convert.ToInt64(dataList[1]), specialtyId)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddToSpecializations(5, dataList[0], (long)providerId, specialtyId)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_SPECIALIZATIONS);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }        

        [HttpGet]
        public IHttpActionResult RemoveDoctorSpecializations(long specialtyId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = new DoctorEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromSpecializations(6, dataList[0], Convert.ToInt64(dataList[1]), specialtyId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromSpecializations(6, dataList[0], (long)providerId, specialtyId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_SPECIALIZATIONS);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IQueryable GetLanguages()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES)).Languages.AsQueryable();        
        }
        [HttpGet]
        public IQueryable GetAddedLanguages(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 5)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 5)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_LANGUAGES)).AddedLanguages.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IQueryable AddDoctorLanguages(string name)
        {
            if (name != null)
            {
                FactoryFacade factory = new FactoryFacade();
                string data = TicketHelper.GetDecryptedUserId();
                if (data != null)
                {
                    string[] dataList = data.Split(',');

                    domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                    domainModel.Fill(HashHelper.DoctorEditDetailsAddLanguages(7, dataList[0], Convert.ToInt64(dataList[1]), name));
                    domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                    return ((DomainModel.Models.DoctorEditDetails)domainService.Save(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_LANGUAGES)).Languages.AsQueryable();
                }
            }
            else
            {
                FactoryFacade factory = new FactoryFacade();
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_LANGUAGES)).Languages.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IHttpActionResult AddToDoctorLanguages(long languageId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsAddToLanguages(8, dataList[0], Convert.ToInt64(dataList[1]), languageId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsAddToLanguages(8, dataList[0], (long)providerId, languageId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TO_LANGUAGES);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }        

        [HttpGet]
        public IHttpActionResult RemoveDoctorLanguages(long languageId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = new DoctorEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromLanguages(9, dataList[0], Convert.ToInt64(dataList[1]), languageId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromLanguages(9, dataList[0], (long)providerId, languageId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_LANGUAGES);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }

        [HttpGet]
        public IQueryable GetTreatments()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_TREATMENTS)).Treatments.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetParentTreatments()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_PARENT_TREATMENTS)).ParentTreatments.AsQueryable();
        }

        [HttpGet]
        public IQueryable GetAddedTreatments(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 6)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 6)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_TREATMENTS)).AddedTreatments.AsQueryable();
            }
            return null;
        }

        [HttpGet]
        public IHttpActionResult AddDoctorTreatments(string treatmentName, int? treatmentCost, int? tax, long? subcatecogyOf, long? providerId, string notes="")
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorTreatments(10, dataList[0], Convert.ToInt64(dataList[1]), treatmentName, treatmentCost, tax, subcatecogyOf, notes)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorTreatments(10, dataList[0], (long)providerId, treatmentName, treatmentCost, tax, subcatecogyOf, notes)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_TREATMENTS);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult EditDoctorTreatments(long treatmentId, string treatmentName, int treatmentCost, int tax, long subcatecogyOf, string notes)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            domainModel.Fill(HashHelper.DoctorEditDetailsEditDoctorTreatments(11, dataList[0], Convert.ToInt64(dataList[1]), treatmentId, treatmentName, treatmentCost, tax, subcatecogyOf, notes));
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_EDIT_TREATMENTS);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult RemoveDoctorTreatments(long treatmentId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = new DoctorEditDetails();
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromTreatments(12, dataList[0], Convert.ToInt64(dataList[1]), treatmentId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromTreatments(12, dataList[0], (long)providerId, treatmentId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_TREATMENTS);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IQueryable GetAddedEducation(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 7)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 7)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EDUCATION)).AddedEducation.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IHttpActionResult AddDoctorEducation(string degreeTitle, int? degreeYear, long? providerId, string schoolTitle = "")
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorEducation(12, dataList[0], Convert.ToInt64(dataList[1]), degreeTitle, degreeYear, schoolTitle)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorEducation(12, dataList[0], (long)providerId, degreeTitle, degreeYear, schoolTitle)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EDUCATION);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult RemoveDoctorEducation(string degreeTitle, string schoolTitle, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromEducation(13, dataList[0], Convert.ToInt64(dataList[1]), degreeTitle, schoolTitle)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromEducation(13, dataList[0], (long)providerId, degreeTitle, schoolTitle)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EDUCATION);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IQueryable GetAddedExperience(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 8)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 8)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_EXPERIENCE)).AddedExperience.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IHttpActionResult AddDoctorExperience(long? cityId, int? startYear, int? endYear, long? providerId, string designation="", string organization="")
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorExperience(13, dataList[0], Convert.ToInt64(dataList[1]), cityId, startYear, endYear, designation, organization)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorExperience(13, dataList[0], (long)providerId, cityId, startYear, endYear, designation, organization)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_EXPERIENCE);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult RemoveDoctorExperience(string designation, string organization, long cityId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromExperience(14, dataList[0], Convert.ToInt64(dataList[1]), designation, organization, cityId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromExperience(14, dataList[0], (long)providerId, designation, organization, cityId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_EXPERIENCE);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult AddDoctorAffiliations(long affiliationId,int? year, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorAffiliation(14, dataList[0], Convert.ToInt64(dataList[1]), affiliationId, year)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorAffiliation(14, dataList[0], (long)providerId, affiliationId, year)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AFFILIATION);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult RemoveDoctorAffiliations(long affiliationId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromAffiliation(15, dataList[0], Convert.ToInt64(dataList[1]), affiliationId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromAffiliation(15, dataList[0], (long)providerId, affiliationId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AFFILIATION);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult AddDoctorAwards(long awardId, int? year, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');

            FactoryFacade factory = new FactoryFacade();
            domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
            if (providerId == 0)
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorAward(15, dataList[0], Convert.ToInt64(dataList[1]), awardId, year)); }
            else
            { domainModel.Fill(HashHelper.DoctorEditDetailsAddDoctorAward(15, dataList[0], (long)providerId, awardId, year)); }
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            doctorEditDetails = (DoctorEditDetails)domainService.Update(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_ADD_AWARD);
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IHttpActionResult RemoveDoctorAwards(long awardId, long? providerId)
        {
            DoctorEditDetails doctorEditDetails = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromAward(16, dataList[0], Convert.ToInt64(dataList[1]), awardId)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsRemoveFromAward(16, dataList[0], (long)providerId, awardId)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                doctorEditDetails = (DoctorEditDetails)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_REMOVE_FROM_AWARD);
            }
            return Ok(doctorEditDetails.ResponseMessage);
        }
        [HttpGet]
        public IQueryable GetAddedAffiliations(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 9)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 9)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AFFILIATIONS)).AddedAffiliations.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IQueryable GetAddedAwards(long? providerId)
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');

                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(DoctorEditDetails));
                if (providerId == 0)
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], Convert.ToInt64(dataList[1]), 10)); }
                else
                { domainModel.Fill(HashHelper.DoctorEditDetailsGetAddedInfo(dataList[0], (long)providerId, 10)); }
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.DoctorEditDetails)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.DOCTOR_EDIT_DETAILS_GET_ADDED_AWARDS)).AddedAwards.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IQueryable GetDegrees()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_DEGREES)).Degrees.AsQueryable();
        }
        [HttpGet]
        public IQueryable GetColleges()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_COLLEGES)).Colleges.AsQueryable();
        }
        [HttpGet]
        public IQueryable GetAffiliations()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_AFFILIATIONS)).Affiliations.AsQueryable();
        }
        [HttpGet]
        public IQueryable GetAwards()
        {
            FactoryFacade factory = new FactoryFacade();
            domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
            return ((DomainModel.Models.DoctorEditDetails)domainService.Query(Medicare.Core.Enumerations.SearchCriteriaEnum.GET_AWARDS)).Awards.AsQueryable();
        }
        [HttpGet]
        public IQueryable GetAllDoctorsByProviderPractice()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(Staff));
                domainModel.Fill(HashHelper.GetAllDoctorsByProviderPractice(dataList[0], Convert.ToInt64(dataList[1]), 11));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.Staff)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_DOCTORS)).PracticeDoctors.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IQueryable GetAllStaffByProviderPractice()
        {
            FactoryFacade factory = new FactoryFacade();
            string data = TicketHelper.GetDecryptedUserId();
            if (data != null)
            {
                string[] dataList = data.Split(',');
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(Staff));
                domainModel.Fill(HashHelper.GetAllDoctorsByProviderPractice(dataList[0], Convert.ToInt64(dataList[1]), 12));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                return ((DomainModel.Models.Staff)domainService.Query(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.STAFF_GET_ADDED_PRACTICE_STAFF)).PracticeStaff.AsQueryable();
            }
            return null;
        }
        [HttpGet]
        public IHttpActionResult RemoveProvider(long providerId)
        {
            Staff staff = null;
            string data = TicketHelper.GetDecryptedUserId();
            string[] dataList = data.Split(',');
            if (data != null)
            {
                FactoryFacade factory = new FactoryFacade();
                domainModel = factory.DomainModelFactory.CreateDomainModel(typeof(Staff));
                domainModel.Fill(HashHelper.StaffRemoveFromProviders(17, dataList[0], Convert.ToInt64(dataList[1]), providerId));
                domainService = factory.DomainServiceFactory.CreateDomainService(typeof(StaffDomainService));
                staff = (Staff)domainService.Delete(domainModel, Medicare.Factory.Enumerations.DomainModelEnum.STAFF_REMOVE_FROM_PROVIDERS);
            }
            return Ok(staff.ResponseMessage);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}