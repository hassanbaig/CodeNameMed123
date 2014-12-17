using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderAccreditation
    {
       public ProviderAccreditation()
       {

       }
        #region Properties
       public long ProviderAccreditationId { get; set; }
       public long ProviderId { get; set; }
       public long AccreditationId { get; set; }
        #endregion
             
    }
}
