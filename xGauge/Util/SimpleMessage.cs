using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xGauge.Util
{
    class SimpleMessage
    {
        public static void ShowMessage(Context ctx, string message)
        {
            Toast.MakeText(ctx, message, ToastLength.Short).Show();
        }
    }
}