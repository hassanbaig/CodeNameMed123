using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ProviderPhoto
    {
       public ProviderPhoto()
       {

       }
        #region Properties
       public long ProviderPhotoId { get; set; }
       public long ProviderId { get; set; }      
       public string Title { get; set; }
       public string Path { get; set; }
       public string Description { get; set; }
       public DateTime UploadDateTime { get; set; }      
        #endregion

      
    }
}
