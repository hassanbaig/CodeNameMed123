using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class Country
    {
        public Country()
        {

        } 
        #region Properties
        public int CountryId { get; set; }
        public string Name { get; set; }
        #endregion
               
    }
}
