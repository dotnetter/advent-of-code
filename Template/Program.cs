using System;
using System.Linq;

namespace Day3
{
    class Program
    {
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
            var gamma = new int[5] { 0, 0, 0, 0, 0 };
            var epislon = new int[5] { 0, 0, 0, 0, 0 };

            for (int i = 0; i < data.Length; i++)
            {
                var digits = data[i].ToCharArray().Reverse().ToArray();

                for (int x = 0; x < 5; x++)
                {
                    var digitValue = Convert.ToInt16(digits[x]);

                    if (digitValue == 1)
                    {
                        gamma[x] = gamma[x] + 1;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (gamma[i] == 0) { }

                gamma[i] = (gamma[i] % numberOfReadings >= 1) ? 1 : 0;
                epislon[i] = (gamma[i] % numberOfReadings >= 1) ? 0 : 1;
            }

            var gammaValue = Convert.ToInt32(gamma.ToString(), 2);

            var epsilonValue = Convert.ToInt32(epislon.ToString(), 2);

            var result = gammaValue * epsilonValue;

            Console.WriteLine($"The gamme value {gammaValue} multiplied by the epsilon value {epsilonValue} equals {result}");

        }

        static void Part2(string[] data)
        {

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
