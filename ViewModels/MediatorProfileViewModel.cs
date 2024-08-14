using BloodConnect.Models;
using BloodConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.ViewModels
{
    internal partial class MediatorProfileViewModel: ObservableObject
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

        public MediatorProfileViewModel()
        {
            FetchMediatorProfile();
            LoadBloodRequests();
        }

        public async void FetchMediatorProfile() {
            Mediator result = await new MediatorProfileService().FetchMediatorProfile(userId);
            Fullname = result.MediatorName;
            Phone = result.MediatorPhone;
            Address = result.MediatorAddress;
        }


        public async void LoadBloodRequests() {
            string userId = Preferences.Get("userId", string.Empty);
            BloodRequests = await new BloodRequestService().fetchAllRequests();
            if (BloodRequests == null)
            {
                await Application.Current.MainPage.DisplayAlert("OK", "damn", "ok");
            }
        }

    }
}
