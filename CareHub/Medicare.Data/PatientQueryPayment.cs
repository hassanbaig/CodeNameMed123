//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medicare.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientQueryPayment
    {
        public long PatientQueryPaymentId { get; set; }
        public long PatientId { get; set; }
        public decimal OrderCost { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }
        public int StateId { get; set; }
        public string PinCode { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual State State { get; set; }
    }
}
