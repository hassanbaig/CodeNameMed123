using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class UserFeedback
    {
       public UserFeedback()
       {

       }
        #region Properties
       public long UserFeedbackId { get; set; }
       public string UserId { get; set; }
       public string ScreenName { get; set; }
       public string QueryNature { get; set; }
       public string Description { get; set; }
        #endregion

      
    }
}
