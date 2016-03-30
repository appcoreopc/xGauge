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
            list.Add(new ActivitiesTypeModel("7 day card", Resource.Drawable.sevendaycard));
            list.Add(new ActivitiesTypeModel("Long Term", Resource.Drawable.longterm));
            list.Add(new ActivitiesTypeModel("Retail", Resource.Drawable.retail));
            list.Add(new ActivitiesTypeModel("Consumption", Resource.Drawable.consumption));
            list.Add(new ActivitiesTypeModel("Vip", Resource.Drawable.vip));
            return list;
        }

    }
}