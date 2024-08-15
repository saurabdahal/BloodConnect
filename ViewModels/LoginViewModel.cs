using BloodConnect.Helpers;
using BloodConnect.Models;
using BloodConnect.Pages.Profile;
using BloodConnect.Services;
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
            try
            {
                var isSignedIn = await FirebaseInitializer.firebaseAuth.SignInWithEmailAndPasswordAsync(username, password);
                Preferences.Set("userId", isSignedIn.User.LocalId);
                UserRole userRole = await new UserRoleService().FetchUserRole(isSignedIn.User.LocalId);
                switch (userRole.RoleType)
                {
                    case "donor":
                        Application.Current.MainPage = new NavigationPage(new DonorProfile());
                        break;
                    case "receiver":
                        Application.Current.MainPage = new NavigationPage(new DonorProfile());
                        break;
                    case "mediator":
                        Application.Current.MainPage = new NavigationPage(new MediatorProfile());
                        break;
                    default:
                        App.Current.MainPage.DisplayAlert("Error", "Invalid User Role", "OK");
                        break;

                }
                

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", $"msg = {ex.Message}", "OK");
            }

        }
    }
}
