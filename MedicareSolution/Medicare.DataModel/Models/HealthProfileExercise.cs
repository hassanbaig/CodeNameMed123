using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.DataModel.Models
{
   public partial class HealthProfileExercise
    {
       public HealthProfileExercise()
       {

       }
       #region Properties
       public long HealthProfileExerciseId { get; set; }
       public string UserId { get; set; }
       public DateTime Date { get; set; }
       public TimeSpan? Time { get; set; }
       public string Activity { get; set; }
       public string Description { get; set; }
       public string Duration { get; set; }
       public string Distance { get; set; }
       public string NumberOfSteps { get; set; }
       public string Note { get; set; }
       #endregion

    }
}
