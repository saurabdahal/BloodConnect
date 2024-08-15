using BloodConnect.Models;
using BloodConnect.Pages;
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

        public Command logoutCommand { get; }
        public Command approveRequestCommand { get; }



        public MediatorProfileViewModel()
        {
            FetchMediatorProfile();
            LoadBloodRequests();

            logoutCommand = new Command(LogoutDonor);
            approveRequestCommand = new Command<string>(async (key) => await ApproveRequest(key));


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

        private void LogoutDonor()
        {
            Preferences.Remove("userId");
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private async Task ApproveRequest(string key)
        {
            bool response = await BloodRequestService.ApproveRequestAsync(key);
            if(response)
            {
                await Application.Current.MainPage.DisplayAlert("Successful", "Request approved", "OK");
                BloodRequests = await new BloodRequestService().fetchAllRequests();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Successful", "Error approving request", "OK");
            }
        }

    }
}
