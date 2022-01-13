using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Models
{
    public class Complaint
    {
        public int id { get; set; }
        public string Name{ get; set; }

        public int House_number { get; set; }

        public int Phone_number { get; set; }
        public string Wereda { get; set; }

        public string Subcity{ get; set; }

        public string caseType { get; set; }

        public string ComplaintType { get; set; }

        public string Status { get; set; }

        public string Recipient { get; set; }


    }
}
