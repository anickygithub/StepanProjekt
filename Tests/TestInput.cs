using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepanProjekt.Tests;

internal class TestInput
{
    public void Test()
    {

        string[] test = new string[] {"12/25/2021","2024-03-18","2024-03-17","2024-03-16","18.1.2024","hw;eoifheruighgiu"};

        foreach (var item in test)
        {
            Console.WriteLine($"Testing: {item}");
            var result = InputHelper.TryParseUserDate(new string[1] { item }, out DateTime userDate, out DateTime currencyExchangeDate);
            Console.WriteLine($"povedlo se: {result} {(result ? currencyExchangeDate.ToString():"")}");
        }
    }
}
