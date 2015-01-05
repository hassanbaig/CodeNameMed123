using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
   public partial class State
    {
       public State()
       {

       }
        #region Properties
       public int StateId { get; set; }
       public int CountryId { get; set; }
       public string Name { get; set; }
        #endregion

      
    }
}
