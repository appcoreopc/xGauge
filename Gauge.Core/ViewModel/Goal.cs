using SQLite.Net.Attributes;

namespace Gauge.Core.ViewModel
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MemberId { get; set; }

        public string ClubId { get; set; }

        public int Type { get; set; }
        
        public int GoalValue { get; set; }
        

    }
}
