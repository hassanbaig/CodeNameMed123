using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class Provider
    {
       public Provider()
       {
            
       }
       #region Properties
       public long ProviderId { get; set; }
       public long? ProviderTypeId { get; set; }
       public DateTime? DOB { get; set; }
       public string BloodGroup { get; set; }
       public string UserId { get; set; }
       public string Email { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Description { get; set; }
       public int? TotalExperienceYears { get; set; }
       public string TagLine { get; set; }
       public string ScreenName { get; set; }
       public string RoleName { get; set; }
       public int GenderId { get; set; }
       public string MobileNumber { get; set; }
       public string ExtraMobileNumber { get; set; }
       public int? DocPoints { get; set; }
       public string TimeZone { get; set; }
       public string LicenseNumber { get; set; }
       public string LicenseCountry { get; set; }
       public string LicenseState { get; set; }
       public bool? IsActive { get; set; }
       public int? ZipCode { get; set; }
       public DateTime? SignUpDate { get; set; }
       public DateTime? DeactivatedDate { get; set; }
       public DateTime? LastLoginDate { get; set; }
       public string StreetAddress { get; set; }
       public string RegistrationDetails { get; set; }
       public int? RegistrationYear { get; set; }
       public long? RegistrationCouncilId { get; set; }
       public string Education { get; set; }
       public string Experience { get; set; }
       public string Specialties { get; set; }
       public string Practice { get; set; }
       public string Address { get; set; }
       public int Fee { get; set; }
       public string Currency { get; set; }
       public string Days { get; set; }
       public string Timings { get; set; }
       #endregion
             
    }
}
