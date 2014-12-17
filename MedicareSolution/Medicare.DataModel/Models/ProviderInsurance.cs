using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class ProviderInsurance
    {
        public ProviderInsurance()
        {

        }
        #region Properties
        public long ProviderInsuranceId { get; set; }
        public long ProviderId { get; set; }
        public long InsuranceId { get; set; }
        #endregion
              
    }
}
