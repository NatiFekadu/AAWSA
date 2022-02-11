using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAWSA.Models;

namespace AAWSA.Models
{
    public class ComplaintDbContext : DbContext 
    {
        public ComplaintDbContext(DbContextOptions options) :base (options)
        {

        }

        public DbSet<Complaint> Complaints { get; set; }
    }
}
