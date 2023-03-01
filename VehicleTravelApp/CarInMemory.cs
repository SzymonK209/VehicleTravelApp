﻿namespace VehicleTravelApp
{
    public class CarInMemory : VehicleBase
    {
        public override event TripAddedDelegate TripAdded;

        private List<float> trips = new List<float>();

        public CarInMemory(string brand, string model, int year, string driver)
            : base(brand, model, year, driver)
        {
            
        }

        public override void AddTrip(float trip)
        {
            if (trip >= 0 && trip <= float.MaxValue)
            {
                this.trips.Add(trip);

                if (TripAdded != null)
                {
                    TripAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid distans value! \n");
            }
        }

        public override void AddTrip(char trip)
        {
            var tripInput = trip switch
            {
                'W' or 'w' => 21,
                'B' or 'b' => 17,
                'S' or 's' => 2.1f,
                'F' or 'f' => 13.8f,
                _ => throw new Exception("Incorrect Letter! \n"),
            };

            {
                this.AddTrip(tripInput);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var trip in this.trips)
            {
                statistics.AddTrip(trip);
            }

            return statistics;

        }
    }
}
