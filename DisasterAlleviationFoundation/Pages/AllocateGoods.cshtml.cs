using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class AllocateGoodsModel : PageModel
    {

        public AllocateGoods allocate = new AllocateGoods();
        public class AllocateGoods
        {
            public string goods_allocationtitle;
            public string goods_allocationqty;
            public string goods_allocationcategory;
            public string goods_allocationdate;
            public string good_allocationdisaster;
            public string goods_allocationdonor;

        }

        public void OnPost()
        {
            allocate.goods_allocationtitle = Request.Form["goodsAllocationTitle"];
            allocate.goods_allocationqty = Request.Form["goodsAllocationQuantity"];
            allocate.goods_allocationcategory = Request.Form["goodsAllocationCategory"];
            allocate.goods_allocationdate = Request.Form["goodsAllocationDate"];
            allocate.good_allocationdisaster = Request.Form["activeDisaster"];
            allocate.goods_allocationdonor = Request.Form["goodsAllocationDonorname"];

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO ALLOCATIONS VALUES (@goodsAllocationTitle,@goodsAllocationQuantity,@goodsAllocationCategory,@goodsAllocationDate,@activeDisaster,@goodsAllocationDonorname)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@goodsAllocationTitle", allocate.goods_allocationtitle);
                        command.Parameters.AddWithValue("@goodsAllocationQuantity", allocate.goods_allocationqty);
                        command.Parameters.AddWithValue("@goodsAllocationCategory", allocate.goods_allocationcategory);
                        command.Parameters.AddWithValue("@goodsAllocationDate", allocate.goods_allocationdate);
                        command.Parameters.AddWithValue("@activeDisaster", allocate.good_allocationdisaster);
                        command.Parameters.AddWithValue("@goodsAllocationDonorname", allocate.goods_allocationdonor);


                        command.ExecuteNonQuery();


                    }
                }
                Response.Redirect("/AdminIndex");


            }
            catch (SqlException goodDonationsError)
            {

                Console.WriteLine(goodDonationsError);
            }

        }



        public void OnGet()
        {
        }
    }
}
