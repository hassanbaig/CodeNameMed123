using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
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

       public string BillingCurrencyName { get; set; }
       public string PracticeTypeName { get; set; }
       public string CityName { get; set; }
       public string StateName { get; set; }
       public string LocalityName { get; set; }
       public string CountryName { get; set; }
       public long? LocalityId { get; set; }
       public DateTime? CreationDate { get; set; }
       public string Name { get; set; }
       public string TagLine { get; set; }
       public string Description { get; set; }
       public DateTime? DeactivatedDate { get; set; }
       public string Address { get; set; }
       public string Landmark { get; set; }
       public int? Zipcode { get; set; }

       #endregion

    }
}
