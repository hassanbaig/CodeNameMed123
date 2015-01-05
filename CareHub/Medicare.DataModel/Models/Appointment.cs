using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Appointment
    {
        public Appointment()
        {

        }
        #region Properties
        public long AppointmentId { get; set; }
        public long ProviderId { get; set; }
        public long PatientId { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }         
        #endregion
           
    }

}
