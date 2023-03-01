using static VehicleTravelApp.VehicleBase;

namespace VehicleTravelApp
{
    public interface IVehicle
    {
        event TripAddedDelegate TripAdded;
        
        string Brand { get; }
        
        string Model { get; }
        
        int Year { get; }

        string Driver { get; }

        void AddTrip(float trip);

        void AddTrip(char trip);

        void AddTrip(string trip);

        void AddTrip(int trip);

        void AddTrip(double trip);

        void VievStatistics();

        Statistics GetStatistics();
    }
}
