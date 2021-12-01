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
            var sonarMeasurements = await GetSonarReadings();
            var totalNumberOfMeasurementsLargerThanPreviousMeasurement = CompareMeasurements(sonarMeasurements);

            var slidingMeassurements = GetSlidingMeasurements(sonarMeasurements);
            var totalNumberOfSlidingMeasurementsLargerThanThePreviousSlidingMeasurement = CompareMeasurements(slidingMeassurements);

            Console.WriteLine($"{totalNumberOfMeasurementsLargerThanPreviousMeasurement} measurements were larger than the preceeding measurement.");
            Console.WriteLine($"{totalNumberOfSlidingMeasurementsLargerThanThePreviousSlidingMeasurement} sliding sums were larger than the preceeding sliding sum.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static async Task<int[]> GetSonarReadings()
        {
            var rawData = await System.IO.File.ReadAllLinesAsync("readings.txt");

            var result = Array.ConvertAll(rawData, s => int.Parse(s));

            return result;
        }

        private static int CompareMeasurements(int[] sonarReadings)
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

        private static int[] GetSlidingMeasurements(int[] sonarReadings)
        {
            const int SlidingWindowSize = 3;
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