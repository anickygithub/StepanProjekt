using System;
using System.Linq;

namespace StepanProjekt.Model
{
    /// <summary>
    /// Reprezentuje řádek z tabulky produktů s informací o ceně i přepočítané ceně
    /// </summary>
    internal class Product
    {
        public string ProductName { get; set; }
        public double DealerPrice { get; set; }
        public double DealerPriceCZ { get; set; }
    }
}
