using SQLite.Net.Attributes;

namespace Gauge.Core.ViewModel
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MemberId { get; set; }

        public string ClubId { get; set; }

        public string Type { get; set; }
        
        public string GoaValue { get; set; }

    }
}
