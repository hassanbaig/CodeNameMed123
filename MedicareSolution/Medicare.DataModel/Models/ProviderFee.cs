using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderFee
    {
       public ProviderFee()
       {

       }

        #region Properties
       public long ProviderFeeId { get; set; }
       public long ProviderId { get; set; }
       public int Fee { get; set; }
       public int Duration { get; set; }
       public string Type { get; set; }
       public string Currency { get; set; }
        #endregion
      
    }
}
