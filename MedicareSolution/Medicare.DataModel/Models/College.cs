using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class College
    {
        public College()
       {

       }
        #region Properties
        public long CollegeId { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }      
        #endregion     
    }
}
