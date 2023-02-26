
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace VehicleTravelApp
{
    public class CarInFile : VehicleBase
    {
        public override event TripAddedDelegate TripAdded;

        private const string fileName = "CarTrip.txt";

        private string brand;
        private string model;
        private string driver;
        private string fullFileName;

        public CarInFile(string brand, string model, int year, string driver)
            : base(brand, model, year, driver)
        {
            fullFileName = $"{brand}_{model}_{driver}_{fileName}";
        }

        public override string Brand
        {
            get
            {
                return $"{char.ToUpper(brand[0])}{brand.Substring(1, brand.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    brand = value;
                }
            }

        }

        public override string Model
        {
            get
            {
                return $"{char.ToUpper(model[0])}{model.Substring(1, model.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    model = value;
                }
            }
        }

        public override string Driver
        {
            get
            {
                return $"{char.ToUpper(driver[0])}{driver.Substring(1, driver.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    driver = value;
                }
            }
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
                'S' or 's' => 2.1f,
                'F' or 'f' => 13.8f,
                _ => throw new Exception("Incorrect Letter! \n"),
            };

            {
                this.AddTrip(tripInput);
            }
        }

        public override void AddTrip(string trip)
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

        public override void AddTrip(int trip)
        {
            float tripInInt = (float)trip;
            this.AddTrip(tripInInt);
        }

        public override void AddTrip(double trip)
        {
            float tripInDouble = (float)trip;
            this.AddTrip(tripInDouble);
        }
        public override Statistics GetStatistics()
        {
            var tripsFromFile = this.ReadTripsFromFile();
            var statistics = this.CountStatistics(tripsFromFile);
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

        private Statistics CountStatistics(List<float> trips)
        {
            var statistics = new Statistics();

            foreach (var trip in trips)
            {
                statistics.AddTrip(trip);
            }

            return statistics;

        }
    }
}

