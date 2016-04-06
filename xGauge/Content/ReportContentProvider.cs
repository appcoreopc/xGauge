using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gauge.Core.Data;
using xGauge.Util;
using Gauge.Core.ViewModel;

namespace xGauge.Content
{
    [ContentProvider(new string[] { GaugeAuthorities.ReportContentProviderAuthorities })]

    public class ReportContentProvider : ContentProvider
    {
        public static Android.Net.Uri CONTENT_URI = Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.ReportContentProviderAuthorities);

        private GoalDataProvider dataProvider = new GoalDataProvider(GaugeAndroidDataPlatform.GetDataPath(), GaugeAndroidDataPlatform.GetPlatform());

        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            return dataProvider.Delete(selection, selectionArgs);
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
            string query = "SELECT " + projection + " WHERE " + selection + " ORDER BY " + sortOrder;
            var result = dataProvider.Query(query, selectionArgs);
            if (result != null)
                return CursorMatrixCreator.Create(result);
            return null;
        }

        public override int Update(Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            return dataProvider.Update(selection, selectionArgs);
        }
    }
}