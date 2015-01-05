using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class HealthProfileMedicalDocument
    {
        public HealthProfileMedicalDocument()
        {

        }
        #region Properties
        public long HealthProfileMedicalDocumentId { get; set; }
        public string   UserId { get; set; }
        public string   Name { get; set; }
        public string Format { get; set; }
        public DateTime AttachmentDateTime { get; set; }
        #endregion
               
    }
}
