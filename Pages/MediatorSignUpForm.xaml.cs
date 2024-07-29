namespace BloodConnect.Pages;

public partial class MediatorSignUpForm : ContentPage
{
	public MediatorSignUpForm()
	{
		InitializeComponent();
	}

	private async void BackToLoginPage(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync(false);

		Application.Current.MainPage = new NavigationPage(new Login());
	}
}