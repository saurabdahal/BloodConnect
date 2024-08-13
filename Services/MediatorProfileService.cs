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
    internal class MediatorProfileService
    {
        public MediatorProfileService() { }

        public async Task<Mediator> FetchMediatorProfile(string mediatorId)
        {
            Mediator mediator = null;
            var response = await FirebaseInitializer.firebaseClient
                                .Child("Mediator")
                                .OrderBy("MediatorId")
                                .EqualTo(mediatorId)
                                .OnceAsync<Mediator>();

            foreach (var d in response)
            {
                mediator = d.Object;
                break;
            }

            return mediator;
        }
    }
}
