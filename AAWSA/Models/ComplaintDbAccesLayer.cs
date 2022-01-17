using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAWSA.Models
{
    public class ComplaintDbAccesLayer
    {
        SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=AAWSA;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
