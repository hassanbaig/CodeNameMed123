using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareHub.DataModel.Models
{
  public partial class HealthProfileFamilyHistory
    {
      public HealthProfileFamilyHistory()
      {

      }
      #region Properties
      public long HealthProfileFamilyHistoryId { get; set; }
      public string UserId { get; set; }
      public string Condition { get; set; }
      public string Severity { get; set; }
      public string Status { get; set; }
      public DateTime? StartDate { get; set; }
      public DateTime? EndDate { get; set; }
      public string HowItEnded { get; set; }
      public string Relationship { get; set; }
      public string RegionOfOrigin { get; set; }
      public DateTime? DOB { get; set; }
      public DateTime? DateOfDeath { get; set; }
      public string Note { get; set; }
      #endregion

    }
}
