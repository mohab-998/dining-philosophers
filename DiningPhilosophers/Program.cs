// Framework used: .NET Framework 4
// Compiler used: v4.0.30319.1
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] argArray)
        {
            int numPhilosophers = 5;

            // Construct philosophers and chopsticks
            var philosophers = Helpers.InitPhilosophers(numPhilosophers);

            // Start dinner
            Console.WriteLine("Dinner is starting!");

            // Spawn threads for each philosopher's eating cycle
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                philosopherThreads.Add(philosopherThread);
                philosopherThread.Start();
            }

            // Wait for all philosopher's to finish eating
            foreach (var thread in philosopherThreads)
            {
                thread.Join();
            }

            // Done
            Console.WriteLine("Dinner is over!");
        }

    }


}