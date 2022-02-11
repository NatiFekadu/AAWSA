using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AAWSA.Models
{
    public class Complaint
    {
        public int id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        [DisplayName("FirstName")]
        public string FirstName{ get; set; }


        [DisplayName("LastName")]
        public string LastName { get; set; }


        [DisplayName("Branch")]
        public Branches Branches { get; set; }


        [DisplayName("Special_Place_Name")]
        public string Special_Place_Name { get; set; }

        public Status status { get; set; }


        [DisplayName("House Number")]

        
        public int HouseNumber { get; set; }


        [DisplayName("PhoneNumber")]
        //  [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        //[Phone]

        public int PhoneNumber { get; set; }
        
        public SubCity Subcity { get; set; }

        public string Woreda { get; set; }

        

        public string CaseType { get; set; }

        public string Complaint_Type { get; set; }


    }
}
