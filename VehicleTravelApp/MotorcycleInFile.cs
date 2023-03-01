﻿namespace VehicleTravelApp
{
    public class MotorcycleInFile : VehicleBase
    {
        public override event TripAddedDelegate TripAdded;

        private const string fileName = "_MotoTrip.txt";

        private string fullFileName;

        public MotorcycleInFile(string brand, string model, int year, string driver)
            : base(brand, model, year, driver)
        {
            fullFileName = $"{brand}_{model}_{driver}_{fileName}";
        }

        public override void AddTrip(float trip)
        {
            using (var writer = File.AppendText(fullFileName))
            {
                if (trip >= 0 && trip <= float.MaxValue)
                {
                    writer.WriteLine(trip);

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
        }

        public override void AddTrip(char trip)
        {
            var tripInput = trip switch
            {
                'W' or 'w' => 21,
                'B' or 'b' => 17,
                'Z' or 'z' => 173,
                'L' or 'l' => 190,
                _ => throw new Exception("Incorrect Letter! \n"),
            };

            {
                this.AddTrip(tripInput);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            var trips = ReadTripsFromFile();

            foreach (var trip in trips)
            {
                statistics.AddTrip(trip);
            }

            return statistics;

        }

        private List<float> ReadTripsFromFile()
        {
            var trips = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        trips.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return trips;
        }
    }
}


