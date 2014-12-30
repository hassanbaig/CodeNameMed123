using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class ProviderContact
    {
       public ProviderContact()
       {

       }
        #region Properties
       public long ProviderContactsId { get; set; }
       public long ProviderId { get; set; }
       public string PrimaryPhone { get; set; }
       public string SecondaryPhone { get; set; }
       public string PrimaryEmail { get; set; }
       public string SecondaryEmail { get; set; }
       public string WebsiteAddress { get; set; }     
        #endregion

    }
}
