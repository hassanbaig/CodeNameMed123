using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class FavoriteProvider
    {
        public FavoriteProvider()
        {
                
        }
        #region Properties
        public long FavoriteProviderId { get; set; }
        public long ProviderId { get; set; }
        public long PatientId { get; set; }
        #endregion
              
    }
}
