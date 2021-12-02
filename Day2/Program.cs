using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();

            Part2();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Part1()
        {
            var horizontal = 0;
            var vertical = 0;

            var rawData = System.IO.File.ReadAllLines("directions.txt");

            foreach (var info in rawData)
            {
                var directions = info.Split(" ");

                var instruction = directions[0];
                var distance = int.Parse(directions[1]);

                switch (instruction)
                {
                    case "forward":
                        horizontal += distance;
                        break;
                    case "down":
                        vertical += distance;
                        break;
                    case "up":
                        vertical -= distance;
                        break;
                }
            }

            var total = horizontal * vertical;

            Console.WriteLine($"Part 1 result = {horizontal} x {vertical} = {total}");
        }

        private static void Part2()
        {
            var horizontal = 0;
            var aim = 0;
            long depth = 0;

            var rawData = System.IO.File.ReadAllLines("directions.txt");

            foreach (var info in rawData)
            {
                var directions = info.Split(" ");

                var instruction = directions[0];
                var distance = int.Parse(directions[1]);

                switch (instruction)
                {
                    case "forward":
                        horizontal += distance;
                        depth += (aim > 0) ? (aim * distance) : 0;
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                }
            }

            var total = horizontal * depth;

            Console.WriteLine($"Part 2 result = {horizontal} x {depth} = {total}");
        }
    }
}
