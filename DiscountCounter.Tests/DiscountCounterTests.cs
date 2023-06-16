namespace DiscountCounter.Tests
{
    [TestClass]
    public class DiscountCounterTests
    {
        private Customer _John = new Customer { Age = 1, LastVisit = new DateTime(2022, 02, 10), Name = "John" };
        private Customer _Jane = new Customer { Age = 100, LastVisit = new DateTime(2022, 12, 30), Name = "Jane" };
        private Customer _Jamie = new Customer { Age = 50, LastVisit = new DateTime(2021, 12, 30), Name = "Jamie" };
        private Customer _Norm = new Customer { Age = 25, LastVisit = new DateTime(2023, 3, 30), Name = "Norm" };

        [TestMethod]
        public void Should_Return_100_Percent_Discount_When_Customer_Under_4_Years_Old()
        {
            // Arrange
            var counter = new DiscountService(new TestDateTimeProvider(new DateTime(2023,6,16,10,0,0)));
            var customer = _John;

            // Act
            var result = counter.DiscountPercentCount(customer);

            // Assert
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void Should_Return_50_Percent_Discount_When_Customer_Visited_200_Days_Ago()
        {
            // Arrange
            var counter = new DiscountService(new TestDateTimeProvider(new DateTime(2023, 6, 16, 10, 0, 0)));
            var customer = _Jamie;

            // Act
            var result = counter.DiscountPercentCount(customer);

            // Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Should_Return_30_Percent_Discount_When_Customer_Age_Over_65()
        {
            // Arrange
            var counter = new DiscountService(new TestDateTimeProvider(new DateTime(2023, 6, 16, 10, 0, 0)));
            var customer = _Jane;

            // Act
            var result = counter.DiscountPercentCount(customer);

            // Assert
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void Should_Return_0_Percent_In_Other_Cases()
        {
            // Arrange
            var counter = new DiscountService(new TestDateTimeProvider(new DateTime(2023, 6, 16, 10, 0, 0)));
            var customer = _Norm;

            // Act
            var result = counter.DiscountPercentCount(customer);

            // Assert
            Assert.AreEqual(30, result);
        }
    }
}