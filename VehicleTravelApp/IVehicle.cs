using static VehicleTravelApp.VehicleBase;

namespace VehicleTravelApp
{
    public interface IVehicle
    {
        event WayAddedDelegate WayAdded;
        
        string Brand { get; }
        
        string Model { get; }
        
        int Year { get; }

        string Driver { get; }

        void AddWay(float way);

        void AddWay(char way);

        void AddWay(string way);

        void AddWay(int way);

        void AddWay(double way);

        Statistics GetStatistics();
    }
}
