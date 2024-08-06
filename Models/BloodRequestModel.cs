using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    class BloodRequestModel
    {
        public string? UserId { get; set; }
        public string? UserRole { get; set; }

        public string? RequestDate { get; set; }    

        public bool Completed { get; set; }

        public string? UserNotes { get; set; }   

        public int Bags { get; set; }

    }
}
