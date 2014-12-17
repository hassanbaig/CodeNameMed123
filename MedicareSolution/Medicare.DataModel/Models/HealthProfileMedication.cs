using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class HealthProfileMedication
    {
        public HealthProfileMedication()
        {

        }
        #region Properties
        public long HealthProfileMedicationId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Strength { get; set; }
        public string Form { get; set; }
        public string Dose { get; set; }
        public string HowOftenTaken { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        #endregion

    }
}
