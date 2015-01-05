using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class ProviderDegree
    {
        public ProviderDegree()
        {

        }
        #region Properties
        public long ProviderDegreeId { get; set; }
        public long ProviderId { get; set; }
        public long DegreeId { get; set; }
        #endregion
      
    }
}
