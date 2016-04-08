using Gauge.Core.Data;
using Gauge.Core.Net;
using Gauge.Core.ViewModel;
using SQLite.Net.Interop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gauge.Core.Core
{
    public class GoalService
    {
        bool _connectedService;
        string _dbPath;
        ISQLitePlatform _platform;
        
        public GoalService(bool connectedService, string dbPath, ISQLitePlatform platform)
        {
            _connectedService = connectedService;
            _platform = platform;
            _dbPath = dbPath;
        }
        



        public async Task<bool> IsGoalSetAsync(GoalRequest goal)
        {
            if (_connectedService)
            {
                var goalRestService = new GoalRestService();
                bool result = await goalRestService.IsGoalSetAsync(goal);
                
                return result;
            }
            else
            {
                
            }
            return false;
        }
                



        public async Task<List<Goal>> GetGoalAsync(GoalRequest goal)
        {
            List<Goal> result;

            if (_connectedService)
            {
                var goalRestService = new GoalRestService();
                result = await goalRestService.GetGoalsAsync(goal);
            }
            else
                result = new GoalDataProvider(_dbPath, _platform).Query("SELECT * FROM GOAL ", new object[] { });
           return result;
        }
    }  
}
