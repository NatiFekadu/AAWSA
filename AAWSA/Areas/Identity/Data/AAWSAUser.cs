using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AAWSA.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AAWSAUser class
    public class AAWSAUser : IdentityUser
    {
        [PersonalData]
        
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }



        [PersonalData]

        [Column(TypeName = "nvarchar(15)")]
        public string Role { get; set; }


        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }



        [PersonalData]

        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }



        [PersonalData]

        [Column(TypeName = "nvarchar(10)")]
        public string Branches { get; set; }





    }
}
