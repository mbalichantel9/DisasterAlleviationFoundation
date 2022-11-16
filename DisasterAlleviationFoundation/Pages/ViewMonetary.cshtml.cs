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
        string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<MoneyDonated> moneyDonationList = new List<MoneyDonated>();

        public int totalDonationsAmount;   
             
       public int getTotalDonations()
        {
            try
            {
                SqlConnection connect = new SqlConnection(connectionString);

                connect.Open();

                string commandText = "SELECT SUM(donation_amount) FROM MONETARYDONATIONS ";
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
                                MoneyDonated myMoney = new MoneyDonated();

                                myMoney.id = "" + dataReader.GetInt32(0);
                                myMoney.donatedAmount = "" + dataReader.GetInt32(1);
                                myMoney.donatedDate = dataReader.GetString(2);
                                myMoney.donatedDisaster = dataReader.GetString(3);
                                myMoney.donatedPerson = dataReader.GetString(4);

                                moneyDonationList.Add(myMoney);

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
          


        }
    }
    
}
