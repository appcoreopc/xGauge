using Android.Content;
using Android.Provider;
using Android.Net;
using xGauge.Model;

namespace GaugesXamarin.Droid.Util
{
    public class ContactUtil
    {
        public static Intent CreatePickContactIntent()
        {
            Intent intent = new Intent(Intent.ActionPick, ContactsContract.Contacts.ContentUri);
            return intent;
        }

        public static Intent CreatePhoneLookupIntent()
        {
            Intent intent = new Intent(Intent.ActionPick, ContactsContract.CommonDataKinds.Phone.ContentUri);
            return intent;
        }
        
        public static Intent OpenContactById(long id)
        {
            var contactId = id.ToString();
            if (!string.IsNullOrEmpty(contactId.ToString()))
            {
                Intent openContactIntent = new Intent(Intent.ActionView);
                Uri contactUri = Uri.WithAppendedPath(ContactsContract.Contacts.ContentUri, contactId);
                openContactIntent.SetData(contactUri);
                return openContactIntent;
            }
            return null;
        }

        public static long GetContactByPhone(ContentResolver resolver, string number)
        {
            Uri uri = Uri.WithAppendedPath(ContactsContract.PhoneLookup.ContentFilterUri, Uri.Encode(number));

            string[] projection =
            {
                    ContactsContract.PhoneLookup.InterfaceConsts.Id,
                    ContactsContract.PhoneLookup.InterfaceConsts.DisplayName,
                    ContactsContract.PhoneLookup.InterfaceConsts.Number,
                    ContactsContract.PhoneLookup.InterfaceConsts.NormalizedNumber,
                    ContactsContract.PhoneLookup.InterfaceConsts.Type
            };

            var cursor = resolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToNext())
            {
                long id = cursor.GetLong(0);
                string name = cursor.GetString(1);
                string data = cursor.GetString(2);
                string data2 = cursor.GetString(3);
                string type = cursor.GetString(4);
                return id;
            }
            return -1;
        }

        public static Customer GetContact(ContentResolver resolver, Uri uri)
        {
            var customer = new Customer();

            string[] projection =
            {
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Id,
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.DisplayName,
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data,
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Data1,
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.DisplayNamePrimary,
                    ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Type
            };

            var cursor = resolver.Query(uri, projection, null, null, null);

            if (cursor.MoveToNext())
            {
                var phoneDetail = new PhoneDetail();

                long id = cursor.GetLong(0);
                var lastName = cursor.GetString(1);

                if (!string.IsNullOrEmpty(lastName))
                {
                    customer.LastName = lastName;
                    customer.FirstName = "FirstName";
                }

                var phoneNumber = cursor.GetString(2);
                if (!string.IsNullOrEmpty(phoneNumber))
                    phoneDetail.Number = phoneNumber;

                phoneDetail.Id = id.ToString();
                phoneDetail.IsPrimary = true;
                phoneDetail.NumberType = "Other";

                customer.Phone = phoneDetail;
                return customer;
            }
            return null;
        }
    }
}