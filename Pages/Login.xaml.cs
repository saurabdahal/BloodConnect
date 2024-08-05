using BloodConnect.ViewModels;

namespace BloodConnect.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    private async void DefineRole(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DefineRole());
    }
}