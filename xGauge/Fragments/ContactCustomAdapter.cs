using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace xGauge.Fragments
{
    class ContactAdapter : CursorAdapter
    {
        private const string Name_Key = "display_name";

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
                String name = cursor.GetString(cursor.GetColumnIndexOrThrow(Name_Key));
                TextView textView = view.FindViewById<TextView>(Resource.Id.textViewContactNameContactLayout);
                textView.Text = name;

                ImageButton btnCallContact = view.FindViewById<ImageButton>(Resource.Id.imageButtonCallContactLayout);
                if (btnCallContact != null)
                    btnCallContact.Click += CallContactMobile;

                ImageButton btnEditContact = view.FindViewById<ImageButton>(Resource.Id.imageButtonActivityContactLayout);
                if (btnCallContact != null)
                    btnCallContact.Click += EditContactMobile;
            }

        }

        private void EditContactMobile(object sender, EventArgs e)
        {
            
        }

        private void CallContactMobile(object sender, EventArgs e)
        {
            
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
                View view = LayoutInflater.From(mContext).Inflate(Resource.Layout.loadcontact_element_layout, parent, false);
                return view;
        }
    }
}