using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Degree
    {
       public Degree()
       {

       }
        #region Properties
       public long DegreeId { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }      
        #endregion

    }
}
