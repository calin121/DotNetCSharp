using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<string> bikes = new List<string>();
            bikes.Add("Kawasaki");
            bikes.Add("Triumph");
            bikes.Add("BMW");
            bikes.Add("Moto Guzzi");
            bikes.Add("Harley Davidson");
            bikes.Add("Suzuki");

            foreach (string manu in bikes)
            {
                Console.WriteLine("-"+manu);
            }
        
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 3; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    continue;
                }
                else if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            for (int i = 3; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
            }

            int count1 = 3;
            int count2 = 5;
            for (int i = 1; i <= 100; i++)
            {
                count1 -= 1;
                count2 -= 1;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    count1 = 3;
                    count2 = 5;
                }
                else if (count1 == 0)
                {
                    Console.WriteLine("Fizz");
                    count1 = 3;
                }
                else if (count2 == 0)
                {
                    Console.WriteLine("Buzz");
                    count2 = 5;
                }
            }
        }
    }
}
