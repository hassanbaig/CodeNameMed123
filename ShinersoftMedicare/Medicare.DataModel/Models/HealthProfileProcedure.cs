using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class HealthProfileProcedure
    {
       public HealthProfileProcedure()
       {
       }
       #region Properties
       public long HealthProfileProcedureId { get; set; }
       public string UserId { get; set; }
       public string Name { get; set; }
       public DateTime? Date { get; set; }
       public string BodyLocation { get; set; }
       public string Provider { get; set; }
       public string Note { get; set; }
       #endregion

    }
}
