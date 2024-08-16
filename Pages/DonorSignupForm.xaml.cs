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

    private void OnAgeUnfocused(object sender, FocusEventArgs e)
    {
        var entry = (Entry)sender;
        if (int.TryParse(entry.Text, out int age))
        {
            if (age <= 18)
            {
                entry.TextColor = Colors.Red;
                DisplayAlert("Invalid Age", "Age must be greater than 18.", "OK");
            }
            else
            {
                entry.TextColor = Colors.Black;
            }
        }
        else
        {
            entry.TextColor = Colors.Red;
            DisplayAlert("Invalid Input", "Please enter a valid age.", "OK");
        }
    }

}