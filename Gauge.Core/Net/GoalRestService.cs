using Gauge.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;


namespace Gauge.Core.Net
{

    public class GaugeRestConfig
    {
        public const string baseUrl = "http://10.7.62.199:5000";
    }

    public class GoalRequest
    {
        public string ClubId { get; set; }

        public string MemberId { get; set; }
    }


    public class GoalRestService
    {   
        public static async Task GetGoalsAsync(string clubId, string memberId)
        {                        
            var result = await GaugeRestConfig.baseUrl.AppendPathSegment("/Goal" + "/" + clubId + "/" + memberId).GetJsonAsync();

            if (result.IsCompleted)
            {
                var a = result.Result;
            }
        }

    }
}
