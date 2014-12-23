using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class HealthProfileBloodPressure
    {
       public HealthProfileBloodPressure()
       {

       }
       #region Properties
       public long HealthProfileBloodPressureId { get; set; }
       public string UserId { get; set; }
       public DateTime Date { get; set; }
       public TimeSpan? Time { get; set; }
       public int Systolic { get; set; }
       public int Diastolic { get; set; }
       public int? Pulse { get; set; }
       public string Note { get; set; }
       #endregion

   }
}
