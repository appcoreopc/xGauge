using Android.Net;

namespace xGauge.Content
{
    public class GaugeAuthorities
    {
        public const string Authorities = "xGauge.xGauge";

        public const string Content = "content://";

        public const string ContactContentProvider = "/contact";

        public const string GoalContentProvider = "/goal";

        public const string GoalContentProviderAuthorities = Authorities;

        public const string ClubContentProvider = "/club";

        public const string ReportContentProvider = "/report";

        public static Uri GOAL_CONTENT_URI = Uri.Parse(Content + Authorities + GoalContentProvider);

        public static Uri REPORT_CONTENT_URI = Uri.Parse(Content + Authorities + ReportContentProvider);

        public static Uri CLUB_CONTENT_URI = Uri.Parse(Content + Authorities + ClubContentProvider);

        public static Uri CONTACT_CONTENT_URI = Uri.Parse(Content + Authorities + ContactContentProvider);

    }
    

    public class GaugeConstant
    {
        public const int GoalLoaderId = 0;

        public const int ContactLoaderId = 1;

        public const int ClubLoaderId = 2;

        public const int ReportLoaderId = 3;
    }
}