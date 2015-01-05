using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class HealthProfileWeight
    {
       public HealthProfileWeight()
       {

       }
       #region Properties
       public long HealthProfileWeightId { get; set; }
       public string UserId { get; set; }
       public DateTime Date { get; set; }
       public TimeSpan? Time { get; set; }
       public string Note { get; set; }
       #endregion
            
    }
}
