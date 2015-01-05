using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class PatientHealthTopics
    {
        public PatientHealthTopics()
        {

        }
        #region Properties
        public long PatientHealthTopicsId { get; set; }
        public long PatientId { get; set; }
        public string TopicName { get; set; }
        public int? RelatedPatients { get; set; }
        #endregion
        
    }
}
