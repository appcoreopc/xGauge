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

namespace xGauge.Content
{
    [ContentProvider(new string[] { GaugeAuthorities.GoalContentProviderAuthorities })]
    public class GoalContentProvider : ContentProvider
    {
        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }

        public override string GetType(Android.Net.Uri uri)
        {
            throw new NotImplementedException();
        }

        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {
            throw new NotImplementedException();
        }

        public override bool OnCreate()
        {
            return true;
        }

        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            return null;
        }

        public override int Update(Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }
    }
}