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
    
    public partial class Insurance
    {
        public Insurance()
        {
            this.ProviderInsurances = new HashSet<ProviderInsurance>();
        }
    
        public long InsuranceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ProviderInsurance> ProviderInsurances { get; set; }
    }
}
