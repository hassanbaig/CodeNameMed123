using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class UserPrefrences
    {
       public UserPrefrences()
       {

       }
        #region Properties
       public long UserPrefrencesId { get; set; }
       public string UserId { get; set; }
       public bool? WeeklyHealthEmail { get; set; }
       public bool? DoctorReplyEmail { get; set; }
       public bool? QuestionNotificationEmail { get; set; }
       public bool? PatientFollowEmail { get; set; }
        #endregion     
    }
}
