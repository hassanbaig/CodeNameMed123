using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class Affiliation
    {
        public Affiliation()
        {

        }
        #region Properties
        public long AffiliationId { get; set; }
        public string Name { get; set; }
        #endregion
    }

}
