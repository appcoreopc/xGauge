using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V4.App;
using Android.Provider;
using Android.Database;
using SimpleCursorAdapter = Android.Support.V4.Widget.SimpleCursorAdapter;

namespace xGauge.Fragments
{
	[Activity (Label = "GoalCursorSupport")]
	[IntentFilter (new[]{Intent.ActionMain}, Categories = new[]{ "mono.support4demo.sample" })]
	public class GoalCursorSupport : FragmentActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			
			var fm = SupportFragmentManager;
            
	        if (fm.FindFragmentById(Android.Resource.Id.Content) == null) {
	            var list = new GoalCursorSupportFragment(this);
	            fm.BeginTransaction().Add(Android.Resource.Id.Content, list).Commit();
	        }
		}
        
		public class GoalCursorSupportFragment : Android.Support.V4.App.Fragment, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
		{
            GoalCursorSupport parent;
            private bool _isGoalSetted = false;

            public GoalCursorSupportFragment() {}

			public GoalCursorSupportFragment(GoalCursorSupport parent)
			{
				this.parent = parent;
			}
			
	        SimpleCursorAdapter _adapter;
            string _curFilter;

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                View view;

                if (_isGoalSetted)
                    view = inflater.Inflate(Resource.Layout.setgoal_layout, container, false);
                else
                    view = inflater.Inflate(Resource.Layout.goalsettings_layout, container, false);

                return view;
            }


            public override void OnActivityCreated (Bundle p0)
			{
				base.OnActivityCreated (p0);
							
				HasOptionsMenu = true;
	            
	            _adapter = new SimpleCursorAdapter(Activity,
	                    Android.Resource.Layout.SimpleListItem1, null,
	                    new string[] { Android.Provider.Contacts.People.InterfaceConsts.DisplayName },
	                    new int[] {Android.Resource.Id.Text1});
	        
				LoaderManager.InitLoader (0, null, this);
			}
						
			public override void OnCreateOptionsMenu (IMenu menu, MenuInflater inflater)
			{
		
			}
		
	        public string[] CONTACTS_SUMMARY_PROJECTION = new string[] {
	            Contacts.People.InterfaceConsts.Id,
	            Contacts.People.InterfaceConsts.DisplayName
	        };
			
			#region ILoaderCallbacks implementation
			public Android.Support.V4.Content.Loader OnCreateLoader (int p0, Bundle p1)
			{
				
	            Android.Net.Uri baseUri;
	            if (_curFilter != null) {
	                baseUri = Android.Net.Uri.WithAppendedPath(Contacts.People.ContentFilterUri, Android.Net.Uri.Encode(_curFilter));
	            } else {
	                baseUri = Contacts.People.ContentUri;
	            }
	         
	            string select = "((" + Contacts.People.InterfaceConsts.DisplayName + " NOTNULL) AND ("
	                    + Contacts.People.InterfaceConsts.DisplayName + " != '' ))";
	            return new Android.Support.V4.Content.CursorLoader(Activity, baseUri,
	                    CONTACTS_SUMMARY_PROJECTION, select, null,
	                    Contacts.People.InterfaceConsts.DisplayName + " COLLATE LOCALIZED ASC");
			}
			
			public void OnLoadFinished (Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
			{
				_adapter.SwapCursor(data.JavaCast<ICursor>());
			}

			public void OnLoaderReset (Android.Support.V4.Content.Loader p0)
			{
				_adapter.SwapCursor(null);
			}


			#endregion	
		}
	}
}

