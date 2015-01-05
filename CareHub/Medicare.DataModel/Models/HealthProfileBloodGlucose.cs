using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class HealthProfileBloodGlucose
    {
       public HealthProfileBloodGlucose()
       {

       }
       #region Properties
       public long HealthProfileBloodGlucoseId { get; set; }
       public string UserId { get; set; }
       public string Measurement { get; set; }
       public string Type { get; set; }
       public DateTime Date { get; set; }
       public TimeSpan? Time { get; set; }
       public string Note { get; set; }
       #endregion

    }
}
