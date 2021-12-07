using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
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

        static void Part1(int[] data)
        {
            var min = data.Min();
            var max = data.Max();

            Dictionary<int, int> results = new Dictionary<int, int>();

            for (int i = min; i <= max; i++)
            {
                var fuel = data.Sum(x =>
                {
                    return Math.Abs(x - i);
                });

                results.Add(i, fuel);
            }

            Console.WriteLine($"Lowest usage of fuel is position {results.OrderBy(x => x.Value).First()}");

        }

        static void Part2(int[] data)
        {
            var min = data.Min();
            var max = data.Max();

            Dictionary<int, int> results = new Dictionary<int, int>();

            for (int i = min; i <= max; i++)
            {
                var fuel = data.Sum(x =>
                {
                    var steps =  Math.Abs(x - i);
                    var result = 0;

                    for (int i = 0; i <= steps; i++)
                    {
                        result += i;
                    }

                    return result;

                });

                results.Add(i, fuel);
            }

            Console.WriteLine($"Lowest usage of fuel is position {results.OrderBy(x => x.Value).First()}");
        }

        static int[] GetData()
        {
            var filename = "sample-data.txt";
#if !DEBUG
            filename = "data.txt";
#endif
            var data = System.IO.File.ReadAllLines(filename);

            data = data[0].Split(',');

            return Array.ConvertAll(data, x => int.Parse(x));
        }
    }
}
