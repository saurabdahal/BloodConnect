namespace BloodConnect.Pages;

public partial class ReceiverSignUpForm : ContentPage
{
	public ReceiverSignUpForm()
	{
		InitializeComponent();
	}

    private async void BackToLoginPage(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync(false);

        // Replace the root page with the login page
        Application.Current.MainPage = new NavigationPage(new Login());

    }

}