using Jalasoft.Monitoring.TDDPractice;

namespace Tests
{
    [TestClass]
    public class UpdateTest
    {
        [TestMethod]
        public void WhenDefaultProductReturnsUpdatedSellInValue()
        {
            Product myProduct = new Product("Bread", 35, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(34,myProduct.SellIn);

        }
        [TestMethod]
        public void WhenDefaultProductReturnsUpdatedQualityValue()
        {
            Product myProduct = new Product("Bread", 35, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(39, myProduct.Quality);

        }

        [TestMethod]
        public void WhenGivenProductReturnsNoNegativeQuality()
        {
            Product myProduct = new Product("Bread", 10, 0);
            myProduct.UpdateProduct();
            Assert.AreEqual(0, myProduct.Quality);
        }

        [TestMethod]
        public void WhenSellInValueLowerThanZeroQualityReducedTwice()
        {
            Product myProduct = new Product("Bread", -1, 2);
            myProduct.UpdateProduct();
            Assert.AreEqual(0, myProduct.Quality);
        }

        [TestMethod]
        public void WhenAgedBrieQualityGrows()
        {
            Product myProduct = new Product("Aged Brie", 15, 15);
            myProduct.UpdateProduct();
            Assert.AreEqual(16, myProduct.Quality);
        }

        [TestMethod]
        public void WhenQualityValueIs50ItDoesNotGrowsMore()
        {
            Product myProduct = new Product("Aged Brie", 15, 50);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsSulfurasItsQualityDoesNotChange()
        {
            Product myProduct = new Product("Sulfuras", 50, 80);
            myProduct.UpdateProduct();
            Assert.AreEqual(80, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsBackstagePassesAndSellinIsHigherThan10()
        {
            Product myProduct = new Product("Backstage passes", 15, 48);
            myProduct.UpdateProduct();
            Assert.AreEqual(49, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsBackstagePassesAndSellinIsLowerThan10()
        {
            Product myProduct = new Product("Backstage passes", 7, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(42, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsBackstagePassesAndSellinIsLowerThan5()
        {
            Product myProduct = new Product("Backstage passes", 2, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(43, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsBackstagePassesAndSellinIsLowerThan0()
        {
            Product myProduct = new Product("Backstage passes", 0, 40);
            myProduct.UpdateProduct();
            Assert.AreEqual(0, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsBackstagePassesAndQualityIs50()
        {
            Product myProduct = new Product("Backstage passes", 5, 50);
            myProduct.UpdateProduct();
            Assert.AreEqual(50, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsConjuredItsQualityDecresseTwice()
        {
            Product myProduct = new Product("Conjured", 10, 20);
            myProduct.UpdateProduct();
            Assert.AreEqual(18, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductIsConjuredAndSellinIsLowerThanZero()
        {
            Product myProduct = new Product("Conjured", -10, 20);
            myProduct.UpdateProduct();
            Assert.AreEqual(16, myProduct.Quality);
        }

        [TestMethod]
        public void WhenProductQualityIsOutOfValidValues()
        {
            string message = string.Empty;
            Product myProduct = new Product("Gold Bread", 10, 60);
            try
            {
                myProduct.UpdateProduct();
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Invalid Quality", message);
        }
    }
}