using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Models
{
    public class Admin
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string userType { get; set; }
        public string password { get; set; }
        public string confrmPassword { get; set; }
    }
}
