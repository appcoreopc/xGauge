using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xGauge.Fragments
{
    public class GoalFragment : Android.Support.V4.App.Fragment
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
    }
}