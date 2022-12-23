using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalasoft.Monitoring.TDDPractice
{
    public class Product
    {
        public Product(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateProduct()
        {
            int multiplier = 1;
            if (!isValidProduct())
            {
                throw new Exception("Invalid Quality");
            }

            SellIn--;
            if (SellIn < 0) multiplier = 2;
            switch (Name)
            {
                case "Aged Brie":
                    if (Quality < 50) Quality++;
                    break;
                case "Sulfuras":
                    break;
                case "Backstage passes":
                    if (SellIn > 10) Quality++;
                    if (SellIn <= 10 && SellIn > 5) Quality += 2;
                    if (SellIn <= 5) Quality += 3;
                    if (SellIn < 0) Quality = 0;
                    if (Quality > 50) Quality = 50;
                    break;
                case "Conjured":
                    Quality -= 2 * multiplier;
                    break;
                default:
                    Quality -= 1 * multiplier;
                    break;
            };

            if (Quality <=0) Quality = 0;
        }

        private bool isValidProduct()
        {
            return (Quality <= 50 && Quality >= 0) || (Quality == 80 && Name == "Sulfuras");
        }
    }
}
