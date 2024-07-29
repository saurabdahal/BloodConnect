using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
        public static class FirebaseInitializer
        {
            public static void Initialize()
            {
#if ANDROID
        Firebase.FirebaseApp.InitializeApp(Android.App.Application.Context);
#endif
            }
        }

    }
