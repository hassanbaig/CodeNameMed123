using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class ProviderPremis
    {
        public ProviderPremis()
        {

        }
        #region Properties
        public long ProviderPremisId { get; set; }
        public long ProviderId { get; set; }
        public long PremisId { get; set; }
        #endregion

      
    }
}
