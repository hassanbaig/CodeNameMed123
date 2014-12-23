using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderTreatment
    {
       public ProviderTreatment()
       {

       }
        #region Properties
       public long ProviderTreatmentId { get; set; }
       public long TreatmentId { get; set; }
       public long ProviderId { get; set; }
        #endregion

      
    }
}
