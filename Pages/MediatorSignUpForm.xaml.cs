namespace BloodConnect.Pages;
using BloodConnect.ViewModels;

public partial class MediatorSignUpForm : ContentPage
{
	public MediatorSignUpForm()
	{
		InitializeComponent();
        BindingContext = new MediatorSignupFormViewModel();

    }

    private async void BackToLoginPage(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync(false);

		Application.Current.MainPage = new NavigationPage(new Login());
	}
}