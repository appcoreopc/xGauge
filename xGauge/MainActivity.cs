using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using xGauge.Fragments;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Views;
using Java.Lang;
using Android.Content;
using System.Collections.Generic;

namespace xGauge
{

    [Activity(Label = "xGauge", MainLauncher = true, Icon = "@drawable/icon")]
    public class FragmentTabsPager : AppCompatActivity
    {

        private const string tabKeyString = "tab";
        private TabHost tabHost;
        private ViewPager viewPager;
        private TabsAdapter tabsAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.fragment_tabs_pager);
            tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);
            tabHost.Setup();

            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            viewPager.OffscreenPageLimit = 5;

            tabsAdapter = new TabsAdapter(this, tabHost, viewPager);

            tabsAdapter.AddTab(tabHost.NewTabSpec("Goal").SetIndicator(string.Empty, Resources.GetDrawable(Resource.Drawable.target)), Java.Lang.Class.FromType(typeof(GoalFragment)), null);
            tabsAdapter.AddTab(tabHost.NewTabSpec("Activities").SetIndicator(string.Empty, Resources.GetDrawable(Resource.Drawable.activities)), Java.Lang.Class.FromType(typeof(ActivitiesFragment)), null);
            tabsAdapter.AddTab(tabHost.NewTabSpec("Contacts").SetIndicator(string.Empty, Resources.GetDrawable(Resource.Drawable.contacts)), Java.Lang.Class.FromType(typeof(ContactsFragment)), null);
            tabsAdapter.AddTab(tabHost.NewTabSpec("Report").SetIndicator(string.Empty, Resources.GetDrawable(Resource.Drawable.report)), Java.Lang.Class.FromType(typeof(ReportsFragment)), null);

            if (savedInstanceState != null)
            {
                tabHost.SetCurrentTabByTag(savedInstanceState.GetString(tabKeyString));
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString(tabKeyString, tabHost.CurrentTabTag);
        }

        protected class TabsAdapter : FragmentPagerAdapter, TabHost.IOnTabChangeListener, ViewPager.IOnPageChangeListener
        {
            private Context _context;
            private TabHost _tabHost;
            private ViewPager _viewPager;
            private List<TabInfo> _tabs = new List<TabInfo>();

            public class TabInfo
            {
                public string tag;
                public Class clss;
                public Bundle args;
                public Android.Support.V4.App.Fragment fragment { get; set; }

                public TabInfo(string _tag, Class _class, Bundle _args)
                {
                    tag = _tag;
                    clss = _class;
                    args = _args;
                }
            }

            public override IParcelable SaveState()
            {
                return base.SaveState();
            }

            public override void RestoreState(IParcelable state, ClassLoader loader)
            {
                base.RestoreState(state, loader);
            }

            public class DummyTabFactory : Java.Lang.Object, TabHost.ITabContentFactory
            {
                private Context _context;

                public DummyTabFactory(Context context)
                {
                    _context = context;
                }

                public View CreateTabContent(string tag)
                {
                    var v = new View(_context);
                    v.SetMinimumHeight(0);
                    v.SetMinimumWidth(0);
                    return v;
                }
            }

            public TabsAdapter(FragmentActivity activity, TabHost tabHost, ViewPager pager) :
                base(activity.SupportFragmentManager)
            {
                _context = activity;
                _tabHost = tabHost;
                _viewPager = pager;
                _tabHost.SetOnTabChangedListener(this);
                _viewPager.Adapter = this;
                _viewPager.SetOnPageChangeListener(this);

            }

            public void AddTab(TabHost.TabSpec tabSpec, Class clss, Bundle args)
            {
                tabSpec.SetContent(new DummyTabFactory(_context));
                var tag = tabSpec.Tag;

                var info = new TabInfo(tag, clss, args);

                _tabs.Add(info);
                _tabHost.AddTab(tabSpec);
                NotifyDataSetChanged();
            }

            public override int Count
            {
                get
                {
                    return _tabs.Count;
                }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                var info = _tabs[position];
                return Android.Support.V4.App.Fragment.Instantiate(_context, info.clss.Name, info.args);
            }

            public void OnTabChanged(string tabId)
            {
                int position = _tabHost.CurrentTab;
                _viewPager.CurrentItem = position;
            }

            public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
            {

            }

            public void OnPageSelected(int position)
            {
                var widget = _tabHost.TabWidget;
                var oldFocusability = widget.DescendantFocusability;
                widget.DescendantFocusability = DescendantFocusability.BlockDescendants;
                _tabHost.CurrentTab = position;
                widget.DescendantFocusability = oldFocusability;
            }

            public void OnPageScrollStateChanged(int state)
            {

            }
        }
    }
}

