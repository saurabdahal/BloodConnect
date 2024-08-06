using BloodConnect.Helpers;
using BloodConnect.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Services
{
    class DonorRequestService
    {
        public async void CreateRequest(Dictionary<string, string> userDetails)
        {
            BloodRequestModel bloodRequest= new BloodRequestModel
            {
                UserRole = userDetails["role"],
                UserNotes = userDetails["notes"],
                UserId = userDetails["id"],
                Bags = int.Parse(userDetails["bags"]),
                Completed =bool.Parse(userDetails["completed"]),
                RequestDate = userDetails["date"]
            };
            await FirebaseInitializer.firebaseClient.Child("BloodRequest").PostAsync(bloodRequest);
        }

        public async Task<List<BloodRequestModel>> fetchAllRequests(string userId)
        {
            try
            {
                var dataSnapshot = await FirebaseInitializer.firebaseClient
                    .Child("BloodRequest")
                    .OrderBy("UserId")
                    .EqualTo(userId)
                    .OnceAsync<BloodRequestModel>();

                var bloodRequests = new List<BloodRequestModel>();
                foreach (var childSnapshot in dataSnapshot)
                {
                    var request = childSnapshot.Object;
                    if (request != null) 
                    {
                        bloodRequests.Add(request);
                    }
                }

                return bloodRequests;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
    }
}
