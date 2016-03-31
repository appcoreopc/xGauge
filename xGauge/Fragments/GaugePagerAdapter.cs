using Android.Support.V4.App;

namespace xGauge.Fragments
{
    public class GaugePagerAdapter : FragmentPagerAdapter
    {
        public GaugePagerAdapter(Android.Support.V4.App.FragmentManager fm):base(fm)
        {

        }
        
        public override int Count
        {
            get
            {
                return 4;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new GoalFragment(false);
                case 1:
                    return new ActivitiesFragment();
                case 2:
                    return new ContactsFragment();
                case 3:
                    return new ReportsFragment();
                default:
                    break;
            }
            return null;
        }
    }
}