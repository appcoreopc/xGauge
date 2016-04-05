using System;
using Android.Content;
using Android.Database;
using Android.Views;
using Android.Widget;
using Android.Provider;
using xGauge.Util;

namespace xGauge.Fragments
{
    class ContactAdapter : CursorAdapter
    {
        private Context mContext;

        public ContactAdapter(View view, Context context, ICursor c) : base(context, c)
        {
            mContext = context;
        }

        public ContactAdapter(Context context, ICursor c) : base(context, c)
        {
            mContext = context;
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            if (cursor != null)
            {
                String name = cursor.GetString(cursor.GetColumnIndexOrThrow(Contacts.People.InterfaceConsts.DisplayName));
                TextView textView = view.FindViewById<TextView>(Resource.Id.textViewContactNameContactLayout);
                textView.Text = name;

                ImageButton btnCallContact = view.FindViewById<ImageButton>(Resource.Id.imageButtonCallContactLayout);
                if (btnCallContact != null)
                {
                    string id = cursor.GetString(cursor.GetColumnIndexOrThrow(Contacts.People.InterfaceConsts.Id));
                    btnCallContact.Click += CallContactMobile;
                    btnCallContact.Tag = id;
                }

                ImageButton btnEditContact = view.FindViewById<ImageButton>(Resource.Id.imageButtonActivityContactLayout);
                if (btnEditContact != null)
                {
                    string phone = cursor.GetString(cursor.GetColumnIndexOrThrow(Contacts.People.InterfaceConsts.Number));
                    btnEditContact.Click += EditContactMobile;
                    btnEditContact.Tag = phone;
                }
            }
        }

        private void EditContactMobile(object sender, EventArgs e)
        {

        }

        private void CallContactMobile(object sender, EventArgs e)
        {
            string telNo = string.Empty;
            ImageButton imgBtn = sender as ImageButton;

            if (imgBtn != null)
            {
                telNo = (string)imgBtn.Tag;
                if (!string.IsNullOrEmpty(telNo))
                {
                    PhoneUtil.TryCallPhone(mContext, telNo);
                }
            }
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.loadcontact_element_layout, parent, false);
            return view;
        }
    }
}