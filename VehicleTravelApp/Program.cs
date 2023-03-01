namespace VehicleTravelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WritelineColor(ConsoleColor.Yellow,
                "\n                           Welcome to the [ SiMoN ] program                     \n\n" +
                "..................................................................................\n\n" +
                "           This program is used to record the mileage of vehicles.\n" +
                "   At the beginning, select the type of saving the entered data, \n" +
                "   if you want the data to be saved, select saving in a file, \n" +
                "   otherwise, after the end of the program, the data will be automatically deleted.\n" +
                "   In the next step, select the vehicle type, then enter the vehicle and driver details,\n" +
                "   then enter the vehicle routes in turn.\n" +
                "   You can also use shortcuts by selecting the appropriate character from the menu. \n\n" +
                "==================================================================================\n\n");

            bool CloseApp = false;

            while (!CloseApp)
            {
                WritelineColor(ConsoleColor.Yellow, "Select type of memory:\n");
                var selectMemory = GetValueFromUser("   Please select the F key on the keyboard if you want to save the data to a file, or\n" +
                                                    "   please select the M key on the keyboard if you want to use program memory,\n" +
                                                    "   if you want to end the program, select X, then confirm by pressing Enter\n");
                switch (selectMemory)
                    {
                    case "X":
                        CloseApp = true;
                        break;
                    case "F":
                        VehicleInFile();
                        break;
                    case "M":
                        VehicleInMemory();
                        break;
                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation! Pleace try again\n");
                        continue;
                }
            }
            WritelineColor(ConsoleColor.Blue, "\n\nThank you for using my program and see you soon. Press any key to leave.");
            Console.ReadKey();
        }

        private static void VehicleInFile()  
        {
            bool backSelectMemory = false;

            while (!backSelectMemory)
            {
                WritelineColor(ConsoleColor.Yellow, "Select the type of vehicle by pressing the appropriate key:\n ");
                var userInput = GetValueFromUser(   "   C - Adding a car ride\n" +
                                                    "   M - Adding a motorcycle ride\n" +
                                                    "   A - Another vehicle\n" +
                                                    "   B - back to select memory type\n");
                switch (userInput)
                {
                    case "B":
                        backSelectMemory = true;
                        break;

                    case "C":
                        CarInFile();
                        break;

                    case "M":
                        MotoInFile();
                        break;

                    case "A":
                        WritelineColor(ConsoleColor.Red, "Unfortunately, this feature is not available yet,  \n" +
                                                         "Contact the program publisher for more information.\n");
                        continue;

                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation! Pleace try again\n");
                        continue;
                }
            }
        }

        private static void VehicleInMemory()
        {
            bool backSelectMemory = false;

            while (!backSelectMemory)
            {
                WritelineColor(ConsoleColor.Yellow, "Select the type of vehicle by pressing the appropriate key:\n ");
                var userInput = GetValueFromUser(   "   C - Adding a car ride\n" +
                                                    "   M - Adding a motorcycle ride\n" +
                                                    "   A - Another vehicle\n" +
                                                    "   B - back to select memory type\n");
                switch (userInput)
                {
                    case "B":
                        backSelectMemory = true;
                        break;

                    case "C":
                        CarInMemory();
                        break;

                    case "M":
                        MotoInMemory();
                        break;

                    case "A":
                        WritelineColor(ConsoleColor.Red, "Unfortunately, this feature is not available yet,  \n" +
                                                         "Contact the program publisher for more information.\n");
                        continue;

                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation! Pleace try again\n");
                        continue;
                }
            }
        }
         
        private static int YearInput()
        {
            int year;

            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Enter the year of manufacture of the vehicle:");
                bool yearInInt = int.TryParse(Console.ReadLine(), out year);
                if (year > 1886 && year <= 3000)
                {
                    break;
                }
                else
                {
                    WritelineColor(ConsoleColor.Red, "Invalid vehicle production year! \n");
                }
            }
            return year;
        }

        private static string DriverInput()
        {
            string input;
            
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Pleace choise driver or create new, by pressing the appropriate key:\n");
                string driverInput = GetValueFromUser("     S - Szymon\n" +
                                                      "     A - Agata\n" +
                                                      "     N - new driver\n");
                if (driverInput == "S")
                {
                    input = "Szymon";
                    break;
                }
                else if (driverInput == "A")
                {
                    input = "Agata";
                    break;
                }
                else if (driverInput == "N")
                {
                    WritelineColor(ConsoleColor.Yellow, "Enter driver details");
                    input = GetValueFromUser("Pleace enter name of driver:");
                    break;
                }
                else
                {
                    WritelineColor(ConsoleColor.Red, $"[{driverInput}] is incorect, pleace try again!\n");
                }
            }
            return input;
        }

        private static void CarInFile()
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Pleace choise car or create new, by pressing the appropriate key:\n");
                string carInput = GetValueFromUser( "   F - Ford Galaxy\n" +
                                                    "   N - Nissan Primastar\n" +
                                                    "   C - create new car\n");
                if (carInput == "F")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInFile("Ford", "Galaxy", 2010, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "N")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInFile("Nissan", "Primastar", 2005, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Provide car details");
                    string brand = GetValueFromUser("Pleace enter brand of car:");
                    string model = GetValueFromUser("Pleace enter model of car:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new CarInFile(brand, model, year, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripCar(vehicle);
                    break;
                }
                else
                { 
                        WritelineColor(ConsoleColor.Red, $"[{carInput}] is incorect, pleace try again!\n");
                        continue;
                }
            }
        }

        private static void CarInMemory()
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Pleace choise car or create new, by pressing the appropriate key:\n");
                string carInput = GetValueFromUser( "   F - Ford Galaxy\n" +
                                                    "   N - Nissan Primastar\n" +
                                                    "   C - create new car\n");
                if (carInput == "F")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInMemory("Ford", "Galaxy", 2010, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "N")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInMemory("Nissan", "Primastar", 2005, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Provide car details");
                    string brand = GetValueFromUser("Pleace enter brand of car:");
                    string model = GetValueFromUser("Pleace enter model of car:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new CarInMemory(brand, model, year, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripCar(vehicle);
                    break;
                }
                else
                {
                    WritelineColor(ConsoleColor.Red, $"[{carInput}] is incorect, pleace try again!\n");
                    continue;
                }
            }
        }

        private static void MotoInFile()
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Pleace choise motorcycle or create new, by pressing the appropriate key:\n");
                string motoInput = GetValueFromUser("   B - Benelli TRK 502\n" +
                                                    "   H - Honda Dauville\n" +
                                                    "   C - create new moto\n");
                if (motoInput == "B")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile("Benelli", "TRK 502", 2019, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "H")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile("Honda", "Deauville", 2007, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Enter the details of the new motorcycle");
                    string brand = GetValueFromUser("Pleace enter brand of motorcycle:");
                    string model = GetValueFromUser("Pleace enter model of motorcycle:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile(brand, model, year, driver);
                    vehicle.TripAdded += TripAddedInFile;
                    AddTripMoto(vehicle);
                    break;
                }
                else
                { 
                    WritelineColor(ConsoleColor.Red, $"[{motoInput}] is incorect, pleace try again!\n");
                    continue;
                }
            }
        }

        private static void MotoInMemory()
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Pleace choise motorcycle or create new, by pressing the appropriate key:\n");
                string motoInput = GetValueFromUser("   B - Benelli TRK 502\n" +
                                                    "   H - Honda Dauville\n" +
                                                    "   C - create new moto\n");

                if (motoInput == "B")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory("Benelli", "TRK 502", 2019, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "H")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory("Honda", "Deauville", 2007, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Enter the details of the new motorcycle");
                    string brand = GetValueFromUser("Pleace enter brand of motorcycle:");
                    string model = GetValueFromUser("Pleace enter model of motorcycle:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory(brand, model, year, driver);
                    vehicle.TripAdded += TripAdded;
                    AddTripMoto(vehicle);
                    break;
                }
                else
                {
                    WritelineColor(ConsoleColor.Red, $"[{motoInput}] is incorect, pleace try again!\n");
                    continue;
                }
            }
        }

        private static void AddTripMoto(IVehicle vehicle)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Enter the next trip in km, or select from the list:  \n");
                var inputTrip = GetValueFromUser(   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     Z - route to Zakpane and back (~173km)\n" +
                                                    "     L - route to the lake Rożnowskie and back (~190km)\n" +
                                                    "     Q - view statistics                            \n");
                if (inputTrip == "Q")
                {
                    vehicle.VievStatistics();
                    break;
                }
                try
                {
                    vehicle.AddTrip(inputTrip);
                }
                catch (Exception ex)
                {
                    WritelineColor(ConsoleColor.Red, $"{ ex.Message}");
                }
            }
        }

        private static void AddTripCar(IVehicle vehicle)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Enter the next trip in km, or select from the list:  \n");
                var inputTrip = GetValueFromUser(   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     S - route to chldren's school and back (~2,1km)\n" +
                                                    "     F - route to children's football school and back (~13,8km)\n" +
                                                    "     Q - view statistics                            \n");
                if (inputTrip == "Q")
                {
                    vehicle.VievStatistics();
                    break;
                }
                try
                {
                    vehicle.AddTrip(inputTrip);
                }
                catch (Exception ex)
                {
                    WritelineColor(ConsoleColor.Red, $"{ ex.Message}");
                }
            }
        }

        private static void TripAddedInFile(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new trip has been added in file!\n");
        }

        private static void TripAdded(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new trip has been added in memory!\n");
        }

        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string GetValueFromUser(string comment)
        {
            WritelineColor(ConsoleColor.Cyan, comment);
            string input;
            do
            {
                var getInput = Console.ReadLine();
                try
                {
                    string userInput = ($"{char.ToUpper(getInput[0])}{getInput.Substring(1, getInput.Length - 1).ToLower()}");
                    input = userInput;
                    break;
                }
                catch (Exception)
                {
                    WritelineColor(ConsoleColor.Red, $"Data cannot be left blank, pleace try again!");
                }

            } while (true);
            return input;
        }
    }
}