using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Locality
    {
        public Locality()
        {

        }
        #region Properties
        public long LocalityId { get; set; }
        public long CityId { get; set; }
        public string Name { get; set; }
        #endregion
              
    }
}
