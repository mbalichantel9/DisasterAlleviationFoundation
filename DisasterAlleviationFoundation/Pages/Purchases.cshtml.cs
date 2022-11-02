using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class PurchasesModel : PageModel
    {
        public PurchaseDetails purchases = new PurchaseDetails();
        public class PurchaseDetails
        {
            public string item_title;
            public string item_amount;
            public string item_category;
            public string item_disaster;
            public string item_purchasedate;
            public string purchaser_name;

        }

        public void OnPost()
        {
            purchases.item_title = Request.Form["itemTitle"];
            purchases.item_amount = Request.Form["itemAmount"];
            purchases.item_category = Request.Form["itemCategory"];
            purchases.item_disaster = Request.Form["activeDisaster"];
            purchases.item_purchasedate = Request.Form["itemPurchasedate"];
            purchases.purchaser_name = Request.Form["purchaserName"];
           
            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO PURCHASES VALUES (@itemTitle,@itemAmount,@itemCategory,@activeDisaster,@itemPurchasedate,@purchaserName)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@itemTitle", purchases.item_title);
                        command.Parameters.AddWithValue("@itemAmount", purchases.item_amount);
                        command.Parameters.AddWithValue("@itemCategory", purchases.item_category);
                        command.Parameters.AddWithValue("@activeDisaster", purchases.item_disaster);
                        command.Parameters.AddWithValue("@itemPurchasedate", purchases.item_purchasedate);
                        command.Parameters.AddWithValue("@purchaserName", purchases.purchaser_name);
                   

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
