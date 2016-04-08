using System.Collections.Generic;
using Android.Views;
using com.frankcalise.widgets;
using Gauge.Core.ViewModel;

namespace xGauge.Util
{
    internal static class FitChartUtil
    {
        public static void ConfigureMinMax(this FitChart fixChart, float value)
        {
            if (fixChart != null)
            {
                fixChart.MinValue = 0;
                fixChart.MaxValue = 100;
                fixChart.SetValue(value);
            }
        }
    }
    internal static class ChartDataUtil
    {
        public static void FillUpChartView(View view, List<Goal> source)
        {

            foreach (var goal in source)
            {
                switch (goal.Type)
                {
                    case 0:
                        var newCustomerFitChart = view.FindViewById<FitChart>(Resource.Id.newCustomerGoalChart);
                        FitChartUtil.ConfigureMinMax(newCustomerFitChart, goal.GoalValue);
                        break;
                    case 1:
                        var sevenDayFitChart = view.FindViewById<FitChart>(Resource.Id.sevenDayCustomerChart);
                        FitChartUtil.ConfigureMinMax(sevenDayFitChart, goal.GoalValue);
                        break;
                    case 2:
                        var retailCustomerFitChart = view.FindViewById<FitChart>(Resource.Id.retailCustomerChart);
                        FitChartUtil.ConfigureMinMax(retailCustomerFitChart, goal.GoalValue);
                        break;
                }
            }
        }
    }
}