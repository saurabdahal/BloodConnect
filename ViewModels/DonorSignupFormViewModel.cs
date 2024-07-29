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
        private string username;

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
            // var authId = await firebaseAuth.CreateUserWithEmailAndPasswordAsync("saurab@gmail.com", "!Dahal123");
            var isSignedIn = await firebaseAuth.SignInWithEmailAndPasswordAsync("gsaurab@gmail.com", "!Dahal123");
            if (isSignedIn.User.Email != null)
            {
                await firebaseClient.Child("Donor")
                    .PostAsync(new Donor
                    {

                        DonorName = "dadas",
                        username = "saurab",
                        password = "dahal",
                        DonorAge = 28,
                        DonorAddress = "dadadas",
                        DonorBloodGroup = "A",
                        DonorEmail = "dasdadadadad",
                        DonorEmergencyContact = "646464646",
                        DonorId = "userid-1",
                        DonorPhone = "31313131313"
                    }
                    );
            }
            else
            {
                App.Current.MainPage.DisplayAlert("ERROR", "Error signing in", "OK");
            }
        }

    }
}
