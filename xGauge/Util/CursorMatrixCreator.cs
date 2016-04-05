
using System.Collections.Generic;
using Android.Database;
using Gauge.Core.ViewModel;

namespace xGauge.Util
{
    public class CursorMatrixCreator
    {
        public static Android.Database.MatrixCursor Create(List<Goal> goals)
        {
            string[] columnNames = { "Id", "MemberId", "ClubId", "Type", "GoalValue" }; 
            MatrixCursor cursor = new MatrixCursor(columnNames);

            foreach (var item in goals)
            {
                cursor.AddRow(new Java.Lang.Object[] { item.Id, item.ClubId, item.ClubId, item.Type, item.GoalValue });
            }
            return cursor;
        }
    }
}