using System;
using Android.Content;

namespace xGauge.Util
{
    class PhoneUtil
    {
        public static void TryCallPhone(Context ctx, string telUrl)
        {
            if (telUrl == null)
                return;
            try
            {
                var callIntent = CreateCallingIntent(telUrl);
                if (callIntent != null)
                {
                    ctx.StartActivity(callIntent);
                }
            }
            catch (Exception ex)
            {
                //SimpleMessage.ShowMessage(ctx, ctx.Resources.GetStringByResourceId(Resource.String.UrlCannotBeNullMessage));
            }
        }

        private static Intent CreateCallingIntent(string telUri)
        {
            if (!string.IsNullOrEmpty(telUri.ToString()))
            {
                Intent callPhoneIntent = new Intent(Intent.ActionCall);
                callPhoneIntent.SetData(Android.Net.Uri.Parse(telUri));
                return callPhoneIntent;
            }
            return null;
        }

    }
}