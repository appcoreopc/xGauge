using Android.OS;
using Android.Views;
using Android.Support.V4.Content;
using xGauge.Content;

namespace xGauge.Fragments
{

    public class GoalFragment : Android.Support.V4.App.Fragment, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
    {
        private bool _isGoalSetted = false;
        public GoalFragment(bool isGoalSetted)
        {
            _isGoalSetted = isGoalSetted;
        }
                
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view;

            if (_isGoalSetted)
                view = inflater.Inflate(Resource.Layout.setgoal_layout, container, false);
            else
                view = inflater.Inflate(Resource.Layout.goalsettings_layout, container, false);

            return view;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LoaderManager.InitLoader(GaugeConstant.GoalLoaderId, savedInstanceState, this);
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        //TextView name = (TextView)view.findViewById(R.id.name);
        //name.setText(cursor.getString(cursor.getColumnIndex("name")));

        public Android.Support.V4.Content.Loader OnCreateLoader(int id, Bundle args)
        {
            return new CursorLoader(this.Context, GaugeAuthorities.GOAL_CONTENT_URI, null, null, null, null);
        }

        public void OnLoaderReset(Android.Support.V4.Content.Loader loader)
        {
            
        }

        public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
        {
            if (loader != null && loader.Id == 0)
            {
                
            }
        }
    }
}