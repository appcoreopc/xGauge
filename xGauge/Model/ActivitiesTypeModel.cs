namespace xGauge.Model
{
    public class ActivitiesTypeModel
    {

        public ActivitiesTypeModel(string name, int resource)
        {
            ActivityName = name;
            ImageResourceId = resource;
        }
        public string ActivityName { get; set; }

        public int ImageResourceId { get; set; }
       
    }
}