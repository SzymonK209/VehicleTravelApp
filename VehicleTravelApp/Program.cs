﻿using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;

namespace VehicleTravelApp
{

    class Program
    {
        static void Main(string[] args)
        {
            WritelineColor(ConsoleColor.Yellow,
                "\n                        Welcome to the [ SiMoN ] program                     \n\n" +
                "...............................................................................\n\n" +
                "         This program is used to record the mileage of vehicles.               \n\n" +
                "First, select the type of vehicle, then enter the vehicle and driver details,    \n" +
                "then enter the routes of the vehicle in turn.                                    \n" +
                "You can also use the shortcuts in the menu.                                    \n\n" +
                "===============================================================================\n\n");

           bool CloseApp = false;

            while (!CloseApp)
            {
                WritelineColor(ConsoleColor.Yellow, "Select the type of vehicle, or press X to close the program\n ");
                WritelineColor(ConsoleColor.Cyan,   "   C - Adding a car ride\n" +
                                                    "   M - Adding a motorcycle ride\n" +
                                                    "   A - Another vehicle\n" +
                                                    "   X - Close app\n");

                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "C":
                        CarInput();
                        break;

                    case "M":
                        MotoInput();
                        break;

                    case "X":
                        CloseApp = true;
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
            WritelineColor(ConsoleColor.DarkYellow, "\n\nBye Bye! Press any key to leave.");
            Console.ReadKey();
        }

        static string DataInput(string comment)
        {
            string input;
            
            while (true)
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
                    WritelineColor(ConsoleColor.Red, "Data cannot be left blank, please try again!");
                }
            }
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

        private static void CarInput()
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
                    vehicle.WayAdded += CarWayAdded;
                    AddWayCar(vehicle);
                    break;
                }
                else if (carInput == "N")
                {
                    string driver = DriverInput();
                    var vehicle = new CarInFile("Nissan", "Primastar", 2005, driver);
                    vehicle.WayAdded += CarWayAdded;
                    AddWayCar(vehicle);
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
                    vehicle.WayAdded += CarWayAdded;
                    AddWayCar(vehicle);
                    break;
                }
                else
                { 
                        WritelineColor(ConsoleColor.Red, $"[{carInput}] is incorect, pleace try again!\n");
                        continue;
                }
            }
        }

        private static void MotoInput()
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
                    vehicle.WayAdded += MotoWayAdded;
                    AddWayMoto(vehicle);
                    break;
                }
                else if (motoInput == "H")
                {
                    string driver = DriverInput();
                    var vehicle = new MotorcycleInFile("Honda", "Deauville", 2007, driver);
                    vehicle.WayAdded += MotoWayAdded;
                    AddWayMoto(vehicle);
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
                    vehicle.WayAdded += MotoWayAdded;
                    AddWayMoto(vehicle);
                    break;
                }
                else
                { 
                    WritelineColor(ConsoleColor.Red, $"[{motoInput}] is incorect, pleace try again!\n");
                    continue;
                }
            }
        }

        private static void AddWayMoto(IVehicle vehicle)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Enter the next way in km, or select from the list:  \n");
                WritelineColor(ConsoleColor.Cyan,   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     S - route to school children and back (~2,10km)\n" +
                                                    "     Q - view statistics                            \n");
                var inputWay = Console.ReadLine().ToUpper();
                if (inputWay == "Q")
                {
                    VievStatistics(vehicle);
                    break;
                }
                try
                {
                    vehicle.AddWay(inputWay);
                }
                catch (Exception ex)
                {
                    WritelineColor(ConsoleColor.Red, $"{ ex.Message}");
                }
            }
        }
        private static void AddWayCar(IVehicle vehicle)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, "Enter the next way in km, or select from the list:  \n");
                WritelineColor(ConsoleColor.Cyan,   "     W - route to and from work (~21km)             \n" +
                                                    "     B - route to the store and back (~17km)        \n" +
                                                    "     S - route to school children and back (~2,10km)\n" +
                                                    "     Q - view statistics                            \n");
                var inputWay = Console.ReadLine().ToUpper();
                if (inputWay == "Q")
                {
                    VievStatistics(vehicle);
                    break;
                }
                try
                {
                    vehicle.AddWay(inputWay);
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
            Console.WriteLine($"The Vehicle \n{vehicle.Brand} {vehicle.Model} {vehicle.Year}year, made {statistics.Count} trips");
            Console.WriteLine($"Total distance: {statistics.Sum:N2}km");
            Console.WriteLine($"Average distance: {statistics.Average:N2}km");
            Console.WriteLine($"Maximum distance: {statistics.Max:N2}");
            Console.WriteLine($"Minimum distance: {statistics.Min:N2}");
            Console.WriteLine($"Commentary: {statistics.AverageComent}\n");
            Console.ResetColor();
        }

        static void CarWayAdded(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new way has been added!\n");
        }

        static void MotoWayAdded(object sender, EventArgs args)
        {
            WritelineColor(ConsoleColor.Blue, "A new way has been added!\n");
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