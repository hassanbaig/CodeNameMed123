using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicare.DataModel.Models
{
    public partial class Specialty
    {
        public Specialty()
        {

        }
        #region Properties
        public long SpecialtyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        #endregion

    }
}
