using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryTitle { get; set; }
        public string goodsType { get; set; }
        public string categoryAdderName { get; set; }

        public int categoryDate { get; set; }
    }
}
