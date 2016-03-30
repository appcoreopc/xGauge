using Android.OS;
using Android.Views;

namespace xGauge.Fragments
{
    public class MainFragment : Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.setgoal_layout, container, false);
            return view;
        }
    }
}