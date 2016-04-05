using Android.Net;

namespace xGauge.Content
{
    public class GaugeAuthorities
    {
        public const string Authorities = "xGauge.xGauge";

        public const string GoalAuthorities = ".Goal";

        public const string Content = "content://";

        public const string ContactContentProviderAuthorities = "xGauge.Contact";

        public const string GoalContentProvider = "/goal";

        public const string GoalContentProviderAuthorities = "xGauge.Goal";

        public const string ReportContentProviderAuthorities = "xGauge.Report";
        
        public const string ClubContentProviderAuthorities = "xGauge.Club";
        
        public static Uri REPORT_CONTENT_URI = Uri.Parse(Content + ReportContentProviderAuthorities);

        public static Uri CLUB_CONTENT_URI = Uri.Parse(Content + ClubContentProviderAuthorities);

        public static Uri CONTACT_CONTENT_URI = Uri.Parse(Content + ContactContentProviderAuthorities);

    }
    

    public class GaugeConstant
    {
        public const int GoalLoaderId = 0;

        public const int ContactLoaderId = 1;

        public const int ClubLoaderId = 2;

        public const int ReportLoaderId = 3;
    }
}