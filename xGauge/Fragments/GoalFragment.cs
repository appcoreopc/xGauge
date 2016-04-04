using Android.OS;
using Android.Views;
using Android.Util;
using Android.Support.V4.App;
using xGauge.Content;

namespace xGauge.Fragments
{
    public class GoalSupportFragment : FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var fm = SupportFragmentManager;

            if (fm.FindFragmentById(Android.Resource.Id.Content) == null)
            {
                var list = new GoalFragment(this);
                fm.BeginTransaction().Add(Android.Resource.Id.Content, list).Commit();
            }
        }
        
        public class GoalFragment : Android.Support.V4.App.Fragment, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
        {
            private bool _isGoalSetted = false;
            private GoalSupportFragment parent; 

            public GoalFragment()
            {
                _isGoalSetted = false;
            }
            public GoalFragment(bool isGoalSetted)
            {
                _isGoalSetted = isGoalSetted;
            }

            public GoalFragment(GoalSupportFragment parent)
            {
                this.parent = parent;
                _isGoalSetted = false;
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
            }

            public Android.Support.V4.Content.Loader OnCreateLoader(int id, Bundle args)
            {
                return null;
                //return new CursorLoader(this.Context, GaugeAuthorities.GOAL_CONTENT_URI, null, null, null, null);
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
}