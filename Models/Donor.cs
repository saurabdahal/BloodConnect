using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    /// <summary>
    /// Represents a donor in the BloodConnect system. Contains attributes that defines the donor's 
    /// identification, contact details, age, blood group, and address. These information are stored as the part of the signup process.
    /// The Donor would be able to see and modify these details as needed.
    /// </summary>
    internal class Donor
    {
        /// <summary>
        /// Unique identifier for the donor. It helps to locate the donor to make it easier to query.
        /// </summary>
        public string DonorId { get; set; }

        public string password { get; set; }

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
