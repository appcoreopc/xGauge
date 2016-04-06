using Android.Content;
using Android.Database;
using Gauge.Core.Data;
using Gauge.Core.ViewModel;
using xGauge.Util;

namespace xGauge.Content
{
    [ContentProvider(new string[] { GaugeAuthorities.GoalContentProviderAuthorities })]
    public class GoalContentProvider : ContentProvider
    {
        public static Android.Net.Uri CONTENT_URI = Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);
        private GoalDataProvider dataProvider = new GoalDataProvider(GaugeAndroidDataPlatform.GetDataPath(), GaugeAndroidDataPlatform.GetPlatform());
        
        public static string[] Projections = { "Id", "MemberId", "ClubId", "Type", "GoalValue" };
        
        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            var deleteQuery = QueryBuilder.BuildDelete("GOAL", selection);
            return dataProvider.Delete(deleteQuery, selectionArgs);
        }

        public override string GetType(Android.Net.Uri uri)
        {
            return "GoalContentProvider";
        }

        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {
            Goal goal = new Goal();
            //goal.Id = values.GetAsInteger("Id");

            goal.MemberId = values.GetAsString("MemberId");
            goal.ClubId = values.GetAsString("ClubId");
            goal.Type = values.GetAsInteger("Type");
            goal.GoalValue = values.GetAsInteger("GoalValue");

            var insertedId = dataProvider.Insert(goal);
            Android.Net.Uri insertUrl = Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities + "/" + insertedId);
            return insertUrl;
        }

        public override bool OnCreate()
        {
            return dataProvider.CreateGoalTable();
        }
        
        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            var query = QueryBuilder.BuildQuery("GOAL", projection, selection, selectionArgs, sortOrder);
            var result = dataProvider.Query(query, selectionArgs);
            if (result != null)
                return CursorMatrixCreator.Create(result);
            return null;
        }

        public override int Update(Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            string clubIdValue = values.GetAsString("ClubId");
            string memberIdValue = values.GetAsString("MemberId");

            string value = " clubId = '" + clubIdValue + "'" + ", memberId = '" + memberIdValue + "'";
            var query = QueryBuilder.BuildUpdate("GOAL", value, selection);
            return dataProvider.Update(query, selectionArgs);
        }
    }
}