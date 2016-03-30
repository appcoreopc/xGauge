using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using xGauge.Fragments;
using Android.Support.V4.View;

namespace xGauge
{
    [Activity(Label = "xGauge", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;

        GaugePagerAdapter mSectionsPagerAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            
            mSectionsPagerAdapter = new GaugePagerAdapter(SupportFragmentManager);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.container);
            viewPager.Adapter = mSectionsPagerAdapter;
            
            
            // Setup loader //

        }
    }
}

