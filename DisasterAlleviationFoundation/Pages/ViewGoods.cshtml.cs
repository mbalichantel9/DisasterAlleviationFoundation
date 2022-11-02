using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewGoodsModel : PageModel
    {
        public List<GoodsDonated> donationList = new List<GoodsDonated>();
        public int noOfGoodsDonated;

        public int countGoods()
        {
            string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection connect = new SqlConnection(connectionString);


            connect.Open();

            string commandText = "SELECT SUM(goods_no) FROM GOODSDONATIONS ";
            SqlCommand command = new SqlCommand(commandText, connect);

            noOfGoodsDonated = (int)command.ExecuteScalar();


            return noOfGoodsDonated;
                
            
        }
        public void OnGet()
        {

            try
            {
                string connectionString = "Server=tcp:dafserver1.database.windows.net,1433;Initial Catalog=daf;Persist Security Info=False;User ID=dafserver1;Password=@Happiness2507#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connect = new SqlConnection(connectionString))

                {
                    connect.Open();
                    string commandText = "SELECT * FROM GOODSDONATIONS";
                    using (SqlCommand command = new SqlCommand(commandText, connect))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                GoodsDonated goods = new GoodsDonated();
                                goods.id = "" + dataReader.GetInt32(0);
                                goods.goodsTitle = dataReader.GetString(1);
                                goods.goodsNo = "" + dataReader.GetInt32(2);
                                goods.goodsDescription = dataReader.GetString(3);
                                goods.goodsDate = dataReader.GetString(4);
                                goods.goodsCategory = dataReader.GetString(5);
                            
                                goods.goodsDonorname = dataReader.GetString(6);
                                donationList.Add(goods);

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
    public class GoodsDonated
    {
        public string id;
        public string goodsTitle;
        public string goodsNo;
        public string goodsDescription;
        public string goodsDate;
        public string goodsCategory;
        public string activeDisaster;
        public string goodsDonorname;

    }
}
