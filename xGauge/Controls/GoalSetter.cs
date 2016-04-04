using System;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Content.Res;

namespace xGauge.Controls
{
    public class GoalSetter : LinearLayout
    {
        private ImageButton _BtnPlus;
        private ImageButton _BtnMinus;
        private EditText _EditTextGoalValue;
        private TextView _Title;
        private string _externalTitle = string.Empty;

        private const string KEYNAME = "GoalValue";
        private int _goalValue;

       
        public int Value
        {
            get
            {
                return _goalValue;
            }
        }

        public GoalSetter(Context ctx) : base(ctx)
        {
            Init();
        }
        
        // Fire up pretty late 
        public GoalSetter(Context ctx, IAttributeSet attr) : base(ctx, attr)
        {
            Init();

            TypedArray ta = this.Context.ObtainStyledAttributes(attr, Resource.Styleable.GoalSetter, 0, 0);
            if (ta != null)
                _externalTitle = ta.GetString(Resource.Styleable.GoalSetter_Title);

            if (_externalTitle != null)
                _Title.Text = _externalTitle;
        }

        public GoalSetter(Context ctx, IAttributeSet attr, int defStyleAttr) : base(ctx, attr, defStyleAttr)
        {
            Init();
        }

        public GoalSetter(Context ctx, IAttributeSet attr, int defStyleAttr, int defStyleRes) : base(ctx, attr, defStyleAttr, defStyleRes)
        {
            Init();
        }
        
        private void Init()
        {
            var view = LayoutInflater.From(Context).Inflate(Resource.Layout.goalctrl_layout, this);
            _BtnPlus = FindViewById<ImageButton>(Resource.Id.imageButtonPlus);
            _BtnMinus = FindViewById<ImageButton>(Resource.Id.imageButtonMinus);
            _EditTextGoalValue = FindViewById<EditText>(Resource.Id.editTextGoalValue);
            _Title = FindViewById<TextView>(Resource.Id.textVewTitle);

            if (_BtnPlus != null)
                _BtnPlus.Click += _BtnPlus_Click;

            if (_BtnMinus != null)
                _BtnMinus.Click += _BtnMinus_Click;

            UpdateControl();

        }

        private void _BtnMinus_Click(object sender, EventArgs e)
        {
            if (_goalValue <= 0)
                _goalValue = 0;
            else
                _goalValue--;

            UpdateControl();
        }

        private void _BtnPlus_Click(object sender, EventArgs e)
        {
            _goalValue++;
            UpdateControl();
        }

        private void UpdateControl()
        {
            if (_EditTextGoalValue != null)
                _EditTextGoalValue.Text = _goalValue.ToString();
        }

        public void SetValue(int value)
        {
            _goalValue = value;
            UpdateControl();
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
            if (state != null)
            {
                if (state is Bundle)
                {
                    var bundle = state as Bundle;
                    if (bundle != null)
                    {
                        int value = bundle.GetInt(KEYNAME);
                    }
                }
            }
            else
                base.OnRestoreInstanceState(state);
        }
    }
}