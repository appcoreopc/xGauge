using Android.OS;
using Android.Views;
using Android.Util;
using Android.Support.V4.App;
using xGauge.Content;
using Android.Widget;
using Android.Database;
using Gauge.Core.Net;
using Android.Content;

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
                _isGoalSetted = true;
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


            Button saveBtn;
            Button cancelBtn;

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View view;

                if (_isGoalSetted)
                {
                    view = inflater.Inflate(Resource.Layout.goaldisplay_layout, container, false);

                    var newCustomerFitChart = view.FindViewById<com.frankcalise.widgets.FitChart>(Resource.Id.newCustomerGoalChart);
                    newCustomerFitChart.MinValue = 0f;
                    newCustomerFitChart.MaxValue = 100f;
                    newCustomerFitChart.SetValue(50);

                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.goalsettings_layout, container, false);
                    saveBtn = view.FindViewById<Button>(Resource.Id.btnSaveGoal);
                    cancelBtn = view.FindViewById<Button>(Resource.Id.btnCancelGoal);

                    if (saveBtn != null)
                    {
                        saveBtn.Click += SaveBtn_Click;
                    }

                    if (cancelBtn != null)
                    {
                        cancelBtn.Click += CancelBtn_Click;
                    }
                }
                                
                return view;
            }

            private void CancelBtn_Click(object sender, System.EventArgs e)
            {
            }

            private void SaveBtn_Click(object sender, System.EventArgs e)
            {
                //string selection = "ClubId = '?' AND MemberId = '?'" ;
                //string[] selectionArg = { "0", "CN640521" };

                //Android.Net.Uri CONTENT_URI =
                //    Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);
                //Activity.ContentResolver.Query(CONTENT_URI, GoalContentProvider.Projections, selection, selectionArg, null);



                //Android.Net.Uri CONTENT_URI =
                //    Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);

                //string selection = "ClubId = '?' AND MemberId = '?'";
                //string[] selectionArg = { "0", "CN640521" };

                //ContentValues content = new ContentValues();
                //content.Put("ClubId", "NC999");
                //content.Put("MemberId", "CN640521");

                //Activity.ContentResolver.Update(CONTENT_URI, content, selection, selectionArg);


                //Android.Net.Uri CONTENT_URI =
                //    Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);

                //string selection = "ClubId = '?'";
                //string[] selectionArg = { "999NC"};

                //Activity.ContentResolver.Delete(CONTENT_URI, selection, selectionArg);
                
                Android.Net.Uri CONTENT_URI =
                    Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);
                
                ContentValues values = new ContentValues();
                values.Put("MemberId", "12345");
                values.Put("ClubId", "NC111");
                values.Put("MemberId", "12345");
                values.Put("Type", 1234);
                values.Put("GoalValue", 99);
                
                Activity.ContentResolver.Insert(CONTENT_URI, values);
                
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