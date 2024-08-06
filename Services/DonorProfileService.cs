using BloodConnect.Helpers;
using BloodConnect.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Services
{
    internal class DonorProfileService
    {
        public DonorProfileService() { }

        public async Task<Donor> FetchDonorProfile(string donorId)
        {
            Donor donor = null;
            var response = await FirebaseInitializer.firebaseClient
                                .Child("Donor")
                                .OrderBy("DonorId")
                                .EqualTo(donorId)
                                .OnceAsync<Donor>();

            foreach(var d in response)
            {
                donor = d.Object;
                break;
            }

            return donor;
        }
    }
}
