using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class FacilityType
    {
        public FacilityType()
        {

        }
        #region Properties
        public int FacilityTypeId { get; set; }
        public string Type { get; set; }
        #endregion
       
    }
}
