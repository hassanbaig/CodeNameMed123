using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class Language
    {
        public Language()
        {

        }
        #region Properties
        public long LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
       
    }
}
