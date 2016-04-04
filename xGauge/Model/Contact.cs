namespace xGauge.Model
{

    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PhoneDetail Phone { get; set; }
    }

    public class PhoneDetail
    {
        public string Id { get; set; }

        public string Number { get; set; }

        public bool IsPrimary { get; set; }

        public string NumberType { get; set; }


    }

}