using BloodConnect.Helpers;
using BloodConnect.Models;
using BloodConnect.Pages;
using BloodConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BloodConnect.ViewModels
{
    internal partial class MediatorSignupFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private ObservableCollection<string> mediatorType;

        [ObservableProperty]
        private string contactNumber;

        [ObservableProperty]
        private string mediatorContactPerson;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string selectedMediatorType;


        private readonly FirebaseAuthProvider firebaseAuth;
        private readonly FirebaseClient firebaseClient;
        private readonly MediatorSignUpService mediatorSignUpService;
        public Command CreateMediatorAccountCommand { get; }

        public MediatorSignupFormViewModel()
        {
            CreateMediatorAccountCommand = new Command(CreateMediatorAccount);
            mediatorSignUpService = new MediatorSignUpService();

            MediatorType = new ObservableCollection<string>
                {
                    "Hospital",
                    "RedCross",
                    "Private Agency"
                };
        }

        private async void CreateMediatorAccount()
        {


            try
            {

                var authId = await FirebaseInitializer.firebaseAuth.CreateUserWithEmailAndPasswordAsync(Email, Password);
                if (authId.FirebaseToken != null)

                {
                    Dictionary<string, string> mediator = new Dictionary<string, string>();

                    mediator.Add("mediatorId", authId.User.LocalId);

                    mediator.Add("fullname", FullName);

                    mediator.Add("mediatortype", selectedMediatorType);
               
                    mediator.Add("mediatoremail", Email);

                    mediator.Add("mediatorphone", ContactNumber);

                    mediator.Add("mediatorcontactperson", MediatorContactPerson);
                    
                    mediator.Add("address", Address);


                    mediatorSignUpService.SignUp(mediator, firebaseClient);

                    Dictionary<string, string> userRole = new Dictionary<string, string>();
                    userRole.Add("userid", authId.User.LocalId);
                    userRole.Add("roletype", "mediator");
                    new UserRoleService().CreateUserRole(userRole);

                    await App.Current.MainPage.DisplayAlert("Success", "Mediator Profile created successfully", "OK");

                    Application.Current.MainPage = new NavigationPage(new Login());
                }


            }
            catch (FirebaseAuthException e)
            {
                // Handle sign-in errors
                App.Current.MainPage.DisplayAlert("Error", $"Firebase Authentication Error: {e.Message}", "OK");
            }
        }
    }
}
