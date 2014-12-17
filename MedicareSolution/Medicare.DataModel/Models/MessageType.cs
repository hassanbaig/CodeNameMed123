using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class MessageType
    {
       public MessageType()
       {

       }
        #region Properties
       public int MessageTypeId { get; set; }
       public string Value { get; set; }
       public bool General { get; set; }
        #endregion
    }
}
