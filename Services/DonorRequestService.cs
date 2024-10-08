﻿using BloodConnect.Helpers;
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

        
    }
}
