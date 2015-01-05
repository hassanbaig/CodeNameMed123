using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class UserLoginAudit
    {
       public UserLoginAudit()
       {

       }
        #region Properties
       public long UserLoginAuditId { get; set; }
       public DateTime StartDateTime { get; set; }
       public string UserId { get; set; }
       public string UserLogin { get; set; }
       public short? LoginType { get; set; }
       public DateTime? EndDateTime { get; set; }
       public short? AccessStatusId { get; set; }
        #endregion

      
    }
}
