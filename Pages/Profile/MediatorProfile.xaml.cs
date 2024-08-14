using BloodConnect.ViewModels;

namespace BloodConnect.Pages.Profile;

public partial class MediatorProfile : ContentPage
{
	public MediatorProfile()
	{
		InitializeComponent();
		BindingContext = new MediatorProfileViewModel();
	}
}