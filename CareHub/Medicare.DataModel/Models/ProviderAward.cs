using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ProviderAward
    {
       public ProviderAward()
       {

       }
        #region Properties
       public long ProviderAwardId { get; set; }
       public long ProviderId { get; set; }
       public long AwardId { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public int? Year { get; set; }
        #endregion

    }
}
