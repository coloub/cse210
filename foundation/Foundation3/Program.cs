using System;
using System.Collections.Generic;

namespace FitnessApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            var running = new Running(30, 3.0);       // 30 min, 3 miles
            var cycling = new Cycling(30, 15.0);     // 30 min, 15 mph
            var swimming = new Swimming(30, 20);     // 30 min, 20 laps

            activities.Add(running);
            activities.Add(cycling);
            activities.Add(swimming);

            Console.WriteLine("Activity Summary:\n");
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
