using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class Gender
    {
        public Gender()
        {

        }
        #region Properties
        public int GenderId { get; set; }
        public string Value { get; set; }        
        #endregion   
     
    }
}
