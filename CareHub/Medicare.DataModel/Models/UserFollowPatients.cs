using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class UserFollowPatients
    {
       public UserFollowPatients()
       {

       }
        #region Properties
       public long UserFollowPatientsId { get; set; }
       public string UserId { get; set; }
       public long PatientId { get; set; }
        #endregion

      
    }
}
