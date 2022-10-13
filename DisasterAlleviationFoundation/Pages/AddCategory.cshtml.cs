using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class AddCategoryModel : PageModel
    {
        public CategoryDetails addCategory = new CategoryDetails();


        public class CategoryDetails
        {
            public string category_name;
            public string category_description;
            public string category_adddate;
        }


        public void OnPost()
        {
            addCategory.category_name = Request.Form["categoryName"];
            addCategory.category_description = Request.Form["categoryDescription"];
            addCategory.category_adddate = Request.Form["categoryDate"];
          

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {

                    connect.Open();
                    string commandText = "INSERT INTO CATEGORIES VALUES (@categoryName,@categoryDescription,@categoryDate)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@categoryName", addCategory.category_name);
                        command.Parameters.AddWithValue("@categoryDescription", addCategory.category_description);
                        command.Parameters.AddWithValue("@categoryDate", addCategory.category_adddate);
                      


                        command.ExecuteNonQuery();


                    }
                }
                Response.Redirect("/AdminIndex");


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
