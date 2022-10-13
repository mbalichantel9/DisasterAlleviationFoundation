using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace DisasterAlleviationFoundation.Models
{
    public class GoodsDonations
    {
        [Key]

        public int goodsID { get; set; }
        public string goodsName { get; set; }
        public int numberOfGoods { get; set; }

        public string goodsType { get; set; }

        public string goodsDate { get; set; }
        public string goodsDescription { get; set; }

        public string userId { get; set; }
       


    }
}
