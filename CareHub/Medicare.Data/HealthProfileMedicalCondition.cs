//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareHub.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class HealthProfileMedicalCondition
    {
        public long HealthProfileMedicalConditionId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string ReasonForEnd { get; set; }
        public string Note { get; set; }
    
        public virtual User User { get; set; }
    }
}