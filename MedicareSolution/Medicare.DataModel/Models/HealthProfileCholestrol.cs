using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class HealthProfileCholestrol
    {
       public HealthProfileCholestrol()
       {

       }
       #region Properties
       public long HealthProfileCholestrolId { get; set; }
       public string UserId { get; set; }
       public string LDL { get; set; }
       public string HDL { get; set; }
       public string Triglycerids { get; set; }
       public string TotalCholestrol { get; set; }
       public DateTime Date { get; set; }
       public TimeSpan? Time { get; set; }
       public string Note { get; set; }
       #endregion
            
    }

}
