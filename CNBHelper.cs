using StepanProjekt.Model;
using System;
using System.Globalization;
using System.Linq;

namespace StepanProjekt
{
    internal class CNBHelper
    {
        public ExchangeRate GetExchangeRate(DateTime date)
        {
            // příprava návratové hodnoty
            var rates = new List<ExchangeRate>();

            // vytvoření klienta pro HTTP request
            using (var client = new HttpClient())
            {
                // počkáme si na async volání stažení souboru
                var taskAwaiter = client.GetStreamAsync($"https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/rok.txt?rok={date.Year}").GetAwaiter();
                using (var reader = new StreamReader(taskAwaiter.GetResult()))
                {
                    // přeskočíme první řádek (názvy sloupců)
                    var row = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        // čteme každý řádek
                        row = reader.ReadLine();
                        var cols = row.Split('|');

                        // ukládáme kurz dolaru k datumu v řádku
                        var er = new ExchangeRate
                        {
                            Date = DateTime.ParseExact(cols[0], "dd.MM.yyyy", null),
                            Rate = double.Parse(cols[29].Replace(",", CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
                        };

                        rates.Add(er);
                    }
                }
            }

            return rates.Single(x => x.Date.Equals(date));
        }
    }
}
