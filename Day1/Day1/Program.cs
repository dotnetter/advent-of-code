using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sonarMeassurements = await GetSonarReadings();

            var totalNumberOfMeassurementsLargerThanPreviousMeassurement = CompareMeassurements(sonarMeassurements);

            Console.WriteLine($"{totalNumberOfMeassurementsLargerThanPreviousMeassurement} meassurements were larger than the preceeding meassurement.");

            var totalNumberOfSlidingMeassurementsLargerThanThePreviousSlidingMeassurement = ProcessMeassurementsForSlidingWindow(sonarMeassurements);

            Console.WriteLine($"{totalNumberOfSlidingMeassurementsLargerThanThePreviousSlidingMeassurement} sliding sums were larger than the preceeding sliding sum.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static async Task<int[]> GetSonarReadings()
        {
            var rawData = await System.IO.File.ReadAllLinesAsync("readings.txt");

            var result = Array.ConvertAll(rawData, s => int.Parse(s));

            return result;
        }

        private static int CompareMeassurements(int[] sonarReadings)
        {
            int depthIncreaseCounter = 0;

            for (int i = 1; i <= sonarReadings.Length - 1; i++)
            {                
                var currentReading = sonarReadings[i];
                var preceedingReading = sonarReadings[i - 1];

                if (currentReading > preceedingReading)
                {
                    depthIncreaseCounter++;
                }
            }

            return depthIncreaseCounter;
        }

        private static int ProcessMeassurementsForSlidingWindow(int[] sonarReadings)
        {
            const int SlidingWindowSize = 3;

            var slidingWindowMeassurements = GetSlidingWindowMeassurements(sonarReadings, SlidingWindowSize);

            var result = CompareMeassurements(slidingWindowMeassurements);

            return result;
        }

        private static int[] GetSlidingWindowMeassurements(int[] sonarReadings, int SlidingWindowSize)
        {
            var slidingSets = new List<int>();
            var readings = sonarReadings.ToList();

            while (readings.Count >= SlidingWindowSize)
            {
                var nextSetOfReadings = readings.Take(SlidingWindowSize);
                var sumOfReadings = nextSetOfReadings.Sum();

                slidingSets.Add(sumOfReadings);

                readings.RemoveRange(0, Math.Min(1, readings.Count));
            }

            return slidingSets.ToArray();
        }
    }
}