using System;
using System.Linq;

namespace StepanProjekt
{
    internal class InputHelper
    {
        public static bool TryParseUserDate(string[] args, out DateTime userDate, out DateTime currencyExchangeDate)
        {
            // zadané nebo dnešní datum
            userDate = DateTime.Today;
            currencyExchangeDate = DateTime.Today;

            if (args.Length == 1)
            {
                // očekáváme datum v českém fomátu
                var czech = System.Globalization.CultureInfo.GetCultureInfo(1029);
                var success = DateTime.TryParse(args[0], czech, out userDate);

               if (!success)
                {
                    Console.WriteLine("chybne zadane datum. je treba zadat datum v ceskem formatu.");
                    return false;
                }
                currencyExchangeDate = userDate;
            }
            // test datumu v budoucnosti
            if (userDate > DateTime.Today)
            {
                Console.WriteLine("datum je v budoucnu");
                return false;
            }

            // pokud bylo zadáno víkendové datum, dopočítáme poslední pátek
            if (userDate.DayOfWeek == DayOfWeek.Saturday)
                currencyExchangeDate = userDate.AddDays(-1);
            else if (userDate.DayOfWeek == DayOfWeek.Sunday)
                currencyExchangeDate = userDate.AddDays(-2);

            return true;
        }
    }
}
