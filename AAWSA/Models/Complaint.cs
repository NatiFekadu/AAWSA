using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Models
{
    public class Complaint
    {
        public int id { get; set; }

        public DateTime date { get; set; }


        
        public string First_Name{ get; set; }

        public Branches Branches { get; set; }

        public string Special_Place_Name { get; set; }

        public Status status { get; set; }

        public int House_number { get; set; }

        public int Phone_number { get; set; }

        public SubCity Subcity { get; set; }

        public string Woreda { get; set; }

        

        public string CaseType { get; set; }

        public string ComplaintType { get; set; }


    }
}
