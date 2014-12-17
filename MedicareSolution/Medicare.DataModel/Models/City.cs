using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class City
    {
        public City()
        {

        }
        #region Properties
        public long CityId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }        
        #endregion   
                 
    }
}
