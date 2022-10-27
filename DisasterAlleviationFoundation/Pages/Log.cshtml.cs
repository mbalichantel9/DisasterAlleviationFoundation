using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class LogModel : PageModel
    {
        public loginUser logUser = new loginUser();
        public string user_mail;
        public string user_password;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            user_mail = Request.Form["userEmail"];
            user_password = Request.Form["userPassword"];


            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string commandText = "SELECT * FROM USERS";
                    SqlCommand command = new SqlCommand(commandText, connect);
                        SqlDataReader readData = command.ExecuteReader();

                    while(readData.Read())
                    {
                        if(user_mail.Equals(readData.GetValue(2)) && user_password.Equals(readData.GetValue(4)))
                        {
                            if(readData.GetValue(3).Equals("ADMIN"))
                            {
                                Response.Redirect("AdminIndex");
                            }
                            else
                            {
                                Response.Redirect("Index");
                            }
                        }
                       


                    }    
                }
            }

            catch (Exception logUserError)
            {
                Console.WriteLine(logUserError);
            }


        }

        public class loginUser
        {
            public string user_email;
            public string user_password;
        }
    }
}

