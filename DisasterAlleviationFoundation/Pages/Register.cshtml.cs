using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class RegisterModel : PageModel
    {
        public UserRegister userRegister = new UserRegister();

        public void OnGet()
        {
        }

        public class UserRegister
        {
            public string user_firstname;
            public string user_email;
            public string user_type;
            public string user_password;
            public string user_confirmpassword;
        }
        public void OnPost()
        {
            userRegister.user_firstname = Request.Form["userFirstname"];
            userRegister.user_email = Request.Form["userEmail"];
            userRegister.user_type = Request.Form["userType"];
            userRegister.user_password = Request.Form["userPassword"];
            userRegister.user_confirmpassword = Request.Form["userConfirmpassword"];

            try
            {
                
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO USERS VALUES (@userFirstname,@userEmail,@userType,@userPassword,@userConfirmpassword);";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        command.Parameters.AddWithValue("@userFirstname", userRegister.user_firstname);
                        command.Parameters.AddWithValue("@userEmail", userRegister.user_email);
                        command.Parameters.AddWithValue("@userType", userRegister.user_type);
                        command.Parameters.AddWithValue("@userPassword", userRegister.user_password);
                        command.Parameters.AddWithValue("@userConfirmpassword", userRegister.user_confirmpassword);

                        command.ExecuteNonQuery();

                    }
                }
                Response.Redirect("/Log");

            }
            catch (Exception userRegError)
            {
                Console.WriteLine(userRegError);
                return;
            }



        }


    }


}
