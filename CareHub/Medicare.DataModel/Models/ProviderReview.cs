using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class ProviderReview
    {
        public ProviderReview()
        {

        }
        #region Properties
        public long ProviderReviewId { get; set; }
        public long ProviderId { get; set; }
        public long PatientId { get; set; }
        public int? Rate { get; set; }
        public DateTime ReviewDateTime { get; set; }
        #endregion

       
    }
}
