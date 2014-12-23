using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderPractice
    {
       public ProviderPractice()
       {

       }
        #region Properties
       public long ProviderPracticeId { get; set; }
       public long ProviderId { get; set; }
       public long PracticeId { get; set; }     
        #endregion
       
    }
}
