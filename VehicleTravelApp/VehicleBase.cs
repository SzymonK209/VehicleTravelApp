namespace VehicleTravelApp
{
    public abstract class VehicleBase : IVehicle
    {
        public delegate void TripAddedDelegate(object sender, EventArgs args);
        
        public abstract event TripAddedDelegate TripAdded;

        public VehicleBase(string brand, string model, int year, string driver)
            
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Driver = driver;
        }

        public string Brand { get; private set; }
        
        public string Model { get; private set; }
        
        public int Year { get; private set; }

        public string Driver { get; private set; }

        public abstract void AddTrip(float trip);

        public abstract void AddTrip(char trip);

        public  void AddTrip(string trip)
        {
            if (float.TryParse(trip, out float tripInString))
            {
                this.AddTrip(tripInString);
            }
            else if (char.TryParse(trip, out char tripInLeatters))
            {
                this.AddTrip(tripInLeatters);
            }
            else
            {
                throw new Exception("String is not float! \n");
            }
        }

        public  void AddTrip(int trip)
        {
            float tripInInt = (float)trip;
            this.AddTrip(tripInInt);
        }

        public  void AddTrip(double trip)
        {
            float tripInDouble = (float)trip;
            this.AddTrip(tripInDouble);
        }

        public void VievStatistics()
        {
            var statistics = GetStatistics();
            if (statistics.Count != 0)
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"The Vehicle \n{this.Brand} {this.Model} {this.Year} year, with a driver {this.Driver}, made {statistics.Count} trips.");
                Console.WriteLine($"Total distance: {statistics.Sum:N2}km");
                Console.WriteLine($"Average distance: {statistics.Average:N2}km");
                Console.WriteLine($"Maximum distance: {statistics.Max:N2}");
                Console.WriteLine($"Minimum distance: {statistics.Min:N2}");
                Console.WriteLine($"Humorous commentary depending on mileage: {statistics.AverageComent}\n\n\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"The Vehicle \n{this.Brand} {this.Model} {this.Year} year, with a driver {this.Driver}, made {statistics.Count} trips.");
                Console.WriteLine($"Total distance: {statistics.Sum:N2}km");
                Console.WriteLine($"Humorous commentary depending on mileage: {statistics.AverageComent}\n\n\n");
                Console.ResetColor();
            }
        }

        public abstract Statistics GetStatistics();
    }
}

