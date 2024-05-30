using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StepanProjekt
{
    internal class DataHelper
    {
        public List<Model.Product> GetProductData()
        {
            // využiju spojení do DB, stahuji data a zavírám spojení
            // connection string - podle www.connectionstrings.com
            var cs = "Server=tcp:stbechyn-sql.database.windows.net,1433;Database=adventureworksdw2020;User ID=prvniit;Password=P@ssW0rd!;Trusted_Connection=False;Encrypt=True";

            var products = new List<Model.Product>();

            using (var con = new SqlConnection(cs))
            {
                var cmd = new SqlCommand("SELECT EnglishProductName, DealerPrice FROM dimProduct where DealerPrice is not null", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var product = new Model.Product
                    {
                        ProductName = rdr["EnglishProductName"]!.ToString(),
                        DealerPrice = Convert.ToDouble(rdr["DealerPrice"]),
                        DealerPriceCZ = 0
                    };

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
