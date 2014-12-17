using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class Practice
    {
       public Practice()
       {

       }
       #region Properties
       public long PracticeId { get; set; }
       public long? PracticeTypeId { get; set; }
       public int? CountryId { get; set; }
       public int? StateId { get; set; }
       public long? CityId { get; set; }
       public long? LocalityId { get; set; }
       public DateTime? CreationDate { get; set; }
       public string Name { get; set; }
       public DateTime? DeactivatedDate { get; set; }
       public string Address { get; set; }
       #endregion
              
    }
}
