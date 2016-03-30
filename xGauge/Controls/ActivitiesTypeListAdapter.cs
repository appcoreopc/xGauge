using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using xGauge.Model;
using System.Collections.Generic;

namespace xGauge.Controls
{
    public class ActivitiesTypeListAdapter : BaseAdapter<ActivitiesTypeModel>
    {
        private Context _ctx;
        private IDictionary<ActivitiesTypeModel, int> dataStore;
        private IList<ActivitiesTypeModel> _source; 

        public ActivitiesTypeListAdapter(Context ctx, IList<ActivitiesTypeModel> source)
        {
            _ctx = ctx;
            _source = source;

            #region Might re-use code
            //dataStore = new Dictionary<ActivitiesTypeModel, int>();
            //for (int i = 0; i < source.Count; i++)
            //{
            //    dataStore.Add(source[i], i);
            //} 
            #endregion
        }


        public override ActivitiesTypeModel this[int position]
        {
            get
            {
                return _source[position];
            }
        }

        public override int Count
        {
            get
            {
                return _source.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
                convertView = LayoutInflater.From(_ctx).Inflate(Resource.Layout.activity_gridelement_layout, parent, false);
            View view = convertView;
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageActivity);
            TextView activityName = view.FindViewById<TextView>(Resource.Id.textViewActivity);

            if (activityName != null)
                activityName.Text = _source[position].ActivityName;

            var imageResourceId = _source[position].ImageResourceId;
            if (imageView != null)
            imageView.SetImageResource(imageResourceId);

            return view;
        }
    }
}