using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ProviderExperience
    {
       public ProviderExperience()
       {

       }
        #region Properties
       public long ProviderExperienceId { get; set; }
       public long ProviderId { get; set; }
       public string Designation { get; set; }
       public string Organization { get; set; }
       public long? CityId { get; set; }
       public string CityName { get; set; }
       public int? StartYear { get; set; }
       public int? EndYear { get; set; }
       public int? TotalYears { get; set; }
        #endregion  

    }
}
