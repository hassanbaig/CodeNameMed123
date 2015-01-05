using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class HealthProfileLabTest
    {
        public HealthProfileLabTest()
        {

        }
        #region Properties
        public long HealthProfileLabTestId { get; set; }
        public string UserId { get; set; }
        public string TestName { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string ResultName { get; set; }
        public string ResultValue { get; set; }
        public string Unit { get; set; }
        public string Range { get; set; }
        public string Flag { get; set; }
        public string Note { get; set; }
        #endregion
            
    }
}
