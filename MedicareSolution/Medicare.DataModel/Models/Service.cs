using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class Service
    {
       public Service()
       {

       }
        #region Properties
       public long ServiceId { get; set; }
       public long ServiceTypeId { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
        #endregion

     
    }
}
