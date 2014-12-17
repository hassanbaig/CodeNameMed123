using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class PatientQueryPayment
    {
       public PatientQueryPayment()
       {

       }
       #region Properties
       public long PatientQueryPaymentId { get; set; }
       public long PatientId { get; set; }
       public decimal OrderCost { get; set; }
       public DateTime TransactionDate { get; set; }
       public string AccountName { get; set; }
       public string Address { get; set; }
       public long CityId { get; set; }
       public int StateId { get; set; }
       public string PinCode { get; set; }
       public int CountryId { get; set; }
       public string Phone { get; set; }
       public string Status { get; set; }
       #endregion

    }
}
