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
    public class LoadContactAdapter : CursorAdapter
    {
        public LoadContactAdapter(Context context, ICursor c):base(context, c)
        {            
        }
        public LoadContactAdapter(Context context, ICursor c, bool autoRequery) : base(context, c, autoRequery)
        {
        }

        public LoadContactAdapter(Context context, ICursor c, [GeneratedEnum] CursorAdapterFlags flags):base(context, c, flags)
        {
        }


        public override void BindView(View view, Context context, ICursor cursor)
        {
            
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            return LayoutInflater.From(context).Inflate(Resource.Layout.loadcontact_element_layout, parent, false);
        }
    }
}