using BloodConnect.Pages.Profile;
using BloodConnect.ViewModels;

namespace BloodConnect.Pages.ServiceRequest;

public partial class DonorRequest : ContentPage
{
	public DonorRequest()
	{
        InitializeComponent();
		BindingContext = new DonorRequestViewModel();
	}

    private async void GoBack(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new DonorProfile());
    }
}