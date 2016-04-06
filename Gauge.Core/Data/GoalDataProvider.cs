using Gauge.Core.ViewModel;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Collections.Generic;

namespace Gauge.Core.Data
{
    public class GoalDataProvider
    {
        private SQLiteConnection _connection;
        public GoalDataProvider(string appPath, ISQLitePlatform platform)
        {
            _connection = new SQLiteConnection(platform, appPath);
        }
                
        public bool CreateGoalTable()
        {   
            if (!GaugeDataProvider.TableExist(_connection, GaugeTableConstant.GoalTableName))
            {
                _connection.CreateTable<Goal>();
                return true;
            }
            return false; 
        }

        public int Delete(string query, object[] selectionArg)
        {
            int  rowDeleted = _connection.Execute(query, selectionArg);
            return rowDeleted;
        }

        public int Insert(Goal goal)
        {
            return _connection.Insert(goal);
        }
        
        public List<Goal> Query(string query, object[] dparams)
        {
            return _connection.Query<Goal>(query, dparams);
        }
        
        public int Update(string query, object[] selectionArg)
        {
            int rowUpdated = _connection.Execute(query, selectionArg);
            return rowUpdated;
        }

    }
}
