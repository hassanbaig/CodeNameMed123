using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class PracticeType
    {
       public PracticeType()
       {

       }
       #region Properties
       public long PracticeTypeId { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       #endregion
              
    }
}
