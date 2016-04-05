using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using xGauge.Util;
using xGauge.Controls;
using Android.App;

namespace xGauge.Fragments
{
    public class ActivitiesFragment : Android.Support.V4.App.Fragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activities_layout, container, false);
            GridView gridView = view.FindViewById<GridView>(Resource.Id.activitiesListGridView);
            if (gridView != null)
            {
                gridView.Adapter = new ActivitiesTypeListAdapter(this.Context, ActivityTypeList.GetEventTypeList());
                gridView.ItemClick += GridView_ItemClick;
            }

            return view;
        }
        
        private void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (e.Id == 0)
            {

            }
        }
    }
}