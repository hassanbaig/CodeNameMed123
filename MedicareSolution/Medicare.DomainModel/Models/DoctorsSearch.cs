using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Factory.Factories;
using System.Reflection;
namespace Medicare.DomainModel.Models
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
        public List<Medicare.DataModel.Models.Provider> Providers { get; set; }
        public List<Medicare.DataModel.Models.Country> Countries { get; set; }
        public List<Medicare.DataModel.Models.City> Cities { get; set; }
        public List<Medicare.DataModel.Models.Locality> Localities { get; set; }
        public List<Medicare.DataModel.Models.Specialty> Specialties { get; set; }
        public List<Medicare.DataModel.Models.Provider> Doctors { get; set; }
        public List<Medicare.DataModel.Models.Provider> Pharmacists { get; set; }
        public List<Medicare.DataModel.Models.Provider> Nurses { get; set; }           
        public List<Medicare.DataModel.Models.Treatment> Treatments { get; set; }
        public int SearchType { get; set; }
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
