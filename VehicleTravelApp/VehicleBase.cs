
namespace VehicleTravelApp
{
    public abstract class VehicleBase : IVehicle
    {
        public delegate void TripAddedDelegate(object sender, EventArgs args);
        
        public abstract event TripAddedDelegate TripAdded;

        public  VehicleBase(string brand, string model, int year, string driver)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.Driver = driver;
        }

        public virtual string Brand { get;  set; }
        
        public virtual string Model { get;  set; }
        
        public virtual int Year { get;  set; }

        public virtual string Driver { get; set; }

        public abstract void AddTrip(float trip);

        public abstract void AddTrip(char trip);

        public abstract void AddTrip(string trip);

        public abstract void AddTrip(int trip);

        public abstract void AddTrip(double trip);

        public abstract Statistics GetStatistics();

    }
}

