using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class HealthProfileImmunization
    {
       public HealthProfileImmunization()
       {

       }
       #region Properties
       public long HealthProfileImmunizationId { get; set; }
       public string UserId { get; set; }
       public string Name { get; set; }
       public string Type { get; set; }
       public DateTime? DateGiven { get; set; }
       public string NumberOfSequence { get; set; }
       public string WhereOnBody { get; set; }
       public string Method { get; set; }
       public string Note { get; set; }
       #endregion
            
    }
}
