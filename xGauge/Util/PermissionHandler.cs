using Android.Support.V4.App;
using Android.Util;
using Android;
using Android.App;
using Android.Content.PM;

namespace xGauge.Util
{
    class PermissionHandler
    {
        public const string TAG = "MainActivity";
        public static readonly int REQUEST_CONTACTS = 1;
        

        static string[] PERMISSIONS_CONTACT = {
            Manifest.Permission.ReadContacts,
            Manifest.Permission.WriteContacts
        };

        public static void RequestContactsPermissions(Activity activity)
        {
            if (ActivityCompat.ShouldShowRequestPermissionRationale(activity, Manifest.Permission.ReadContacts)
                || ActivityCompat.ShouldShowRequestPermissionRationale(activity, Manifest.Permission.WriteContacts))
            {

                Log.Info(TAG, "Displaying contacts permission rationale to provide additional context.");

                // Display a SnackBar with an explanation and a button to trigger the request.
                //Snackbar.Make(layout, Resource.String.permission_contacts_rationale,
                //    Snackbar.LengthIndefinite).SetAction(Resource.String.ok, new Action<View>(delegate (View obj) {
                //        ActivityCompat.RequestPermissions(this, PERMISSIONS_CONTACT, REQUEST_CONTACTS);
                //    })).Show();
            }
            else {
                // Contact permissions have not been granted yet. Request them directly.
                ActivityCompat.RequestPermissions(activity, PERMISSIONS_CONTACT, REQUEST_CONTACTS);
            }
        }
    }
    
    public abstract class PermissionUtil
    {
        
        public static bool VerifyPermissions(Permission[] grantResults)
        {
            // At least one result must be checked.
            if (grantResults.Length < 1)
                return false;

            // Verify that each required permission has been granted, otherwise return false.
            foreach (Permission result in grantResults)
            {
                if (result != Permission.Granted)
                {
                    return false;
                }
            }
            return true;
        }
    }
}