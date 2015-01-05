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
    
    public partial class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.Localities = new HashSet<Locality>();
            this.Patients = new HashSet<Patient>();
            this.PatientQueryPayments = new HashSet<PatientQueryPayment>();
            this.Practices = new HashSet<Practice>();
            this.States = new HashSet<State>();
        }
    
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
    
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<PatientQueryPayment> PatientQueryPayments { get; set; }
        public virtual ICollection<Practice> Practices { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}