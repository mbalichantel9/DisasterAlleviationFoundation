using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class Disaster
    {
        [Key]
        public int disasterId { get; set; }

        public string disasterName { get; set; }

        public string disasterDescription { get; set; }
        public int startDate { get; set; }

        public string endDate { get; set; }

        public string location { get; set; }
        public string disasterAids { get; set; }

    }
}
