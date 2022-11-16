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
        public List<PurchasesItem> purchasesList = new List<PurchasesItem>();

        string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public int totalPurchases;

        public int getTotalPurchases()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);

                connect.Open();

                string commandText = "SELECT SUM(item_amount) FROM PURCHASES ";
                SqlCommand command = new SqlCommand(commandText, connect);

                totalPurchases = (int)command.ExecuteScalar();

            }
            catch (Exception calException)
            {
                Console.WriteLine(calException);
            }
            return totalPurchases;

        }

        public void OnGet()
        {

            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))

                {
                    connect.Open();
                    string commandText = "SELECT * FROM PURCHASES ";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                PurchasesItem myPurchases = new PurchasesItem();

                                myPurchases.id = "" + dataReader.GetInt32(0);
                                myPurchases.itemTitle = dataReader.GetString(1);
                                myPurchases.itemAmount = "" + dataReader.GetInt32(2);
                                myPurchases.itemCategory = dataReader.GetString(3);
                                myPurchases.itemDisaster = dataReader.GetString(4);
                                myPurchases.itemPurchaseDate = dataReader.GetString(5);
                                myPurchases.itemPurchaser = dataReader.GetString(6);

                                purchasesList.Add(myPurchases);

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

        public class PurchasesItem
        {
            public string id;
            public string itemTitle;
            public string itemAmount;
            public string itemCategory;
            public string itemDisaster;
            public string itemPurchaseDate;
            public string itemPurchaser;

        }
    }

}


        
