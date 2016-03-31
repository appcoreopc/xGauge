using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace xGauge.Controls
{
    public class GoalSetter : LinearLayout
    {
        private ImageButton _BtnPlus;
        private ImageButton _BtnMinus;
        private EditText _EditTextGoalValue;
        private TextView _Title; 

        private const string KEYNAME = "GoalValue";

        private int _goalValue;

        public GoalSetter(Context ctx):base(ctx)
        {
            Init();
        }

        public GoalSetter(Context ctx, IAttributeSet attr):base(ctx, attr)
        {
            Init();
        }

        private void Init()
        {
            var view = LayoutInflater.From(Context).Inflate(Resource.Layout.goalctrl_layout, this);
            _BtnPlus = FindViewById<ImageButton>(Resource.Id.imageButtonPlus);
            _BtnMinus = FindViewById<ImageButton>(Resource.Id.imageButtonMinus);
            _EditTextGoalValue = FindViewById<EditText>(Resource.Id.editTextGoalValue);
            _Title = FindViewById<TextView>(Resource.Id.textView1); 
            
            UpdateControl();

            if (_BtnPlus != null)
                _BtnPlus.Click += _BtnPlus_Click;

            if (_BtnMinus != null)
                _BtnMinus.Click += _BtnMinus_Click;
        }

        private void _BtnMinus_Click(object sender, EventArgs e)
        {
            if (_goalValue > 0)
                _goalValue = 0;
            else 
                _goalValue--;
        }

        private void _BtnPlus_Click(object sender, EventArgs e)
        {
            _goalValue++;
        }
             
        private void UpdateControl()
        {
            _EditTextGoalValue.Text = _goalValue.ToString();
        }

        public void SetValue(int value)
        {
            _goalValue = value;
        }

        public void SetTitle(string value)
        {
            _Title.Text = value;
        }

        protected override IParcelable OnSaveInstanceState()
        {
            Bundle bundle = new Bundle();
            bundle.PutInt(KEYNAME, _goalValue);
            return bundle;    
        }
        
        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (state is Bundle)
            {
                var bundle = state as Bundle; 
                if (bundle != null)
                {
                    int value = bundle.GetInt(KEYNAME);
                }
            } else 
                base.OnRestoreInstanceState(state);
        }
    }
}