using BloodConnect.Models;
using BloodConnect.Pages;
using BloodConnect.Pages.ServiceRequest;
using BloodConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.ViewModels
{
    internal partial class DonorProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string fullname;

        [ObservableProperty]
        private string phone;
        [ObservableProperty]
        private string address;

        
        [ObservableProperty]
        private List<BloodRequestWithKey> bloodRequests = new List<BloodRequestWithKey>();

        private string userId = Preferences.Get("userId", string.Empty);

        public Command logoutCommand { get; }

        public Command deleteRequestCommand { get; }


        public DonorProfileViewModel() {
            fetchDonorProfile();
            LoadBloodRequests();

            logoutCommand = new Command(LogoutDonor);
            deleteRequestCommand = new Command<string>(async (key) => await DeleteRequest(key));
        }


        public async void fetchDonorProfile()
        {
            Donor result = await new DonorProfileService().FetchDonorProfile(userId);
            Fullname = result.DonorName;
            Phone = result.DonorPhone;
            Address = result.DonorAddress;


        }

        private async void LoadBloodRequests()
        {
            string userId = Preferences.Get("userId", string.Empty);
            BloodRequests = await new BloodRequestService().fetchAllRequestsByUser(userId);
            if (BloodRequests == null)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "damn", "ok");
            }
            
        }

        private void LogoutDonor()
        {
            Preferences.Remove("userId");
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private async Task DeleteRequest(string key)
        {
           bool response =  await BloodRequestService.DeleteRequestAsync(key);
            if (response)
            {
                await Application.Current.MainPage.DisplayAlert("Delete Successful", "Your request to delete the Donation entry is successfully removed", "ok");
                BloodRequests = await new BloodRequestService().fetchAllRequestsByUser(userId);
            }
        }
    }
}
