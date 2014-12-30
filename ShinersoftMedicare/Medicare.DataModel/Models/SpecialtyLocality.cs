using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class SpecialtyLocality
    {
       public SpecialtyLocality()
       {

       }

        #region Properties
       public long SpecialtyLocalityId { get; set; }
       public long SpecialtyId { get; set; }
       public long LocalityId { get; set; }
        #endregion

      
    }
}
