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
    
    public partial class ProviderReview
    {
        public long ProviderReviewId { get; set; }
        public long ProviderId { get; set; }
        public long PatientId { get; set; }
        public Nullable<int> Rate { get; set; }
        public System.DateTime ReviewDateTime { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
