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
    
    public partial class Patient
    {
        public Patient()
        {
            this.Appointments = new HashSet<Appointment>();
            this.FavoriteProviders = new HashSet<FavoriteProvider>();
            this.PatientHealthTopics = new HashSet<PatientHealthTopic>();
            this.PatientQueries = new HashSet<PatientQuery>();
            this.PatientQueryPayments = new HashSet<PatientQueryPayment>();
            this.ProviderReviews = new HashSet<ProviderReview>();
            this.UserFollowPatients = new HashSet<UserFollowPatient>();
        }
    
        public long PatientId { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<long> CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ScreenName { get; set; }
        public string TimeZone { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<FavoriteProvider> FavoriteProviders { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PatientHealthTopic> PatientHealthTopics { get; set; }
        public virtual ICollection<PatientQuery> PatientQueries { get; set; }
        public virtual ICollection<PatientQueryPayment> PatientQueryPayments { get; set; }
        public virtual ICollection<ProviderReview> ProviderReviews { get; set; }
        public virtual ICollection<UserFollowPatient> UserFollowPatients { get; set; }
    }
}