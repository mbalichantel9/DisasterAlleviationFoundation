using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DisasterAlleviationFoundation.Models
{
    public class Users
    {

        public class DJ
        {
            [Key]
            public int userId { get; set; }
            public string userName { get; set; }
            public string userType {get; set; }
            public string password { get; set; }
            public string confrmPassword { get; set; }
        }

    }
}
