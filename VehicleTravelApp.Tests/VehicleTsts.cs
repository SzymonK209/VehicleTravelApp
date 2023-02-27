using System;
using VehicleTravelApp;

namespace VehicleTravelApp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenVehicleMakeAFewTrips_ShouldReturnCorrectResult()
        {
            //arrange
            var vehicle = new MotorcycleInMemory("Benelli", "TRK 502", 2019, "Szymon");
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

    }
}