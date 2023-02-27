using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                WritelineColor(ConsoleColor.Cyan,   "   Please select the F key on the keyboard if you want to save the data to a file,\n" +
                                                    "   or\n" +
                                                    "   Please select the M key on the keyboard if you want to use program memory,\n" +
                                                    "   If you want to end the program, select X\n" +
                                                    "   then confirm by pressing Enter\n");
                
                var selectMemory = Console.ReadLine().ToUpper();

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
            WritelineColor(ConsoleColor.DarkYellow, "\n\nThank you for using my program and see you soon. Press any key to leave.");
            Console.ReadKey();
        }

        private static void VehicleInFile()  
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Select the type of vehicle by pressing the appropriate key:\n ");
                WritelineColor(ConsoleColor.Cyan,   "   C - Adding a car ride\n" +
                                                    "   M - Adding a motorcycle ride\n" +
                                                    "   A - Another vehicle\n");
                                                    
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
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
                        WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
                        continue;
                }
            }
            
        }
        private static void VehicleInMemory()
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Select the type of vehicle by pressing the appropriate key:\n ");
                WritelineColor(ConsoleColor.Cyan,   "   C - Adding a car ride\n" +
                                                    "   M - Adding a motorcycle ride\n" +
                                                    "   A - Another vehicle\n");

                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
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
                        WritelineColor(ConsoleColor.Red, "Invalid operation.\n");
                        continue;
                }
            }
        }

        static string DataInput(string comment)
        {
            string input;

            do
            {

                input = null;
                WritelineColor(ConsoleColor.Yellow, comment);
                var dataInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dataInput))
                {
                    input = dataInput;
                    break;
                }
                else
                {
                    WritelineColor(ConsoleColor.Red, "Data cannot be left blank, pleace try again!");
                }
            } while (true);
            return input;
        }

        static int YearInput()
        {
            int year;
            
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "E nter the year of manufacture of the vehicle:");
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

        static string DriverInput()
        {
            string input;
            
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow,   "Pleace choise driver or create new\n");
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
                    WritelineColor(ConsoleColor.Yellow, "Pleace enter driver details");
                    input = DataInput("Pleace enter name of driver:");
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
                WritelineColor(ConsoleColor.Yellow, "Pleace choise car or create new\n");
                string carInput = GetValueFromUser( "   F - Ford Galaxy\n" +
                                                    "   N - Nissan Primastar\n" +
                                                    "   C - create new car\n");
                
                if (carInput == "F")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInFile("Ford", "Galaxy", 2010, driver);
                    vehicle.TripAdded += CarTripAddedInFile;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "N")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInFile("Nissan", "Primastar", 2005, driver);
                    vehicle.TripAdded += CarTripAddedInFile;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Provide car details");
                    string brand = DataInput("Pleace enter brand of car:");
                    string model = DataInput("Pleace enter model of car:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new CarInFile(brand, model, year, driver);
                    vehicle.TripAdded += CarTripAddedInFile;
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
                WritelineColor(ConsoleColor.Yellow, "Pleace choise car or create new\n");
                string carInput = GetValueFromUser("   F - Ford Galaxy\n" +
                                                    "   N - Nissan Primastar\n" +
                                                    "   C - create new car\n");

                if (carInput == "F")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInMemory("Ford", "Galaxy", 2010, driver);
                    vehicle.TripAdded += CarTripAdded;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "N")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInMemory("Nissan", "Primastar", 2005, driver);
                    vehicle.TripAdded += CarTripAdded;
                    AddTripCar(vehicle);
                    break;
                }
                else if (carInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Provide car details");
                    string brand = DataInput("Pleace enter brand of car:");
                    string model = DataInput("Pleace enter model of car:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new CarInMemory(brand, model, year, driver);
                    vehicle.TripAdded += CarTripAdded;
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
                WritelineColor(ConsoleColor.Yellow, "Pleace choise motorcycle or create new\n");
                string motoInput = GetValueFromUser("   B - Benelli TRK 502\n" +
                                                    "   H - Honda Dauville\n" +
                                                    "   C - create new moto\n");
                
                if (motoInput == "B")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile("Benelli", "TRK 502", 2019, driver);
                    vehicle.TripAdded += MotoTripAddedInFile;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "H")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile("Honda", "Deauville", 2007, driver);
                    vehicle.TripAdded += MotoTripAddedInFile;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Enter the details of the new motorcycle");
                    string brand = DataInput("Pleace enter brand of motorcycle:");
                    string model = DataInput("Pleace enter model of motorcycle:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile(brand, model, year, driver);
                    vehicle.TripAdded += MotoTripAddedInFile;
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
                WritelineColor(ConsoleColor.Yellow, "Pleace choise motorcycle or create new\n");
                string motoInput = GetValueFromUser("   B - Benelli TRK 502\n" +
                                                    "   H - Honda Dauville\n" +
                                                    "   C - create new moto\n");

                if (motoInput == "B")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory("Benelli", "TRK 502", 2019, driver);
                    vehicle.TripAdded += MotoTripAdded;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "H")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory("Honda", "Deauville", 2007, driver);
                    vehicle.TripAdded += MotoTripAdded;
                    AddTripMoto(vehicle);
                    break;
                }
                else if (motoInput == "C")
                {
                    WritelineColor(ConsoleColor.Yellow, "Enter the details of the new motorcycle");
                    string brand = DataInput("Pleace enter brand of motorcycle:");
                    string model = DataInput("Pleace enter model of motorcycle:");
                    int year = YearInput();
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInMemory(brand, model, year, driver);
                    vehicle.TripAdded += MotoTripAdded;
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
                WritelineColor(ConsoleColor.Cyan,   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     Z - route to Zakpane and back (~173km)\n" +
                                                    "     L - route to the lake Rożnowskie and back (~190km)\n" +
                                                    "     Q - view statistics                            \n");
                
                var inputTrip = Console.ReadLine().ToUpper();
                if (inputTrip == "Q")
                {
                    VievStatistics(vehicle);
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
                WritelineColor(ConsoleColor.Cyan,   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     S - route to chldren's school and back (~2,1km)\n" +
                                                    "     F - route to children's football school and back (~13,8km)\n" +
                                                    "     Q - view statistics                            \n");
                
                var inputTrip = Console.ReadLine().ToUpper();
                if (inputTrip == "Q")
                {
                    VievStatistics(vehicle);
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
        private static void VievStatistics(IVehicle vehicle)
        {
            var statistics = vehicle.GetStatistics();

            Console.WriteLine("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The Vehicle \n{vehicle.Brand} {vehicle.Model} {vehicle.Year} year, with a driver {vehicle.Driver}, made {statistics.Count} trips.");
            Console.WriteLine($"Total distance: {statistics.Sum:N2}km");
            Console.WriteLine($"Average distance: {statistics.Average:N2}km");
            Console.WriteLine($"Maximum distance: {statistics.Max:N2}");
            Console.WriteLine($"Minimum distance: {statistics.Min:N2}");
            Console.WriteLine($"Commentary: {statistics.AverageComent}\n");
            Console.ResetColor();
        }

        static void CarTripAddedInFile(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new trip has been added in file!\n");
        }

        static void MotoTripAddedInFile(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new trip has been added in file!\n");
        }

        static void CarTripAdded(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new trip has been added in memory!\n");
        }

        static void MotoTripAdded(object sender, EventArgs args)
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
            string input = Console.ReadLine();
            string userInput = ($"{char.ToUpper(input[0])}{input.Substring(1, input.Length - 1).ToLower()}");
            return userInput;
        }
    }
}