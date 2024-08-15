using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodConnect.Models
{
    internal class BloodRequestWithKey
    {
        public string Key { get; set; }    
        public BloodRequestModel RequestModel { get; set; }

        public Donor Donor { get; set; }
    }
}
