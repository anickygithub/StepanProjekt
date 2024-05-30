using StepanProjekt.Model;
using System;
using System.Globalization;
using System.Linq;

namespace StepanProjekt
{
    internal class CSVHelper
    {
        public string CreateOutputFile(List<Product> products, DateTime date)
        {
            // příprava stream writeru pro zápis výstupního souboru
            // v režimu přepis (případný existující soubor bude nahrazen)
            var fileName = $"{date.ToString("yyyyMMdd")}-adventureworks.csv";
            using (var writer = new StreamWriter(fileName, false))
            {
                var outputDate = date.ToString("yyyy-MM-dd");
                var usCult = CultureInfo.GetCultureInfo("en-US");

                writer.WriteLine("Date;EnglishProductName;DealerPriceUSD;DealerPriceCZK");
                foreach (var product in products)
                    writer.WriteLine($"{outputDate};{product.ProductName};{product.DealerPrice.ToString(usCult)};{product.DealerPriceCZ.ToString(usCult)}");

                // uložení a zavření souboru
                writer.Close();
            }

            return fileName;
        }
    }
}
