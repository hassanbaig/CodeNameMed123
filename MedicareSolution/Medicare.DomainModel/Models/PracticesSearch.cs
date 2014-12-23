using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicare.Factory.Factories;
using System.Reflection;
namespace Medicare.DomainModel.Models
{
    public class PracticesSearch:AbstractDomainModel
    {
        public PracticesSearch()
        {
            
        }

        #region Properties        
        public int Country { get; set; }
        public long City { get; set; }
        public string Locality { get; set; }        
        public string Hospital { get; set; }
        public string Lab { get; set; }        
        public string ResponseMessage { get; set; }
        public List<Medicare.DataModel.Models.Practice> Practices { get; set; }                     
        public List<Medicare.DataModel.Models.Practice> Hospitals { get; set; }
        public List<Medicare.DataModel.Models.Practice> Labs { get; set; }                
        public int SearchType { get; set; }
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
