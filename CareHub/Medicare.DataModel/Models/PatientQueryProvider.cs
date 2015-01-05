using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class PatientQueryProvider
    {
       public PatientQueryProvider()
       {

       }
       #region Properties
       public long PatientQueryProviderId { get; set; }
       public long ProviderId { get; set; }
       public long PatientQueryId { get; set; }
       public string ProviderType { get; set; }
       public string ProviderTitle { get; set; }
       #endregion
      
    }
}
