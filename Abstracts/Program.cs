using System;

namespace Abstracts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var car1 = new car();
            car1.move();

            car1.cartype("evo");

            car1.printcar();

        }
    }
}
