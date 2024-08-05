using BloodConnect.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace BloodConnect.Services
{
    internal class DonorSignUpService
    {
        public DonorSignUpService()
        {
        }
        public async void SignUp(Dictionary<string, string> donorDictionary, FirebaseClient firebaseClient)
        {
           
                Donor donor = new Donor
                {
                    DonorName = donorDictionary["fullname"],

                    DonorAge = int.Parse(donorDictionary["age"]),


                    DonorAddress = donorDictionary["address"],
                    DonorBloodGroup = donorDictionary["bloodgroup"],
                    DonorEmail = donorDictionary["donoremail"],
                    DonorEmergencyContact = donorDictionary["emergencycontact"],
                    DonorPhone = donorDictionary["donorphone"]
                };
                await firebaseClient.Child("Donor").PostAsync(donor);
               
            
        
        }
    }

}
