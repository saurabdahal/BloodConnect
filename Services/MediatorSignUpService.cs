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
    internal class MediatorSignUpService
    {
        public MediatorSignUpService() { }  
         public async void SignUp(Dictionary<string, string> mediatorDictionary, FirebaseClient firebaseClient)
        {
           
                Mediator mediator = new Mediator
                {
                    MediatorId = mediatorDictionary["mediatorId"],

                    MediatorName = mediatorDictionary["fullName"],

                    MediatorType = mediatorDictionary["mediatorType"],
                  
                    MediatorEmail = mediatorDictionary["mediatorEmail"],

                    MediatorPhone = mediatorDictionary["mediatorPhone"],

                    MediatorContactPerson = mediatorDictionary["mediatorContactPerson"],

                    MediatorAddress = mediatorDictionary["address"],
                };
                await firebaseClient.Child("Mediator").PostAsync(mediator);
               
            
        
        }
    }
}
