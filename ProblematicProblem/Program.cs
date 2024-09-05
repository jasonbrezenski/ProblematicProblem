using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public static Random rng = new Random();
        public static bool cont = true;

        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var userInput = Console.ReadLine().ToLower();

            while (userInput != "yes" && userInput != "no")
            {
                Console.WriteLine("Not a valid response - please enter yes or no.");
                userInput = Console.ReadLine().ToLower();
            }
            
            if (userInput == "no")
            {
                Console.WriteLine("Okay goodbye, have a great day!");
                return;
            }
            
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Invalid response - please type a valid age: ");
            }
            
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            userInput = Console.ReadLine().ToLower();

            while (userInput != "sure" && userInput != "no thanks")
            {
                Console.WriteLine("Not a valid response - please enter sure or no thanks.");
                userInput = Console.ReadLine().ToLower();
            }

            if (userInput == "sure")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().ToLower();

                while (userInput != "yes" && userInput != "no")
                {
                    Console.WriteLine("Not a valid response - please enter yes or no.");
                    userInput = Console.ReadLine().ToLower();
                }

                Console.WriteLine();
                while (userInput == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userInput = Console.ReadLine().ToLower();

                    while (userInput != "yes" && userInput != "no")
                    {
                        Console.WriteLine("Not a valid response - please enter yes or no.");
                        userInput = Console.ReadLine().ToLower();
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                userInput = Console.ReadLine().ToLower();

                while (userInput != "keep" && userInput != "redo")
                {
                    Console.WriteLine("Not a valid response - please enter keep or redo.");
                    userInput = Console.ReadLine().ToLower();
                }

                if (userInput == "keep")
                {
                    Console.WriteLine("Okay great - have a great time!");
                    cont = false;
                }
            }
        }
    }
}