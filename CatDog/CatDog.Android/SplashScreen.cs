
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.Threading;

namespace CatDog.Droid
{
    [Activity(Label = "CatDog", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", NoHistory = true,
       MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Thread.Sleep(2000);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}