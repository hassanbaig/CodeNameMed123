using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Factory.Factories;
using System.Reflection;
namespace CareHub.DomainModel.Models
{
    public class DoctorsSearch:AbstractDomainModel
    {
        public DoctorsSearch()
        {
            
        }

        #region Properties        
        public int Country { get; set; }
        public long City { get; set; }
        public string Locality { get; set; }
        public string Specialty { get; set; }        
        public string Doctor { get; set; }
        public string Hospital { get; set; }
        public string Lab { get; set; }   
        public string Pharmacist { get; set; }
        public string Nurse { get; set; }
        public string Treatment { get; set; }
        public string ResponseMessage { get; set; }
        public List<CareHub.DataModel.Models.Provider> Providers { get; set; }
        public List<CareHub.DataModel.Models.Country> Countries { get; set; }
        public List<CareHub.DataModel.Models.City> Cities { get; set; }
        public List<CareHub.DataModel.Models.Locality> Localities { get; set; }
        public List<CareHub.DataModel.Models.Specialty> Specialties { get; set; }
        public List<CareHub.DataModel.Models.Provider> Doctors { get; set; }
        public List<CareHub.DataModel.Models.Provider> Pharmacists { get; set; }
        public List<CareHub.DataModel.Models.Provider> Nurses { get; set; }           
        public List<CareHub.DataModel.Models.Treatment> Treatments { get; set; }
        public int SearchType { get; set; }
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
