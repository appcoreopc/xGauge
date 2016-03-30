using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using xGauge.Util;
using xGauge.Controls;

namespace xGauge.Fragments
{
    public class ActivitiesFragment : Android.Support.V4.App.Fragment
    {
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activities_layout, container, false);
            GridView gridView = view.FindViewById<GridView>(Resource.Id.activitiesListGridView);
            if (gridView != null)
                gridView.Adapter = new ActivitiesTypeListAdapter(this.Context, ActivityTypeList.GetEventTypeList());
            return view;
        }
    }
}