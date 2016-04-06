using Gauge.Core.ViewModel;
using SQLite.Net;
using SQLite.Net.Interop;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gauge.Core.Data
{
    public class GaugeDataProvider
    {
        private SQLiteConnection _connection;

        public GaugeDataProvider(string appPath, ISQLitePlatform platform)
        {
            _connection = new SQLiteConnection(platform, appPath);
        }

        //public void CreateClubTable()
        //{
        //    if (!TableExist(GaugeTableConstant.ClubTableName))
        //        _connection.CreateTable<Club>();
        //}

        //public void CreateContactTable()
        //{
        //    if (!TableExist(GaugeTableConstant.ContactsTableName))
        //        _connection.CreateTable<Contacts>();
        //}

        //public void CreateReportTable()
        //{
        //    if (!TableExist(GaugeTableConstant.ReportTableName))
        //        _connection.CreateTable<Report>();
        //}

        public static bool TableExist(SQLiteConnection _connection, string goalTableName)
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

    public class QueryBuilder
    {

        private const string SELECT_STATEMENT = "SELECT ";
        private const string FROM_STATEMENT = " FROM ";
        private const string WHERE_STATEMENT = " WHERE ";

        public static string buildQuery(string table, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            StringBuilder builder = new StringBuilder(SELECT_STATEMENT);
            builder.Append(string.Join(",", projection));
            builder.Append(FROM_STATEMENT + table);
            builder.Append(WHERE_STATEMENT);

            var regex = new Regex(Regex.Escape("?"));
            string pText = selection;

            for (int i = 0; i < selectionArgs.Length; i++)
            {
                pText = regex.Replace(pText, selectionArgs[i], 1);
            }

            builder.Append(pText);
            return builder.ToString();
        }
    }

}
