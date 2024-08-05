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
    internal partial class DonorSignupFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private string fullname;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string age;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string contactNumber;

        [ObservableProperty]
        private string emergencyContactNumber;

        [ObservableProperty]
        private string bloodGroup;

        private readonly FirebaseAuthProvider firebaseAuth;
        private readonly FirebaseClient firebaseClient;
        private readonly DonorSignUpService donorSignUpService;
        public Command CreateDonorAccountCommand { get; }

        public DonorSignupFormViewModel()
        {
            firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCiS3d - wBcf7KpGHgsxDo87pHMilLeQKD8"));
            firebaseClient = new FirebaseClient("https://bloodconnect-7c36f-default-rtdb.firebaseio.com/");

            CreateDonorAccountCommand = new Command(CreateDonorAccount);
            donorSignUpService = new DonorSignUpService();
        }

        private async void CreateDonorAccount()
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
                    Dictionary<string, string> donor = new Dictionary<string, string>();

                    donor.Add("donorId", authId.User.LocalId);
                    donor.Add("fullname", Fullname);
                    donor.Add("age", Age);
                    donor.Add("address", Address);
                    donor.Add("bloodgroup", BloodGroup);
                    donor.Add("donoremail", Email);
                    donor.Add("emergencycontact", EmergencyContactNumber);
                    donor.Add("donorphone", ContactNumber);

                  
                    donorSignUpService.SignUp(donor, firebaseClient);
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
