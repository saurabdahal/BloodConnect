using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    /// <summary>
    /// Represents a donor in the BloodConnect system. Contains attributes that defines the donor's 
    /// identification, contact details, age, blood group, and address.
    /// </summary>
    internal class Donor
    {
        /// <summary>
        /// Unique identifier for the donor.
        /// </summary>
        public string DonorId { get; set; }

        /// <summary>
        /// Full name of the donor.
        /// </summary>
        public string DonorName { get; set; }

        /// <summary>
        /// Age of the donor.
        /// </summary>
        public int DonorAge { get; set; }

        /// <summary>
        /// Email address of the donor.
        /// </summary>
        public string DonorEmail { get; set; }

        /// <summary>
        /// Phone number of the donor.
        /// </summary>
        public string DonorPhone { get; set; }

        /// <summary>
        /// Emergency contact information for the donor.
        /// </summary>
        public string DonorEmergencyContact { get; set; }

        /// <summary>
        /// Blood group of the donor.
        /// </summary>
        public string DonorBloodGroup { get; set; }

        /// <summary>
        /// Address of the donor.
        /// </summary>
        public string DonorAddress { get; set; }
    }
}
