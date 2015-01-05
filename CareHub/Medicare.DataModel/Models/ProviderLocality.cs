using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ProviderLocality
    {
       public ProviderLocality()
       {

       }

        #region Properties
       public long ProviderLocalityId { get; set; }
       public long ProviderId { get; set; }
       public long LocalityId { get; set; }
        #endregion
     
    }
}
