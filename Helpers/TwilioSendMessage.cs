using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace BloodConnect.Helpers
{
    class TwilioSendMessage
    {
        public TwilioSendMessage() { }

        public static void SendMessage(string message)
        {
             MessageResource.Create(
                new PhoneNumber("+17059216266"),
                from: new PhoneNumber("+17723104281"),
                body: message
                );
        }
    }
}
