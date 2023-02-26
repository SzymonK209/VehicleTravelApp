
namespace VehicleTravelApp
{
    public class MotorcycleInFile : VehicleBase
    {
        public override event WayAddedDelegate WayAdded;

        private const string fileName = "_MotoWay.txt";
        private string brand;
        private string model;
        private string driver;
        private string fullFileName;

        public MotorcycleInFile(string brand, string model, int year, string driver)
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

        public override void AddWay(float way)
        {
            using (var writer = File.AppendText(fullFileName))
            {
                if (way >= 0 && way <= float.MaxValue)
                {
                    writer.WriteLine(way);

                    if (WayAdded != null)
                    {
                        WayAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new Exception("Invalid distans value! \n");
                }
            }
        }

        public override void AddWay(char way)
        {
            var wayInput = way switch
            {
                'W' or 'w' => 21,
                'B' or 'b' => 17,
                'S' or 's' => 2.1f,
                _ => throw new Exception("Incorrect Letter! \n"),
            };

            {
                this.AddWay(wayInput);
            }
        }

        public override void AddWay(string way)
        {
            if (float.TryParse(way, out float wayInString))
            {
                this.AddWay(wayInString);
            }
            else if (char.TryParse(way, out char wayInLeatters))
            {
                this.AddWay(wayInLeatters);
            }
            else
            {
                throw new Exception("String is not float! \n");
            }
        }

        public override void AddWay(int way)
        {
            float wayInInt = (float)way;
            this.AddWay(wayInInt);
        }

        public override void AddWay(double way)
        {
            float wayInDouble = (float)way;
            this.AddWay(wayInDouble);
        }
        public override Statistics GetStatistics()
        {
            var waysFromFile = this.ReadWaysFromFile();
            var statistics = this.CountStatistics(waysFromFile);
            return statistics;
        }

        private List<float> ReadWaysFromFile()
        {
            var ways = new List<float>();
            if (File.Exists($"{fullFileName}"))
            {
                using (var reader = File.OpenText($"{fullFileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        ways.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return ways;
        }

        private Statistics CountStatistics(List<float> ways)
        {
            var statistics = new Statistics();

            foreach (var way in ways)
            {
                statistics.AddWay(way);
            }

            return statistics;

        }
    }
}


