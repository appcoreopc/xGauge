using Android.Content;
using Android.Database;
using Gauge.Core.Data;
using xGauge.Util;
using Gauge.Core.ViewModel;

namespace xGauge.Content
{
    [ContentProvider(new string[] { GaugeAuthorities.ReportContentProviderAuthorities })]

    public class ReportContentProvider : ContentProvider
    {
        public static Android.Net.Uri CONTENT_URI = Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.ReportContentProviderAuthorities);
        private const string TABLENAME = "GOAL";
        private ReportDataProvider dataProvider = new ReportDataProvider(GaugeAndroidDataPlatform.GetDataPath(), GaugeAndroidDataPlatform.GetPlatform());

        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            var deleteQuery = QueryBuilder.BuildDelete(TABLENAME, selection);
            return dataProvider.Delete(deleteQuery, selectionArgs);
        }

        public override string GetType(Android.Net.Uri uri)
        {
            return "ReportContentProvider";
        }

        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {
            Goal goal = new Goal();
            goal.Id = values.GetAsInteger("Id");
            goal.MemberId = values.GetAsString("MemberId");
            goal.ClubId = values.GetAsString("ClubId");
            goal.Type = values.GetAsInteger("Type");
            goal.GoalValue = values.GetAsInteger("GoalValue");

            var insertedId = dataProvider.Insert(goal);
            Android.Net.Uri insertUrl = Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.ReportContentProviderAuthorities + "/" + insertedId);
            return insertUrl;
        }

        public override bool OnCreate()
        {
            return dataProvider.CreateGoalTable();
        }

        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            var query = QueryBuilder.BuildQuery(TABLENAME, projection, selection, selectionArgs, sortOrder);
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
            var query = QueryBuilder.BuildUpdate(TABLENAME, value, selection);

            return dataProvider.Update(selection, selectionArgs);
        }
    }
}