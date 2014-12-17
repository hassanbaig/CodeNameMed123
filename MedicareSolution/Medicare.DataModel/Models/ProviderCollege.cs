using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class ProviderCollege
    {
        public ProviderCollege()
        {

        }
        #region Properties
        public long ProviderCollegeId { get; set; }
        public long ProviderId { get; set; }
        public long CollegeId { get; set; }
        #endregion
                
    }

}
