using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewAllocationsModel : PageModel
    {
        public List<Allocations> allocationList = new List<Allocations>();
        Allocations allocated = new Allocations();

        public int allocatedGoodsQty;

        public int getAllocationsTotal()
        {
            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection connect = new SqlConnection(connectionString);


                connect.Open();

                string commandText = "SELECT SUM(goods_allocationqty) FROM ALLOCATIONS";
                SqlCommand command = new SqlCommand(commandText, connect);

                allocatedGoodsQty = (int)command.ExecuteScalar();




            }
            catch (Exception calException)
            {
                Console.WriteLine(calException);
            }
            return allocatedGoodsQty;

        }

        public void OnGet()
        {

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {
                    connect.Open();
                    string commandText = "SELECT * FROM ALLOCATIONS";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {


                            while (dataReader.Read())
                            {
                                allocated.id = "" + dataReader.GetInt32(0);
                                allocated.goodsAllocationtitle = dataReader.GetString(1);
                                allocated.goodsAllocationqty = "" + dataReader.GetInt32(2);
                                allocated.goodAllocationdisaster = dataReader.GetString(5);
                                
                                allocationList.Add(allocated);

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
        public class Allocations
        {
            public string id;
            public string goodsAllocationtitle;
            public int goodsAllocationqty;
            public string goodAllocationdisaster;

        
        }
    }
}

