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
    
    public partial class Appointment
    {
        public long AppointmentId { get; set; }
        public long ProviderId { get; set; }
        public long PatientId { get; set; }
        public string Reason { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Provider Provider { get; set; }
    }
}