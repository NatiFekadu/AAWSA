using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AAWSA.Models;
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
        

        [DataType(DataType.Date)]

        [Range (1920,2000)]
        public DateTime BirthDate { get; set; }



        [PersonalData]
       
        [Column(TypeName = "nvarchar(20)")]
        public Role Role { get; set; }


        



        [PersonalData]
    
        [Column(TypeName = "nvarchar(10)")]
        public Gender Gender { get; set; }



        [PersonalData]

       
        [Column(TypeName = "nvarchar(20)")]
        public Branches Branches { get; set; }





    }
}
