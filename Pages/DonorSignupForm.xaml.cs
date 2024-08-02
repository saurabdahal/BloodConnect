namespace BloodConnect.Pages;
using BloodConnect.ViewModels;
public partial class DonorSignupForm : ContentPage
{
	public DonorSignupForm()
	{
		InitializeComponent();
		BindingContext = new DonorSignupFormViewModel();
	}

	private async void BackToLoginPage(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync(false);

		Application.Current.MainPage = new NavigationPage(new Login());
	}

	
}