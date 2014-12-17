﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Factory.Factories;
using System.Reflection;
namespace Medicare.DomainModel.Models
{
    public class PracticeEditDetails:AbstractDomainModel
    {
        public PracticeEditDetails()
        {
            
        }

        #region Properties    

        public int OperationType { get; set; }
        public string UserId { get; set; }
        public long PracticeId { get; set; }
        public long ProviderId { get; set; }
        public string PracticeDetailsLogoPath { get; set; }
        public string PracticeDetailsPracticeName { get; set; }
        public string PracticeDetailsPracticeTagline { get; set; }
        public string PracticeDetailsPracticeDescription { get; set; }
        public int PracticeDetailsBillingCurrency { get; set; }
        public long PracticeDetailsPracticeType { get; set; }
        public string PracticeLocationStreetAddress { get; set; }
        public string PracticeLocationLandmark { get; set; }
        public string PracticeLocationLocality { get; set; }
        public string PracticeLocationCity { get; set; }
        public string PracticeLocationState { get; set; }
        public string PracticeLocationZipCode { get; set; }
        public string PracticeLocationCountry { get; set; }
        public string PracticeContactsPrimaryPhone { get; set; }
        public string PracticeContactsSecondaryPhone { get; set; }
        public string PracticeContactsPrimaryEmail { get; set; }
        public string PracticeContactsSecondaryEmail { get; set; }
        //public bool Monday {get;set;}
        //public string MonOpenHour1 { get; set; }
        //public string MonOpenMinute1 { get; set; }
        //public string MonCloseHour1 { get; set; }
        //public string MonCloseMinute1 { get; set; }
        //public string MonOpenHour2 { get; set; }
        //public string MonOpenMinute2 { get; set; }
        //public string MonCloseHour2 { get; set; }
        //public string MonCloseMinute2 { get; set; }
        //public bool Tuesday {get;set;}
        //public string TueOpenHour1 { get; set; }
        //public string TueOpenMinute1 { get; set; }
        //public string TueCloseHour1 { get; set; }
        //public string TueCloseMinute1 { get; set; }
        //public string TueOpenHour2 { get; set; }
        //public string TueOpenMinute2 { get; set; }
        //public string TueCloseHour2 { get; set; }
        //public string TueCloseMinute2 { get; set; }
        //public bool Wednesday {get;set;}
        //public string WedOpenHour1 { get; set; }
        //public string WedOpenMinute1 { get; set; }
        //public string WedCloseHour1 { get; set; }
        //public string WedCloseMinute1 { get; set; }
        //public string WedOpenHour2 { get; set; }
        //public string WedOpenMinute2 { get; set; }
        //public string WedCloseHour2 { get; set; }
        //public string WedCloseMinute2 { get; set; }
        //public bool Thursday {get;set;}
        //public string ThuOpenHour1 { get; set; }
        //public string ThuOpenMinute1 { get; set; }
        //public string ThuCloseHour1 { get; set; }
        //public string ThuCloseMinute1 { get; set; }
        //public string ThuOpenHour2 { get; set; }
        //public string ThuOpenMinute2 { get; set; }
        //public string ThuCloseHour2 { get; set; }
        //public string ThuCloseMinute2 { get; set; }
        //public bool Friday {get;set;}
        //public string FriOpenHour1 { get; set; }
        //public string FriOpenMinute1 { get; set; }
        //public string FriCloseHour1 { get; set; }
        //public string FriCloseMinute1 { get; set; }
        //public string FriOpenHour2 { get; set; }
        //public string FriOpenMinute2 { get; set; }
        //public string FriCloseHour2 { get; set; }
        //public string FriCloseMinute2 { get; set; }
        //public bool Saturday {get;set;}
        //public string SatOpenHour1 { get; set; }
        //public string SatOpenMinute1 { get; set; }
        //public string SatCloseHour1 { get; set; }
        //public string SatCloseMinute1 { get; set; }
        //public string SatOpenHour2 { get; set; }
        //public string SatOpenMinute2 { get; set; }
        //public string SatCloseHour2 { get; set; }
        //public string SatCloseMinute2 { get; set; }
        //public bool Sunday {get;set;}
        //public string SunOpenHour1 { get; set; }
        //public string SunOpenMinute1 { get; set; }
        //public string SunCloseHour1 { get; set; }
        //public string SunCloseMinute1 { get; set; }
        //public string SunOpenHour2 { get; set; }
        //public string SunOpenMinute2 { get; set; }
        //public string SunCloseHour2 { get; set; }
        //public string SunCloseMinute2 { get; set; }     
                

        //Timings
        public bool Monday { get; set; }
        public string MonOpenHour1 { get; set; }
        public string MonOpenMinute1 { get; set; }
        public string MonCloseHour1 { get; set; }
        public string MonCloseMinute1 { get; set; }
        public string MonOpenHour2 { get; set; }
        public string MonOpenMinute2 { get; set; }
        public string MonCloseHour2 { get; set; }
        public string MonCloseMinute2 { get; set; }
        public bool Tuesday { get; set; }
        public string TueOpenHour1 { get; set; }
        public string TueOpenMinute1 { get; set; }
        public string TueCloseHour1 { get; set; }
        public string TueCloseMinute1 { get; set; }
        public string TueOpenHour2 { get; set; }
        public string TueOpenMinute2 { get; set; }
        public string TueCloseHour2 { get; set; }
        public string TueCloseMinute2 { get; set; }
        public bool Wednesday { get; set; }
        public string WedOpenHour1 { get; set; }
        public string WedOpenMinute1 { get; set; }
        public string WedCloseHour1 { get; set; }
        public string WedCloseMinute1 { get; set; }
        public string WedOpenHour2 { get; set; }
        public string WedOpenMinute2 { get; set; }
        public string WedCloseHour2 { get; set; }
        public string WedCloseMinute2 { get; set; }
        public bool Thursday { get; set; }
        public string ThuOpenHour1 { get; set; }
        public string ThuOpenMinute1 { get; set; }
        public string ThuCloseHour1 { get; set; }
        public string ThuCloseMinute1 { get; set; }
        public string ThuOpenHour2 { get; set; }
        public string ThuOpenMinute2 { get; set; }
        public string ThuCloseHour2 { get; set; }
        public string ThuCloseMinute2 { get; set; }
        public bool Friday { get; set; }
        public string FriOpenHour1 { get; set; }
        public string FriOpenMinute1 { get; set; }
        public string FriCloseHour1 { get; set; }
        public string FriCloseMinute1 { get; set; }
        public string FriOpenHour2 { get; set; }
        public string FriOpenMinute2 { get; set; }
        public string FriCloseHour2 { get; set; }
        public string FriCloseMinute2 { get; set; }
        public bool Saturday { get; set; }
        public string SatOpenHour1 { get; set; }
        public string SatOpenMinute1 { get; set; }
        public string SatCloseHour1 { get; set; }
        public string SatCloseMinute1 { get; set; }
        public string SatOpenHour2 { get; set; }
        public string SatOpenMinute2 { get; set; }
        public string SatCloseHour2 { get; set; }
        public string SatCloseMinute2 { get; set; }
        public bool Sunday { get; set; }
        public string SunOpenHour1 { get; set; }
        public string SunOpenMinute1 { get; set; }
        public string SunCloseHour1 { get; set; }
        public string SunCloseMinute1 { get; set; }
        public string SunOpenHour2 { get; set; }
        public string SunOpenMinute2 { get; set; }
        public string SunCloseHour2 { get; set; }
        public string SunCloseMinute2 { get; set; }
        //

        public string ResponseMessage { get; set; }
        public List<Medicare.DataModel.Models.Country> Countries { get; set; }
        //Langugae
        public List<Medicare.DataModel.Models.Language> Languages { get; set; }
        public List<Medicare.DataModel.Models.Language> AddedLanguages { get; set; }
        public string PracticeLanguagesLanguageName { get; set; }
        public long PracticeLanguagesLanguageId { get; set; }

        //Premises
        public List<Medicare.DataModel.Models.Premises> Premises { get; set; }
        public List<Medicare.DataModel.Models.Premises> AddedPremises { get; set; }
        public string PracticePremisesPremisName { get; set; }
        public long PracticePremisesPremisId { get; set; }

        //Accreditation
        public List<Medicare.DataModel.Models.Accreditation> Accreditations { get; set; }
        public List<Medicare.DataModel.Models.Accreditation> AddedAccreditations { get; set; }
        public string PracticeAccreditationsAccreditationName { get; set; }
        public long PracticeAccreditationsAccreditationId { get; set; }

        //Insurances
        public List<Medicare.DataModel.Models.Insurance> Insurances { get; set; }
        public List<Medicare.DataModel.Models.Insurance> AddedInsurances { get; set; }
        public string PracticeInsurancesInsuranceName { get; set; }
        public long PracticeInsurancesInsuranceId { get; set; }

     //Services

        public List<Medicare.DataModel.Models.Service> Services { get; set; }
        public List<Medicare.DataModel.Models.Service> AddedServices { get; set; }
        public string PracticeServicesServiceName { get; set; }
        public long PracticeServicesServiceId { get; set; }
        public long PracticeServicesServiceTypeId { get; set; }

        //Travel Service

        public List<Medicare.DataModel.Models.Service> TravelServices { get; set; }
        public List<Medicare.DataModel.Models.Service> AddedTravelServices { get; set; }
        public string PracticeServicesTravelServiceName { get; set; }
        public long PracticeServicesTravelServiceId { get; set; }
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
