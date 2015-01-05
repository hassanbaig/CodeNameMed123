using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareHub.Factory.Factories;
using System.Reflection;
using CareHub.DataModel.Models;
namespace CareHub.DomainModel.Models
{
    public class ForgotPassword:AbstractDomainModel
    {
        public ForgotPassword()
        {

        }

        #region Properties
        public string ResponseMessage { get; set; }
        public string UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; } 
        
        #endregion        
    
        public override void Fill(System.Collections.Hashtable dataTable)
        {           
            base.FillModel(this.GetType(), dataTable);        
        }
    }
}
