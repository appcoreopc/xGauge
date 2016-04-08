using Gauge.Core.Core;
using Gauge.Core.Net;
using Gauge.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauge.Core
{
    public interface IGoalDataService
    {
        Task<List<Goal>> GetGoalsAsync(GoalRequest goalRequest);

        Task SetGoalsAsync(List<Goal> goals);

        Task<bool> IsGoalSetAsync(GoalRequest goal);
    }
}
