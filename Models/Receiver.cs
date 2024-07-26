using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    internal class Receiver
    {
        public string ReceiverId { get; set }
        public string ReceiverName { get; set; }
        public int ReceiverAge { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmergencyContact { get; set; }
        public string ReceiverBloodGroup { get; set; }
        public string ReceiverAddress { get; set; }
    }
}
