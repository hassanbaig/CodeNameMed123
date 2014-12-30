using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class SecurityQuestion
    {
       public SecurityQuestion()
       {

       }

        #region Properties
       public int SecurityQuestionId { get; set; }
       public string Value { get; set; }
        #endregion

      
    }
}
