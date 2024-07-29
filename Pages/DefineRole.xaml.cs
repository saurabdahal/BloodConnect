namespace BloodConnect.Pages;

public partial class DefineRole : ContentPage
{
	public DefineRole()
	{
		InitializeComponent();
        rolePicker.SelectedIndex = 0;
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
		Picker picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if(selectedIndex != -1)
		{
            if(selectedIndex == 0)
            {
                selectedRoleDescription.Text = "";
            }
			else if(selectedIndex == 1)
			{
                selectedRoleDescription.Text = "Thank you for being a donor. As a Donor you can request to donate your precious blood that will definetely save someone's life.";
            }
            else if(selectedIndex == 2)
			{
                selectedRoleDescription.Text = "Do not worry we care for you life. As a Receiver you can request to purchase the blood. Do not give up hope. We are with you.";
            }
            else if (selectedIndex == 3)
			{
                selectedRoleDescription.Text = "Thank you for acting as a Mediater. As a Mediater you can manage donations and help those in need of the blood";
            }
        }
    }

    private async void SelectPage(object sender, EventArgs e)
    {
        int selectedRole = rolePicker.SelectedIndex;
        if (selectedRole == -1) {
            await DisplayAlert("Error","Please seleted a role first", "OK");
            return;
        }

        switch (selectedRole)
        {
            case 1:
                selectedRoleDescription.Text = "Boom, you are a donor";
                break;
            case 2:
                selectedRoleDescription.Text = "Boom, you are a receiver";
                break;
            case 3:
                selectedRoleDescription.Text = "Boom, you are a mediator";
                break;
            default:
                await DisplayAlert("Error", "Your selection is not valid. Please select a role first", "OK");
                return;
        }
    }
}