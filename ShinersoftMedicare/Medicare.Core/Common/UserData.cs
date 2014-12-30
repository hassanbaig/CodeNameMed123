using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Medicare.Core.Common
{
    public class UserData
    {
        public string UserId { get; set; }
            public string ProviderId { get; set; }
            public string PatientId { get; set; }
            public string PracticeId { get; set; }
            public bool IsConsignmentCloud { get; set; }

            public UserData()
            {
            }

            public UserData(string userId, string providerId, string patientId)
            {
                UserId = userId;
                ProviderId = providerId;
                PatientId = patientId;
            }

            //public UserData(string userId, string providerId, string patientId , string practiceId)
            //{
            //    UserId = userId;
            //    ProviderId = providerId;
            //    PatientId = patientId;
            //    PracticeId = practiceId;
            //}
            public string GetProviderUserData()
            {
                string data = UserId + "," + ProviderId + "," + PatientId;
                return data;
            }

            //public string GetProviderUserData()
            //{
            //    string data = UserId + "," + ProviderId + "," + PatientId + "," + PracticeId;
            //    return data;
            //}

            // Serialize    
            public override string ToString()
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(this);
                return result;
            }

            // Deserialize
            public static UserData FromString(string text)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<UserData>(text);
            }
        
    }
}
