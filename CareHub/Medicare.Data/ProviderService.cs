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
    
    public partial class ProviderService
    {
        public long ProviderServiceId { get; set; }
        public long ProviderId { get; set; }
        public long ServiceId { get; set; }
    
        public virtual Provider Provider { get; set; }
        public virtual Service Service { get; set; }
    }
}
