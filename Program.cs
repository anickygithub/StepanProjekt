using StepanProjekt.Tests;

namespace StepanProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // test
            //new TestInput().Test();

            // validujeme vstup
            if (!InputHelper.TryParseUserDate(args, out DateTime userDate, out DateTime currencyExchangeDate))
                return;

            // stahujeme data z Adv databáze
            var dh = new DataHelper();
            var products = dh.GetProductData();

            // stahujeme kurzový lístek
            var cnbh = new CNBHelper();
            var todayRate = cnbh.GetExchangeRate(currencyExchangeDate);

            // přepočítáme cenu
            foreach( var product in products)
                product.DealerPriceCZ = product.DealerPrice * todayRate.Rate;

            // skládáme výstup
            var csvh = new CSVHelper();
            var resultFileName = csvh.CreateOutputFile(products, currencyExchangeDate);

            Console.WriteLine($"Výstup byl uložen do souboru {resultFileName}");
        }
    }
}
