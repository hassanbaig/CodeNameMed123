using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class ProviderService
    {
        public ProviderService()
        {

        }
        #region Properties
        public long ProviderServiceId { get; set; }
        public long ProviderId { get; set; }
        public long ServiceId { get; set; }
        #endregion

       
    }
}
