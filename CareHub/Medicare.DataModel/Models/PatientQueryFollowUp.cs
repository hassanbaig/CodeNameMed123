using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class PatientQueryFollowUp
    {
       public PatientQueryFollowUp()
       {

       }
       #region Properties
       public long PatientQueryFollowUpID { get; set; }
       public long PatientQueryId { get; set; }
       public string Description { get; set; }
       public int FollowUpRemaining { get; set; }
       public DateTime QueryCreationDateTime { get; set; }
       #endregion
             
    }
}
