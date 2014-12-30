using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderAffiliation
    {
       public ProviderAffiliation()
       {

       }
        #region Properties
       public long ProviderAffiliationId { get; set; }
       public long ProviderId { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public long AffiliationId { get; set; }
       public int? Year { get; set; }
        #endregion
              
    }
}
