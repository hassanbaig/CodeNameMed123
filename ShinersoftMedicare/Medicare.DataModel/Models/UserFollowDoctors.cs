using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class UserFollowDoctors
    {
       public UserFollowDoctors()
       {

       }
        #region Properties
       public long UserFollowDoctorsId { get; set; }
       public string UserId { get; set; }
       public long ProviderId { get; set; }
        #endregion

      
    }
}
