using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewMoneyModel : PageModel
    {
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

                    PurchaseMoney = (int)comandquery.ExecuteScalar();

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
            getMoney();


            
        }
    }
}
