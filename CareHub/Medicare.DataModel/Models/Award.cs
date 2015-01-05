using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class Award
    {
        public Award()
        {

        }
        #region Properties
        public long AwardId { get; set; }
        public string Name { get; set; }
        #endregion

    }

}
