using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
    public partial class HealthProfileDiet
    {
        public HealthProfileDiet()
        {

        }
        #region Properties
        public long HealthProfileDietId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Name { get; set; }
        public string ServingSize { get; set; }
        public string NumberOfServing { get; set; }
        public string Meal { get; set; }
        public string Calories { get; set; }
        public string Note { get; set; }
        #endregion
             
    }
}
