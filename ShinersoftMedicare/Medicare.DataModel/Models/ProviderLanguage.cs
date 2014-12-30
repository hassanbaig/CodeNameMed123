using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderLanguage
    {
       public ProviderLanguage()
       {

       }

        #region Properties
       public long ProviderLanguageId { get; set; }
       public long ProviderId { get; set; }
       public long LanguageId { get; set; }
        #endregion
       
    }
}
