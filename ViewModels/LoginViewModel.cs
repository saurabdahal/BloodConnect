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
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

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
            var message = MessageResource.Create(
    new PhoneNumber("+7059216266"),
    from: new PhoneNumber("+7723104281"),
    body: "Hello World!"
);
            Application.Current.MainPage = new NavigationPage(new DonorProfile());
            //try
            //{
            //    var isSignedIn = await FirebaseInitializer.firebaseAuth.SignInWithEmailAndPasswordAsync(Username, Password);
            //    var phone = await FirebaseInitializer.firebaseClient.Child("Donor").OrderBy("DonorEmail").EqualTo("saurab@gmail.com").OnceSingleAsync<Donor>();
            //        App.Current.MainPage.DisplayAlert("phone", $" number = {phone.DonorName}", "OK");

            //}catch (Exception ex)
            //{
            //    App.Current.MainPage.DisplayAlert("Error", $"msg = {ex.Message}", "OK");
            //}
        }
    }
}
