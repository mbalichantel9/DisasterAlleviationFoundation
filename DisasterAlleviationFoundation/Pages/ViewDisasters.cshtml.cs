using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewDisastersModel : PageModel
    {
        public List<DisastersActive> disastersList = new List<DisastersActive>();

        public void OnGet()
        {
            try { 
            string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection connect = new SqlConnection(connectionString))

            {
                connect.Open();
                string commandText = "SELECT * FROM DISASTER";
                using (SqlCommand command = new SqlCommand(commandText, connect))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            DisastersActive disaster = new DisastersActive();
                                disaster.id = "" + dataReader.GetInt32(0);
                                disaster.disasterName = dataReader.GetString(1);
                                disaster.disasterDesc = dataReader.GetString(2);
                                disaster.disasterStartdate = dataReader.GetString(3);
                                disaster.disasterEnddate = dataReader.GetString(4);
                                disaster.disasterState = dataReader.GetString(5);
                                disaster.disasterLocation = dataReader.GetString(6);
                                disaster.disasterAids = dataReader.GetString(7);
                                disastersList.Add(disaster);

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

    }
    public class DisastersActive
{
    public string id;
    public string disasterName;
    public string disasterDesc;
    public string disasterStartdate;
    public string disasterEnddate;
    public string disasterState;
    public string disasterLocation;
    public string disasterAids;

}
        }
   
