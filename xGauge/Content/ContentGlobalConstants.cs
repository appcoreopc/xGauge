using System;
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
using System.IO;
using SQLite.Net.Interop;

namespace xGauge.Content
{
    public class GaugeAndroidDataPlatform
    {
        public const string GaugeDatabaseName = "gauge.db";
        
        public static string GetDataPath()
        {
            string applicationFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), GaugeDatabaseName);

            if (!Directory.Exists(applicationFolderPath))
                Directory.CreateDirectory(applicationFolderPath);

            return Path.Combine(applicationFolderPath, GaugeDatabaseName);
        }

        public static ISQLitePlatform GetPlatform()
        {
            return new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        }
    }
}