using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database;
using Android.Provider;
using Android.Util;
using Android.Support.V4.App;
using Android.Content.PM;
using xGauge.Util;

namespace xGauge.Fragments
{
    public class ContactsFragment : Android.Support.V4.App.Fragment, Android.Support.V4.App.LoaderManager.ILoaderCallbacks
    {
        private SimpleCursorAdapter _adapter;

        public ContactsFragment()
        {
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            _adapter = new SimpleCursorAdapter(Activity,
                     Resource.Layout.loadcontact_element_layout, null,
                     new string[] { Android.Provider.Contacts.People.InterfaceConsts.DisplayName },
                     new int[] { Resource.Id.textViewContactNameContactLayout });

            LoaderManager.InitLoader(0, null, this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.loadcontact_layout, container, false);
            return view;
        }

        public static readonly string QUERY_KEY = "query";
        public static readonly string TAG = "ContactablesLoaderCallbacks";
        public string[] CONTACTS_SUMMARY_PROJECTION = new string[] {
                Contacts.People.InterfaceConsts.Id,
                Contacts.People.InterfaceConsts.DisplayName
            };

        Android.Support.V4.Content.Loader Android.Support.V4.App.LoaderManager.ILoaderCallbacks.OnCreateLoader(int id, Bundle args)
        {
            var baseUri = Contacts.People.ContentUri;

            string select = "((" + Contacts.People.InterfaceConsts.DisplayName + " NOTNULL) AND ("
                   + Contacts.People.InterfaceConsts.DisplayName + " != '' ))";

            return new Android.Support.V4.Content.CursorLoader(Activity, baseUri,
                    CONTACTS_SUMMARY_PROJECTION, select, null,
                    Contacts.People.InterfaceConsts.DisplayName + " COLLATE LOCALIZED ASC");
        }

        public void OnLoadFinished(Android.Support.V4.Content.Loader loader, Java.Lang.Object data)
        {
            var cursor = data.JavaCast<ICursor>();
            _adapter.SwapCursor(cursor);
        }

        public void OnLoaderReset(Android.Support.V4.Content.Loader loader)
        {
            _adapter.SwapCursor(null);
        }









        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            if (requestCode == PermissionHandler.REQUEST_CONTACTS)
            {

                Log.Info(TAG, "Received response for contact permissions request.");

                // We have requested multiple permissions for contacts, so all of them need to be
                // checked.
                if (PermissionUtil.VerifyPermissions(grantResults))
                {
                    LoaderManager.InitLoader(0, null, this);

                    // All required permissions have been granted, display contacts fragment.
                    //Snackbar.Make(layout, Resource.String.permision_available_contacts, Snackbar.LengthShort).Show();
                }
                else {
                    Log.Info(TAG, "Contacts permissions were NOT granted.");
                    //Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();
                }
            }
            else {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

    }
}

