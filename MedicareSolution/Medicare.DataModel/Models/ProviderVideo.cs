using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderVideo
    {
       public ProviderVideo()
       {

       }

        #region Properties
       public long ProviderVideoId { get; set; }
       public long ProviderId { get; set; }
       public string Type { get; set; }
       public string Name { get; set; }
       public string Format { get; set; }
       public DateTime UploadDateTime { get; set; }
       public DateTime? DeletionDateTime { get; set; }
        #endregion

     
    }
}
