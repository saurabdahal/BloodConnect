using BloodConnect.Helpers;
using BloodConnect.Models;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;

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

                var donorSnapshots = await FirebaseInitializer.firebaseClient
                    .Child("Donor")
                    .OnceAsync<Donor>();

                var donors = donorSnapshots.ToDictionary(d => d.Object.DonorId, d => d.Object);

                foreach (var childSnapshot in dataSnapshot)
                {
                    var request = childSnapshot.Object;
                    if (request != null)
                    {
                        donors.TryGetValue(request.UserId, out var donorVar);

                        bloodRequests.Add(new BloodRequestWithKey
                        {
                            Key = childSnapshot.Key,
                            RequestModel = request,
                            Donor = donorVar
                        });
                    }
                }

                return bloodRequests;
            }
            catch (Exception ex)
            {
                return new List<BloodRequestWithKey>();
            }
        }


        public static async Task<bool> DeleteRequestAsync(string key)
        {
            try
            {
                var dbRef = FirebaseInitializer.firebaseClient.Child("BloodRequest").Child(key);

                await dbRef.DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> ApproveRequestAsync(string key)
        {
            try
            {
                var dbRef = FirebaseInitializer.firebaseClient.Child("BloodRequest").Child(key);

                // Retrieve the current data
                var currentData = await dbRef.OnceSingleAsync<BloodRequestModel>();

                if (currentData != null)
                {
                    // Prepare the updated data
                    var updateData = new BloodRequestModel
                    {
                        Bags = currentData.Bags,
                        Completed = true,
                        RequestDate = currentData.RequestDate,
                        UserId = currentData.UserId,
                        UserNotes = currentData.UserNotes,
                        UserRole = currentData.UserRole
                    };

                    // Set the new value at the specified key
                    await dbRef.PutAsync(updateData);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
