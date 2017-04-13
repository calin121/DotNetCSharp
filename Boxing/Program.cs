using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Boxme();
        }

        public static List<object> Boxme(){
            List<object> box = new List<object>();
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");
            int sum = 0;
            foreach (var i in box){
                if (i is int){
                    sum = (int)i + sum;
                }
                System.Console.WriteLine(sum);
                System.Console.WriteLine(i);
            }
            return box;
        }
    }
}
