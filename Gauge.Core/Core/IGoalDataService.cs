using Gauge.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauge.Core
{
    interface IGoalDataService
    {
        List<GoalValueModel> GetGoals(string clubId, string clientNo);
    }
}
