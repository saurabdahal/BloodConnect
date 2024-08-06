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

        public async Task<List<BloodRequestWithKey>> fetchAllRequests(string userId)
        {
            try
            {
                var dataSnapshot = await FirebaseInitializer.firebaseClient
                    .Child("BloodRequest")
                    .OrderBy("UserId")
                    .EqualTo(userId)
                    .OnceAsync<BloodRequestModel>();

                var bloodRequests = new List<BloodRequestWithKey>();
                foreach (var childSnapshot in dataSnapshot)
                {
                    var request = childSnapshot.Object;
                    if (request != null) 
                    {
                        bloodRequests.Add(new BloodRequestWithKey
                        {
                            Key = childSnapshot.Key,
                            RequestModel = request
                        });
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
