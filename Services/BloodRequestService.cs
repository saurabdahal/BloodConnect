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
    internal class BloodRequestService
    {
        public async Task<List<BloodRequestWithKey>> fetchAllRequestsByUser(string userId)
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

        public async Task<List<BloodRequestWithKey>> fetchAllRequests()
        {
            try
            {
                var dataSnapshot = await FirebaseInitializer.firebaseClient
                    .Child("BloodRequest")
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
