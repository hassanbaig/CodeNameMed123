using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class MessageStatus
    {
       public MessageStatus()
       {

       }
        #region Properties
       public int MessageStatusId { get; set; }
       public string Value { get; set; }
        #endregion
      
    }
}
