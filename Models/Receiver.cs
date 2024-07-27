using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    /// <summary>
    /// Represents a receiver in the BloodConnect system. Contains attributes that defines the receiver's 
    /// identification, contact details, age, blood group, and address.
    /// </summary>
    internal class Receiver
    {
        /// <summary>
        /// Unique identifier for the receiver.
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        /// Full name of the receiver.
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// Age of the receiver.
        /// </summary>
        public int ReceiverAge { get; set; }

        /// <summary>
        /// Email address of the receiver.
        /// </summary>
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Phone number of the receiver.
        /// </summary>
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// Emergency contact information for the receiver.
        /// </summary>
        public string ReceiverEmergencyContact { get; set; }

        /// <summary>
        /// Blood group of the receiver.
        /// </summary>
        public string ReceiverBloodGroup { get; set; }

        /// <summary>
        /// Address of the receiver.
        /// </summary>
        public string ReceiverAddress { get; set; }
    }
}
