using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
    public partial class HealthProfileHeight
    {
        public HealthProfileHeight()
        {

        }
        #region Properties
        public long HealthProfileHeightId { get; set; }
        public string UserId { get; set; }
        public int HeightFt { get; set; }
        public int HeightInches { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Note { get; set; }
        #endregion
              
    }
}
