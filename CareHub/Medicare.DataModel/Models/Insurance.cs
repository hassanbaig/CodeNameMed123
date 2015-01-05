using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Insurance
    {  
        public Insurance()
        {

        }
        #region Properties
        public long InsuranceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        #endregion
               
    }
}
