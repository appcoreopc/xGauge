using Gauge.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauge.Core.Data
{
    public class GaugeDataProvider : IGoalDataService
    {
        public GaugeDataProvider()
        {

        }

        public List<GoalValueModel> GetGoals(string clubId, string clientNo)
        {
            return null;   
        }
    }
}
