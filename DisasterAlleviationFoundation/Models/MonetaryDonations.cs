using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
namespace DisasterAlleviationFoundation.Models
{
    public class MonetaryDonations
    {
        public class Venue
        {
            [Key]
            public int monetaryId { get; set; }
            public string amount { get; set; }
            public string monetaryDate { get; set; }
            public string donorName { get; set; }

            public int UserID { get; set; }

            



        }
    }
}
