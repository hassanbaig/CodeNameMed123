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
    
    public partial class Award
    {
        public Award()
        {
            this.ProviderAwards = new HashSet<ProviderAward>();
        }
    
        public long AwardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ProviderAward> ProviderAwards { get; set; }
    }
}
