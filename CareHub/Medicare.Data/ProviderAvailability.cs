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
    
    public partial class ProviderAvailability
    {
        public long ProviderAvalibilityId { get; set; }
        public long ProviderId { get; set; }
        public Nullable<System.DateTime> StartTime1 { get; set; }
        public Nullable<System.DateTime> StartTime2 { get; set; }
        public Nullable<System.DateTime> EndTime1 { get; set; }
        public Nullable<System.DateTime> EndTime2 { get; set; }
        public string DayoftheWeek { get; set; }
    
        public virtual Provider Provider { get; set; }
    }
}
