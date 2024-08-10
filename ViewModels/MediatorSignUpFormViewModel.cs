using BloodConnect.Models;
using BloodConnect.Pages;
using BloodConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Controls;
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
        private string mediatorType;


        [ObservableProperty]
        private string contactNumber;

        [ObservableProperty]
        private string mediatorContactPerson;

        [ObservableProperty]
        private string address;


        private readonly FirebaseAuthProvider firebaseAuth;
        private readonly FirebaseClient firebaseClient;
        private readonly MediatorSignUpService mediatorSignUpService;
        public Command CreateMediatorAccountCommand { get; }

        public MediatorSignupFormViewModel()
        {
            firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCiS3d - wBcf7KpGHgsxDo87pHMilLeQKD8"));
            firebaseClient = new FirebaseClient("https://bloodconnect-7c36f-default-rtdb.firebaseio.com/");

            CreateMediatorAccountCommand = new Command(CreateMediatorAccount);
            mediatorSignUpService = new MediatorSignUpService();
        }

        private async void CreateMediatorAccount()
        {


            try
            {

                var authId = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(Email, Password);

                //var isSignedIn = await firebaseAuth.SignInWithEmailAndPasswordAsync("saurab@gmail.com", "!Dahal123");
                if (authId.FirebaseToken != null)

                {
                    // var authResult = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(Email, Password);


                    // User created successfully, proceed with saving donor data
                    // Creating a HashMap with keys of type string and values of type int
                    Dictionary<string, string> mediator = new Dictionary<string, string>();

                    mediator.Add("mediatorId", authId.User.LocalId);

                    mediator.Add("fullname", FullName);

                    mediator.Add("mediatortype", MediatorType);
               
                    mediator.Add("mediatoremail", Email);

                    mediator.Add("mediatorphone", ContactNumber);

                    mediator.Add("mediatorcontactperson", MediatorContactPerson);
                    
                    mediator.Add("address", Address);


                    mediatorSignUpService.SignUp(mediator, firebaseClient);
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
