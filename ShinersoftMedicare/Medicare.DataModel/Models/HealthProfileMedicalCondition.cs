using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class HealthProfileMedicalCondition
    {
        public HealthProfileMedicalCondition()
        {

        }
        #region Properties
        public long HealthProfileMedicalConditionId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReasonForEnd { get; set; }
        public string Note { get; set; }
        #endregion
              
    }
}
