using BloodConnect.Models;
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

        public Command CreateDonorAccountCommand { get; }

        public DonorSignupFormViewModel()
        {
            firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCiS3d - wBcf7KpGHgsxDo87pHMilLeQKD8"));
            firebaseClient = new FirebaseClient("https://bloodconnect-7c36f-default-rtdb.firebaseio.com/");

            CreateDonorAccountCommand = new Command(CreateDonorAccount);
        }

        private async void CreateDonorAccount()
        {
            try
            {
                // var authId = await firebaseAuth.CreateUserWithEmailAndPasswordAsync("saurab@gmail.com", "!Dahal123");
                var isSignedIn = await firebaseAuth.SignInWithEmailAndPasswordAsync("saurab@gmail.com", "!Dahal123");
                if (isSignedIn.User.Email != null)
                {
                    var authResult = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(Email, Password);
                    if (authResult.User != null)
                    {
                        // User created successfully, proceed with saving donor data
                        var donor = new Donor
                        {
                            DonorName = Fullname,
                            username = Username,
                            // Consider hashing password before storing
                            password = Password,
                            DonorAge = int.Parse(Age),
                            DonorAddress = Address,
                            DonorBloodGroup = BloodGroup,
                            DonorEmail = authResult.User.Email,
                            DonorEmergencyContact = EmergencyContactNumber,
                            DonorPhone = ContactNumber
                        };

                        await firebaseClient.Child("Donor").PostAsync(donor);

                        // Handle successful account creation (e.g., navigation)
                    }
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
