using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Firebase;

namespace BloodConnect
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.SmallestScreenSize | ConfigChanges.Density | ConfigChanges.Orientation)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
<<<<<<< HEAD
           // FirebaseApp.InitializeApp(this);
=======
>>>>>>> cd543fd4fbb9d01d7a765356066a49064c430443
        }
    }
}
