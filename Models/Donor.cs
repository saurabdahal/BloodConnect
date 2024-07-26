using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    internal class Donor
    {
        public string DonorId { get; set }
        public string DonorName { get; set; }
        public int DonorAge { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        public string DonorEmergencyContact {get; set;}
        public string DonorBloodGroup { get;set; }
        public string DonorAddress { get; set; }
    }
}
