using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class Treatment
    {
       public Treatment()
       {

       }
        #region Properties
       public long TreatmentId { get; set; }
       public string Name { get; set; }
       public string Notes { get; set; }
       public long? Cost { get; set; }
       public long? Tax { get; set; }
       public long? ParentId { get; set; }
       public bool ShowOnClinicPage { get; set; }
        #endregion

       
    }
}
