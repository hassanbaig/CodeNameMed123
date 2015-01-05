using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ProviderEducation
    {
       public ProviderEducation()
       {

       }
        #region Properties
       public long ProviderEducationId { get; set; }
       public long ProviderId { get; set; }
       public string SchoolTitle { get; set; }
       public string DegreeTitle { get; set; }
       public int? DegreeYear { get; set; }
        #endregion
             
    }
}
