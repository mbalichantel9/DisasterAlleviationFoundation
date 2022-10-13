using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class DisasterAddModel : PageModel
    {
        public DisasterDetails addDisaster = new DisasterDetails();

        public void OnGet()
        {
        }

        public class DisasterDetails
        {
            public string disaster_name;
            public string disaster_description;
            public string disaster_startDate;
            public string disaster_endDate;
            public string disaster_state;
            public string disaster_location;
            public string disaster_aids;

        }

        public void OnPost()
        {
            addDisaster.disaster_name = Request.Form["disasterName"];
            addDisaster.disaster_description = Request.Form["disasterDescription"];
            addDisaster.disaster_startDate = Request.Form["disasterStartDate"];
            addDisaster.disaster_endDate = Request.Form["disasterEndDate"];
            addDisaster.disaster_state = Request.Form["disasterState"];
            addDisaster.disaster_location = Request.Form["disasterlocation"];
            addDisaster.disaster_aids = Request.Form["disasterAids"];

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string commandText = "INSERT INTO DISASTER VALUES (@disastername,@disasterDescription,@disasterStartDate,@disasterEndDate,@disasterState,@disasterlocation,@disasterAids)";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {

                        command.Parameters.AddWithValue("@disastername", addDisaster.disaster_name);
                        command.Parameters.AddWithValue("@disasterDescription", addDisaster.disaster_description);
                        command.Parameters.AddWithValue("@disasterStartDate", addDisaster.disaster_startDate);
                        command.Parameters.AddWithValue("@disasterEndDate", addDisaster.disaster_endDate);
                        command.Parameters.AddWithValue("@disasterState", addDisaster.disaster_state);
                        command.Parameters.AddWithValue("@disasterlocation", addDisaster.disaster_location);
                        command.Parameters.AddWithValue("@disasterAids", addDisaster.disaster_aids);

                        command.ExecuteNonQuery();

                    }
                }
                    Response.Redirect("/Index");
                            
            }
            catch (Exception disasterError)
            {
                Console.WriteLine(disasterError);
            }

        }

       
    }
}
