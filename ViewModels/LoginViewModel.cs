using BloodConnect.Helpers;
using BloodConnect.Models;
using BloodConnect.Pages.Profile;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodConnect.ViewModels
{
    internal partial class LoginViewModel: ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public Command SignInCommand { get; }

        public LoginViewModel() {
            SignInCommand = new Command(SignIn);
        }

        public async void SignIn()
        {
            //var isSignedIn = await FirebaseInitializer.firebaseAuth.SignInWithEmailAndPasswordAsync("saurab@gmail.com", "saurab123");

            //Preferences.Set("userId", isSignedIn.User.LocalId);
            //Application.Current.MainPage = new NavigationPage(new DonorProfile());

            try
            {
                var isSignedIn = await FirebaseInitializer.firebaseAuth.SignInWithEmailAndPasswordAsync("saurab@gmail.com", "saurab123");
                Preferences.Set("userId", isSignedIn.User.LocalId);
                Application.Current.MainPage = new NavigationPage(new DonorProfile());

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", $"msg = {ex.Message}", "OK");
            }

        }
    }
}
