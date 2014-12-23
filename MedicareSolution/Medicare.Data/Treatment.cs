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
    
    public partial class Treatment
    {
        public Treatment()
        {
            this.ProviderTreatments = new HashSet<ProviderTreatment>();
        }
    
        public long TreatmentId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public Nullable<long> Cost { get; set; }
        public Nullable<long> Tax { get; set; }
        public Nullable<long> ParentId { get; set; }
        public bool ShowOnClinicPage { get; set; }
    
        public virtual ICollection<ProviderTreatment> ProviderTreatments { get; set; }
    }
}