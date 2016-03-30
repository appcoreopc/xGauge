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
using xGauge.Model;

namespace xGauge.Util
{
    class ActivityTypeList
    {

        public static IList<ActivitiesTypeModel> GetEventTypeList()
        {
            var list = new List<ActivitiesTypeModel>();
            list.Add(new ActivitiesTypeModel("Contacts", Resource.Drawable.addressbook));
            list.Add(new ActivitiesTypeModel("Club Visit", Resource.Drawable.home));
            list.Add(new ActivitiesTypeModel("Event Attendance", Resource.Drawable.eventAttendance));
            return list;
        }

    }
}