using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {
        const int ExpectedLengthOfReading = 12;
        static void Main(string[] args)
        {
            var data = GetData();

            Part1(data);
            Part2(data);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static void Part1(string[] data)
        {
            var numberOfReadings = data.Length;
            var gamma = new int[ExpectedLengthOfReading];
            var epislon = new int[ExpectedLengthOfReading];

            for (int i = 0; i < data.Length; i++)
            {
                var digits = data[i].ToCharArray().Reverse().ToArray();

                for (int x = 0; x < ExpectedLengthOfReading; x++)
                {
                    var digitValue = Convert.ToInt16(digits[x].ToString());

                    if (digitValue == 1)
                    {
                        gamma[x] = gamma[x] + 1;
                    }
                }
            }

            for (int i = 0; i < ExpectedLengthOfReading; i++)
            {
                gamma[i] = (decimal.Divide(gamma[i], numberOfReadings) >= 0.5M) ? 1 : 0;
                epislon[i] = (gamma[i] % numberOfReadings >= 1) ? 0 : 1;
            }

            var gammaValue = Convert.ToInt32(string.Join("", gamma.Reverse()), 2);

            var epsilonValue = Convert.ToInt32(string.Join("", epislon.Reverse()), 2);

            var result = gammaValue * epsilonValue;

            Console.WriteLine($"The gamme value {gammaValue} multiplied by the epsilon value {epsilonValue} equals {result}");

        }

        private static char[][] GetOxygenRating(char[][] blah, int pos)
        {
            if (pos >= ExpectedLengthOfReading) { return blah; }

            var ones = blah.Where(x => x[pos] == '1').ToArray();
            var zeros = blah.Where(x => x[pos] == '0').ToArray();

            // if only one left
            if (ones.Length + zeros.Length == 1)
            {
                return (ones.Length == 1) ? ones : zeros;
            }

            var nextPos = pos + 1;

            if (ones.Length == zeros.Length)
            {
                return GetOxygenRating(ones, nextPos);
            }
            else if (ones.Length > zeros.Length)
            {
                return GetOxygenRating(ones, nextPos);
            }
            else
            {
                return GetOxygenRating(zeros, nextPos);
            }
        }

        private static char[][] GetCO2ScrubberRating(char[][] blah, int pos)
        {
            if (pos >= ExpectedLengthOfReading) { return blah; }

            var ones = blah.Where(x => x[pos] == '1').ToArray();
            var zeros = blah.Where(x => x[pos] == '0').ToArray();

            // if only one left
            if (ones.Length + zeros.Length == 1)
            {
                return (ones.Length == 1) ? ones : zeros;
            }

            var nextPos = pos + 1;

            if (ones.Length == zeros.Length)
            {
                return GetCO2ScrubberRating(zeros, nextPos);
            }
            else if (ones.Length < zeros.Length)
            {
                return GetCO2ScrubberRating(ones, nextPos);
            }
            else
            {
                return GetCO2ScrubberRating(zeros, nextPos);
            }
        }

        static void Part2(string[] data)
        {
            var blah = data.Select(s => s.ToCharArray().ToArray()).ToArray();

            var oxygenRating = GetOxygenRating(blah, 0)[0];
            var o2Rating = GetCO2ScrubberRating(blah, 0)[0];

            var oxygenFinal = Convert.ToInt32(string.Join("", oxygenRating), 2);
            var o2Final = Convert.ToInt32(string.Join("", o2Rating), 2);
            var lifeSupport = oxygenFinal * o2Final;

            Console.WriteLine($"The Oxygen rating {oxygenFinal} multiplied by the O2 Scurbber rating {o2Final} equals a Life Support rating of {lifeSupport}");
        }

        static string[] GetData()
        {
            var filename = "sample-data.txt";
#if !DEBUG
            filename = "data.txt";
#endif
            return System.IO.File.ReadAllLines(filename);
        }
    }
}
