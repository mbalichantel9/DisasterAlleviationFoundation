using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class MoneyDonationsModel : PageModel
    {
        public MoneyDonations moneyDonations = new MoneyDonations();

        public class MoneyDonations
        {
            public string donation_amount;
            public string monetary_donationDate;
            public string monetary_activedisaster;
            public string monetary_donorName;
        }



        public void OnPost()
        {
            moneyDonations.donation_amount = Request.Form["donationAmount"];
            moneyDonations.monetary_donationDate = Request.Form["monetarydonationDate"];
            moneyDonations.monetary_activedisaster = Request.Form["activeDisaster"];
            moneyDonations.monetary_donorName = Request.Form["monetarydonorName"];
           

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO MONETARYDONATIONS VALUES (@donationAmount,@monetarydonationDate,@activeDisaster,@monetarydonorName)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@donationAmount", moneyDonations.donation_amount);
                        command.Parameters.AddWithValue("@monetarydonationDate", moneyDonations.monetary_donationDate);
                        command.Parameters.AddWithValue("@activeDisaster", moneyDonations.monetary_activedisaster);
                        command.Parameters.AddWithValue("@monetarydonorName", moneyDonations.monetary_donorName);
                      

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
