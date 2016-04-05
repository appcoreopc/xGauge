using SQLite.Net.Attributes;


namespace Gauge.Core.ViewModel
{
    public class Report
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ClubId { get; set; }

        public string ClubName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

    }

}
