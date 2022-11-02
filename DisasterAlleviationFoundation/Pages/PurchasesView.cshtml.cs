using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;


namespace DisasterAlleviationFoundation.Pages
{
    public class PurchasesViewModel : PageModel
    {
        public List<Purchases> purchasesList = new List<Purchases>();
        Purchases purchaseAmt = new Purchases();

        public int totalDonationsAmount;

        public int getTotalDonations()
        {
            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection connect = new SqlConnection(connectionString);


                connect.Open();

                string commandText = "SELECT SUM(item_amount) FROM PURCHASES ";
                SqlCommand command = new SqlCommand(commandText, connect);

                totalDonationsAmount = (int)command.ExecuteScalar();




            }
            catch (Exception calException)
            {
                Console.WriteLine(calException);
            }
            return totalDonationsAmount;

        }

        public void OnGet()
        {

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {
                    connect.Open();
                    string commandText = "SELECT * FROM PURCHASES";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {


                            while (dataReader.Read())
                            {
                                purchaseAmt.id = "" + dataReader.GetInt32(0);
                                purchaseAmt.itemName = dataReader.GetString(1);
                                purchaseAmt.itemAmount = dataReader.GetInt32(2);
                                purchaseAmt.itemCategory = dataReader.GetString(3);
                                purchaseAmt.itemPurchaseDate = dataReader.GetString(4);
                                purchaseAmt.itemDisaster = dataReader.GetString(5);
                                purchaseAmt.itemPurchaserName = dataReader.GetString(6);
                                purchasesList.Add(purchaseAmt);

                            }




                        }
                    }
                }

            }
            catch (Exception listError)
            {
                Console.WriteLine(listError);
            }

        }
        public class Purchases
        {
            public string id;
            public string itemName;
            public int itemAmount;
            public string itemCategory;
            public string itemPurchaseDate;
            public string itemDisaster;
            public string itemPurchaserName;



        }
    }
}
