using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Microsoft.Maui.Essentials;

namespace Lando
{

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "lando";

    }
}