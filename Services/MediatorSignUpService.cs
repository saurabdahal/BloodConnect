using BloodConnect.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using BloodConnect.Helpers;

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

                    MediatorName = mediatorDictionary["fullname"],

                    MediatorType = mediatorDictionary["mediatortype"],
                  
                    MediatorEmail = mediatorDictionary["mediatoremail"],

                    MediatorPhone = mediatorDictionary["mediatorphone"],

                    MediatorContactPerson = mediatorDictionary["mediatorcontactperson"],

                    MediatorAddress = mediatorDictionary["address"],
                };
                await FirebaseInitializer.firebaseClient.Child("Mediator").PostAsync(mediator);
               
            
        
        }
    }
}
