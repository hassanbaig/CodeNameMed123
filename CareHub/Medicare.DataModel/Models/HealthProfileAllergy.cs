using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class HealthProfileAllergy
    {
        public HealthProfileAllergy()
        {

        }
        #region Properties
        public long HealthProfileAllergyId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Reaction { get; set; }
        public DateTime? FirstTimeDate { get; set; }
        public string Note { get; set; }
        #endregion

    }
}
