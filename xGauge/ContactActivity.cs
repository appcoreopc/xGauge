using System;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using GaugesXamarin.Droid.Util;
using Java.Lang;
using Android.Widget;
using xGauge.Fragments;

namespace xGauge
{
    [Activity(Label = "ContactActivity")]
    public class ContactActivity : Activity, LoaderManager.ILoaderCallbacks
    {
        public const int RQS_PICK_CONTACT = 1;
        private ListView contactListView; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loadcontact_layout);
            contactListView = FindViewById<ListView>(Resource.Id.loadContactListView);

            if (contactListView != null)
            {
                // LoaderManager.InitLoader(0, null, this);
            }
        }        

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }
        
        public Loader OnCreateLoader(int id, Bundle args)
        {
            Android.Net.Uri uri = Android.Net.Uri.WithAppendedPath(ContactsContract.Contacts.ContentUri, string.Empty);

            string[] projection =
            {
                    ContactsContract.PhoneLookup.InterfaceConsts.Id,
                    ContactsContract.PhoneLookup.InterfaceConsts.DisplayName,
                    ContactsContract.PhoneLookup.InterfaceConsts.Number,
                    ContactsContract.PhoneLookup.InterfaceConsts.NormalizedNumber,
                    ContactsContract.PhoneLookup.InterfaceConsts.Type
            };

            var loader = new CursorLoader(this, uri, projection, null, null, null);
            return loader;

        }

        public void OnLoaderReset(Loader loader)
        {
            
        }

        public void OnLoadFinished(Loader loader, Java.Lang.Object data)
        {
            // put into the adapter //
            // LoadContactAdapter adapter = new LoadContactAdapter(this, 
        }
    }
}