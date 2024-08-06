using BloodConnect.Helpers;
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
    internal partial class DonorRequestViewModel : ObservableObject
    {
        [ObservableProperty]
        private int bags;

        [ObservableProperty]
        private string notes;

        public Command CreateDonationRequestCommand { get; }


        public DonorRequestViewModel()
        {
            CreateDonationRequestCommand = new Command(CreateDonationRequest);
        }


        private async void CreateDonationRequest()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", Preferences.Get("userId", string.Empty));
            data.Add("bags", Bags.ToString());
            data.Add("date", DateTime.Now.Date.ToString());
            data.Add("role", "donor");
            data.Add("completed", false.ToString());
            data.Add("notes", Notes);

            new DonorRequestService().CreateRequest(data);

            TwilioSendMessage.SendMessage("Thank you for showing interest to save someone's life. You good deed will not go unnoticed.");
            App.Current.MainPage.DisplayAlert("Way To Go", "Thank you for your service. We will get backk to you as soon as possible", "OK");
        }

        
    }
}
