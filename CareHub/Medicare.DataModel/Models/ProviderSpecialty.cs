using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class ProviderSpecialty
    {
        public ProviderSpecialty()
        {

        }
        #region Properties
        public long ProviderSpecialtyId { get; set; }
        public long ProviderId { get; set; }
        public long SpecialtyId { get; set; }
        #endregion

      
    }
}
