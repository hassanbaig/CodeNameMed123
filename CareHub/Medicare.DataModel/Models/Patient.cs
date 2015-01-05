using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class Patient
    {
       public Patient()
       {

       }
       #region Properties
       public long PatientId { get; set; }
       public string UserId { get; set; }
       public string Email { get; set; }
       public int? CountryId { get; set; }
       public long? CityId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string ScreenName { get; set; }
       public string TimeZone { get; set; }
       #endregion

    }
}
