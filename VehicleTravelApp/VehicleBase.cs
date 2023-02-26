
namespace VehicleTravelApp
{
    public abstract class VehicleBase : IVehicle
    {
        public delegate void WayAddedDelegate(object sender, EventArgs args);
        
        public abstract event WayAddedDelegate WayAdded;

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

        public abstract void AddWay(float way);

        public abstract void AddWay(char way);

        public abstract void AddWay(string way);

        public abstract void AddWay(int way);

        public abstract void AddWay(double way);

        public abstract Statistics GetStatistics();
    }
}

