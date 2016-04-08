using Gauge.Core.ViewModel;
using System.Collections.Generic;
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

    public class GoalRestService : IGoalDataService
    {
        private const string GoalPath = "/Goal";

        public async Task<List<Goal>> GetGoalsAsync(GoalRequest goalRequest)
        {
            List<Goal> data = null;

            var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath + "/" +
                goalRequest.ClubId + "/" +
                goalRequest.MemberId).GetJsonAsync();

            if (result.IsCompleted)
            {
                data = result.Result as List<Goal>;
            }

            return data;
        }

        public async Task<bool> IsGoalSetAsync(GoalRequest goal)
        {
            bool isGoalSet = false;
            var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath + "/"
                + goal.ClubId + "/" + goal.MemberId).GetJsonAsync();

            if (result.IsCompleted)
            {
                isGoalSet = result.Status;
            }
            return isGoalSet;
        }

        public async Task SetGoalsAsync(List<Goal> goals)
        {
            var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath).GetJsonAsync();
            if (result.IsCompleted)
            {
                var a = result.Result;
            }
        }

        //public async Task<List<Goal>> IGoalDataService.GetGoalsAsync(GoalRequest goalRequest)
        //{
        //    List<Goal> data = null;

        //    var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath + "/" +
        //        goalRequest.ClubId + "/" +
        //        goalRequest.MemberId).GetJsonAsync();

        //    if (result.IsCompleted)
        //    {
        //        data = result.Result as List<Goal>;
        //    }

        //    return data;
        //}

        //public async Task<bool> IsGoalSetAsync(GoalRequest goalRequest)
        //{
        //    bool isGoalSet = false;

        //    var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath + "/" 
        //        + goalRequest.ClubId + "/" + goalRequest.MemberId).GetJsonAsync();

        //    if (result.IsCompleted)
        //    {
        //        isGoalSet = result.Status;
        //    }
        //    return isGoalSet;
        //}


        //public async Task SetGoalsAsync(List<Goal> goals)
        //{            
        //    var result = await GaugeRestConfig.baseUrl.AppendPathSegment(GoalPath).GetJsonAsync();

        //    if (result.IsCompleted)
        //    {
        //        var a = result.Result;
        //    }
        //}
    }
}
