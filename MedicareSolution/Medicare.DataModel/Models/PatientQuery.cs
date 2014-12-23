using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class PatientQuery
    {
       public PatientQuery()
       {

       }
       #region Properties
       public long PatientQueryId { get; set; }
       public long PatientId { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
       public string Summary { get; set; }
       public long SpecialtyId { get; set; }
       public int? Age { get; set; }
       public string ScreenName { get; set; }
       public string Gender { get; set; }
       public string MedicalHistory { get; set; }
       public string AttachedDocument { get; set; }
       public string DocumentName { get; set; }
       public string DocumentFormat { get; set; }
       public DateTime QueryCreationDateTime { get; set; }
       public string Status { get; set; }
       #endregion
             
    }
}
