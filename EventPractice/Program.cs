using System;
using System.Collections.Generic;
namespace EventPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            CarRaceEvent f1Race = new CarRaceEvent("F1", 3);
            CarRaceEvent nascarRace = new CarRaceEvent("Nascar", 2);

            f1Race.EnrollmentFull += CarRace_EnrollmentFull;

            f1Race.SignUpCars("Ferrari").PrintToConsole();
            f1Race.SignUpCars("BMW").PrintToConsole();
            f1Race.SignUpCars("Mercedes").PrintToConsole();
            f1Race.SignUpCars("Puma").PrintToConsole();

            

            Console.WriteLine();


            nascarRace.EnrollmentFull += CarRace_EnrollmentFull;

            nascarRace.SignUpCars("Ford").PrintToConsole();
            nascarRace.SignUpCars("Dodge").PrintToConsole();
            nascarRace.SignUpCars("Buick").PrintToConsole();

           Console.ReadLine();
        }

        private static void CarRace_EnrollmentFull(object sender, string e)
        {
           CarRaceEvent carRaceEvent = (CarRaceEvent)sender;
            Console.WriteLine();
            Console.WriteLine($"{carRaceEvent.RaceName} FULL");
            Console.WriteLine();
        }
    }
    public static class ConsoleHelper
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }
    }

    public class CarRaceEvent
    {
        public event EventHandler<string> EnrollmentFull;

        private List<string> enrollCars = new List<string>();
        private List<string> waitingList = new List<string>();
        public string RaceName { get; set; }
        public int MaxCarsAllowed { get; set; }   

        public CarRaceEvent(string raceName, int maxCarsAllowed)
        {
            RaceName = raceName;

            MaxCarsAllowed = maxCarsAllowed;
        }

        public string SignUpCars(string carName)
        {
            string output = "";

            if (enrollCars.Count < MaxCarsAllowed)
            {
                enrollCars.Add(carName);
                output = $"{carName} is enrolled in {RaceName}";

                if (enrollCars.Count == MaxCarsAllowed)
                {
                    EnrollmentFull?.Invoke(this, $"{RaceName} enrollment is now full.");
                }

            }
            else
            {
                waitingList.Add(carName);
                output = $"{carName} has been added to the wait list for {RaceName}";
            }
            return output;  
        }

    }



}
