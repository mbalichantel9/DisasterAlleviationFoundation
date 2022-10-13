using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class DonateGoodsModel : PageModel
    {

        public GoodsDonations donateGoods = new GoodsDonations();
        public class GoodsDonations
        {
            public string goods_title;
            public string goods_no;
            public string goods_description;
            public string goods_date;
            public string goods_category;
            public string goods_activedisaster;
            public string goods_donorname;

        }


        public void OnPost()
        {
            donateGoods.goods_title = Request.Form["goodsTitle"];
            donateGoods.goods_no = Request.Form["goodsNo"];
            donateGoods.goods_description = Request.Form["goodsDescription"];
            donateGoods.goods_date = Request.Form["goodsDate"];
            donateGoods.goods_category = Request.Form["goodsCategory"];
            donateGoods.goods_activedisaster = Request.Form["goodsActivedisaster"];
            donateGoods.goods_donorname = Request.Form["goodsDonorname"];

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO GOODSDONATIONS VALUES (@goodsTitle,@goodsNo,@goodsDescription,@goodsDate,@goodsCategory,@goodsActivedisaster,@goodsDonorname)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@goodsTitle", donateGoods.goods_title);
                        command.Parameters.AddWithValue("@goodsNo", donateGoods.goods_no);
                        command.Parameters.AddWithValue("@goodsDescription", donateGoods.goods_description);
                        command.Parameters.AddWithValue("@goodsDate", donateGoods.goods_date);
                        command.Parameters.AddWithValue("@goodsCategory", donateGoods.goods_category);
                        command.Parameters.AddWithValue("@goodsActivedisaster", donateGoods.goods_activedisaster);
                        command.Parameters.AddWithValue("@goodsDonorname", donateGoods.goods_donorname);


                        command.ExecuteNonQuery();


                    }
                }
                Response.Redirect("/Index");


            }
            catch (Exception goodDonationsError)
            {
                Console.WriteLine(goodDonationsError);
            }


        }
        public void OnGet()
        {
        }
    }
}
