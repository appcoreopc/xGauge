using Android.OS;
using Android.Views;
using Android.Widget;
using xGauge.Util;

namespace xGauge.Fragments
{
    public class GoalFragment : Android.Support.V4.App.Fragment, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
    {
        private bool _isGoalSetted = false;
        Button saveBtn;
        Button cancelBtn;
        
        public GoalFragment()
        {
            _isGoalSetted = true;
        }
        public GoalFragment(bool isGoalSetted)
        {
            _isGoalSetted = isGoalSetted;
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = CreateView(inflater, container);
            //view.Wait();
            return view;
        }
        
        private View CreateView(LayoutInflater inflater, ViewGroup container)
        {
            View view;

            //var service = new GoalService(false, GaugeAndroidDataPlatform.GetDataPath(), GaugeAndroidDataPlatform.GetPlatform());
            //_isGoalSetted = await service.IsGoalSetAsync(new GoalRequest() { ClubId = "test", MemberId = "memberid" });

            if (_isGoalSetted)
            {
                view = inflater.Inflate(Resource.Layout.goaldisplay_layout, container, false);

                var newCustomerFitChart = view.FindViewById<com.frankcalise.widgets.FitChart>(Resource.Id.newCustomerGoalChart);
                if (newCustomerFitChart != null)
                    newCustomerFitChart.ConfigureMinMax(50);
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
            #region Code Commented

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
            #endregion

            //Android.Net.Uri CONTENT_URI =
            //    Android.Net.Uri.Parse(GaugeAuthorities.Content + GaugeAuthorities.GoalContentProviderAuthorities);
            //ContentValues values = new ContentValues();
            //values.Put("MemberId", "12345");
            //values.Put("ClubId", "NC111");
            //values.Put("MemberId", "12345");
            //values.Put("Type", 1234);
            //values.Put("GoalValue", 99);
            //Activity.ContentResolver.Insert(CONTENT_URI, values);
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