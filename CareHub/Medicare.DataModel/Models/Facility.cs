using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Facility
    {
        public Facility()
        {

        }
        #region Properties
        public long FacilityId { get; set; }
        public long ProviderId { get; set; }
        public long PracticeId { get; set; }
        public int FacilityTypeId { get; set; }
        public string FacilityName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public long CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillAddress3 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillPostalCode { get; set; }
        public string BillCountryCode { get; set; }
        public string BillPhone { get; set; }
        public string BillFax { get; set; }
        public bool GeneralMessageAvailable { get; set; }
        public bool GeneralMessageNotify { get; set; }
        public string GeneralMessageEmail { get; set; }
        public bool AppointmentMessageAvailable { get; set; }
        public int AppointmentMessageNotify { get; set; }
        public string AppointmentMessageEmail { get; set; }
        public bool MedicationMessageAvailable { get; set; }
        public int MedicationMessageNotify { get; set; }
        public string MedicationMessageEmail { get; set; }
        public bool ReferralMessageAvailable { get; set; }
        public int ReferralMessageNotify { get; set; }
        public string ReferralMessageEmail { get; set; }
        public bool PremiumAvailable { get; set; }
        public short OnlineBillPayment { get; set; }
        public long UserIdCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public long UserIdModified { get; set; }
        public DateTime DateModified { get; set; }
        public long UserIdDeactivated { get; set; }
        public DateTime DateDeactivated { get; set; }
        #endregion
              
    }
}
