using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr1 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string[] arr2 = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] arr3 = {true, false, true, false, true, false, true, false, true, false};
            // Console.WriteLine("It looks like {0} forgot he had {1} people saying the problem is {2} and not {3}", arr2[0], arr1[6], arr3[1], arr3[2]);

            // foreach (int i in arr2)
            // {
            //     Console.WriteLine(i);
            // }
            int[,] arr4 = new int[10,10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    arr4[x,y] = (x+1) * (y+1);
                    System.Console.Write(arr4[x,y]);
                }
                
            }
            IceCream();
            UserInfo();
            
        }
        public static List<string> IceCream(){
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Mint");
            flavors.Add("Cookie");
            flavors.Add("Caramel");
            flavors.Add("Strawbery");
            flavors.Add("Milk");
            flavors.Add("Kiwi");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            System.Console.WriteLine(flavors.Count);
            return flavors;

        }
        public static Dictionary<string,string> UserInfo(){
            Dictionary<string,string> nameFlavor = new Dictionary<string,string>();
            string[] arr2 = {"Tim", "Martin", "Nikki", "Sara"};
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Mint");
            flavors.Add("Cookie");
            flavors.Add("Caramel");
            flavors.Add("Strawbery");
            flavors.Add("Milk");
            flavors.Add("Kiwi");
            Random rand = new Random();
            for (int i = 0; i < arr2.Length; i++)
            {
                nameFlavor.Add(arr2[i],flavors[rand.Next(flavors.Count)]);
                // System.Console.WriteLine(nameFlavor[i].Key);
                // System.Console.WriteLine(nameFlavor[arr2[i]]);
            }
            foreach (KeyValuePair<string,string> entry in nameFlavor)
            {
                System.Console.WriteLine(entry.Key + " - " + entry.Value);
            }
            return nameFlavor;
            
        }
    }
}
