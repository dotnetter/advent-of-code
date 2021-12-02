using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static void Part1()
        {

        }

        static void Part2()
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
