using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class ServiceType
    {
       public ServiceType()
       {

       }
        #region Properties
       public long ServiceTypeId { get; set; }
       public string Title { get; set; }
        #endregion

     
    }
}
