using BloodConnect.Models;
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

        public DonorProfileViewModel() {
            fetchDonorProfile();
            LoadBloodRequests();
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
            // Replace with actual userId retrieval logic
            string userId = Preferences.Get("userId", string.Empty);
            BloodRequests = await new BloodRequestService().fetchAllRequestsByUser(userId);
            if (BloodRequests == null)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "damn", "ok");
            }
            
        }

    }
}
