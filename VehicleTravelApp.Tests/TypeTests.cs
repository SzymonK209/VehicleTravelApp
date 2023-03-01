namespace VehicleTravelApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void GetTwoNumber_ShouldCorectResult()
        {
            //arrange
            int number1 = 1;
            int number2 = 2;

            //act
            int number3 = number2 + number1;
            int number4 = number3 - number2;
            int number5 = number4 * number3;
            int number6 = number5 / number4;

            //assert
            Assert.AreNotEqual(number1, number2);
            Assert.AreEqual(3, number3);
            Assert.AreEqual(1, number4);
            Assert.AreEqual(3, number5);
            Assert.AreEqual(3, number6);

        }

        [Test]
        public void DifferentValueTypesAreEqual()
        {
            //arrange
            int number4 = 2;
            float number1 = 2.0f;
            double number2 = 2;
            decimal number3 = 2;

            //act

            //assert
            Assert.AreEqual(number1, number2);
            Assert.AreEqual(number2, number3);
            Assert.AreEqual(number3, number4);
            Assert.AreEqual(number4, number1);
            Assert.AreEqual(number1, number3);
            Assert.AreEqual(number2, number4);
        }

        [Test]
        public void GetTwoName_ShouldDifferentObject()
        {
            //arange
            string name1 = "Szymon";
            string name2 = "Jan";

            //act

            //assert
            Assert.IsFalse(name1.Equals(name2));
            Assert.AreNotEqual(name1, name2);
        }

        [Test]
        public void GetNewObject_ShouldDifferentObject()
        {
            //arrange
            var vehicle1 = GetVehicle("Benelli", "TRK 502", 2019, "Szymon");
            var vehicle2 = GetVehicle("Honda", "Deauville", 2007, "Jan");
            var vehicle3 = vehicle2;

            //act

            //assert
            Assert.False(Object.ReferenceEquals(vehicle1, vehicle2));
            Assert.True(Object.ReferenceEquals(vehicle2, vehicle3));
            Assert.AreNotSame(vehicle1, vehicle2);
            Assert.AreSame(vehicle2, vehicle3);
            Assert.AreEqual(vehicle2, vehicle3);
            Assert.AreEqual("Szymon", vehicle1.Driver);
            Assert.AreEqual(vehicle3.Driver, vehicle2.Driver);
        }
        [Test]
        public void WhenVehicleMakeAFewTrips_ShouldReturnCorrectResult()
        {
            //arrange
            var vehicle = new MotorcycleInMemory("Honda", "Deauville", 2007, "Szymon");
            vehicle.AddTrip(100);
            vehicle.AddTrip(5);
            vehicle.AddTrip(45);

            //act
            var result = vehicle.GetStatistics();

            //assert
            Assert.AreEqual(150, result.Sum);
            Assert.AreEqual(100, result.Max);
            Assert.AreEqual(5, result.Min);
            Assert.AreEqual(50, result.Average);


        }
        private MotorcycleInMemory GetVehicle(string brand, string model, int year, string driver)
        {
            return new MotorcycleInMemory(brand, model, year, driver);
        }
    }
}