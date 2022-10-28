using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewMonetaryModel : PageModel
    {
        public List<MoneyDonated> donationList = new List<MoneyDonated>();


        public int AvailableMoney;
        public int PurchaseMoney;
        public int availableFunds;
        public int getMoney()
        {
            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection connect = new SqlConnection(connectionString);


                connect.Open();

                string commandText = "SELECT SUM(donation_amount) FROM MONETARYDONATIONS ";
                SqlCommand command = new SqlCommand(commandText, connect);

                AvailableMoney = (int)command.ExecuteScalar();

                string query = "SELECT SUM(item_amount) FROM PURCHASES ";
                SqlCommand comandquery = new SqlCommand(query, connect);

                PurchaseMoney = (int)command.ExecuteScalar();

                availableFunds = AvailableMoney - PurchaseMoney;


            }
            catch (Exception calException)
            {
                Console.WriteLine(calException);
            }
            return availableFunds;

        }


        public void OnGet()
        {

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {
                    connect.Open();
                    string commandText = "SELECT * FROM MONETARYDONATIONS";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                MoneyDonated moneies = new MoneyDonated();
                                moneies.id = "" + dataReader.GetInt32(0);
                                moneies.donatedAmount = "" + dataReader.GetInt32(1);
                                moneies.donatedDate = dataReader.GetString(2);
                                moneies.donatedDisaster = dataReader.GetString(3);
                                moneies.donatedPerson = dataReader.GetString(4);
                                donationList.Add(moneies);

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
        public class MoneyDonated
        {
            public string id;
            public string donatedAmount;
            public string donatedDate;
            public string donatedDisaster;
            public string donatedPerson;
            public int AvailableMoney;
            public int PurchaseMoney;
            public int availableFunds;


        }
    }
    
}
