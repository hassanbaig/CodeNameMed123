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
    
    public partial class HealthProfileMedicalDocument
    {
        public long HealthProfileMedicalDocumentId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public System.DateTime AttachmentDateTime { get; set; }
    
        public virtual User User { get; set; }
    }
}