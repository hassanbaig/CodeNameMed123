using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class UserRole
    {
       public UserRole()
       {

       }
        #region Properties
       public int UserRoleId { get; set; }
       public string RoleName { get; set; }
        #endregion

      
    }
}
