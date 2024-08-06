using BloodConnect.Pages.ServiceRequest;
using BloodConnect.ViewModels;

namespace BloodConnect.Pages.Profile;

public partial class DonorProfile : ContentPage
{
	public DonorProfile()
	{
		InitializeComponent();
		BindingContext = new DonorProfileViewModel(); 
	}

	public async void NavigateToDonationRequestPage(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new DonorRequest());

    }


}