using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Helpers
{
    
    class FirebaseInitializer
    {
        public static readonly FirebaseAuthProvider firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCiS3d - wBcf7KpGHgsxDo87pHMilLeQKD8"));
        public static readonly FirebaseClient firebaseClient = new FirebaseClient("https://bloodconnect-7c36f-default-rtdb.firebaseio.com/");
    }
}
