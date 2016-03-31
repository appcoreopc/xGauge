using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauge.Core.ViewModel
{
    interface IGoalDataService
    {
        List<GoalValueModel> GetGoals(string clubId, string clientNo);
    }
}
