﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Factory.Factories;
using System.Reflection;
using CareHub.DataModel.Models;
namespace CareHub.DomainModel.Models
{
    public class ProviderRegistration:AbstractDomainModel
    {
        public ProviderRegistration()
        {

        }

        #region Properties
        public string UserId { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; } 
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClinicName { get; set; }
        public long SpecialtyId { get; set; }
        public int CountryId { get; set; }
        public long? CityId { get; set; }
        public long LocalityId { get; set; }
        public string ClinicAddress { get; set; }
        public string ResponseMessage { get; set; }
        public List<Specialty> Specialties { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
        public List<Locality> Localities { get; set; }
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
