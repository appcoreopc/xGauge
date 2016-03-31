using Gauge.Core.ViewModel;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gauge.Core.Data
{
    public class GaugeDataProvider 
    {
        private SQLiteConnection _connection;

        public GaugeDataProvider(string appPath, ISQLitePlatform platform)
        {
            _connection = new SQLiteConnection(platform, appPath);

            InitDatabase();
        }

        private void InitDatabase()
        {
            if (!TableExist(GaugeTableConstant.GoalTableName))
                _connection.CreateTable<Goal>();

            if (!TableExist(GaugeTableConstant.ClubTableName))
                _connection.CreateTable<Club>();

            if (!TableExist(GaugeTableConstant.ContactsTableName))
                _connection.CreateTable<Contacts>();

        }

        private bool TableExist(string goalTableName)
        {
            var tableInfo = _connection.GetTableInfo(goalTableName);
            return tableInfo.Any();
        }
        
        
        
        
        
              

        public List<Goal> GetGoal(string clubId, string memberId)
        {
            var result = _connection.Query<Goal>("SELECT * FROM Goal WHERE ClubId = ? AND MemberId = ?", clubId, memberId);
            return result;
        }

        public Goal GetGoalById(int Id)
        {
            var result = _connection.Get<Goal>(Id);
            return result;
        }



    }
}
