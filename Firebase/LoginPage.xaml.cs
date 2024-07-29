using Microsoft.Maui.Controls;
using Firebase.Auth;
using System;
using Firebase.Auth.Providers;

namespace BloodConnect
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCiS3d-wBcf7KpGHgsxDo87pHMilLeQKD8"));
                var authResult = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                if (authResult.User != null)
                {
                    await DisplayAlert("Success", "Logged in successfully!", "OK");
                    // Navigate to the main page
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        async void OnSignUpClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("YOUR_API_KEY"));
                var authResult = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                if (authResult.User != null)
                {
                    await DisplayAlert("Success", "User created successfully!", "OK");
                    // Navigate to the main page
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
