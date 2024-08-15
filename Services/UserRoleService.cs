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
    internal class UserRoleService
    {
        public async void CreateUserRole(Dictionary<string, string> roles)
        {
            UserRole userRole = new UserRole
            {
                UserId = roles["userid"],
                RoleType = roles["roletype"]
            };
            await FirebaseInitializer.firebaseClient.Child("UserRole").PostAsync(userRole);
        }


        public async Task<UserRole> FetchUserRole(string userId)
        {
            UserRole userRole = null;
            var response = await FirebaseInitializer.firebaseClient
                                .Child("UserRole")
                                .OrderBy("UserId")
                                .EqualTo(userId)
                                .OnceAsync<UserRole>();

            foreach (var d in response)
            {
                userRole = d.Object;
                break;
            }

            return userRole;
        }
    }
}
