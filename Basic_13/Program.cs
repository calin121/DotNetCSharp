using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Print1_255();
            PrintOdd1_255();
            PrintSum();
            int[] arr = new int[] {3,1,8,-4,93,18,4,44,56};
            int y = 12;
            IteratingAnArray(arr);
            FindMax(arr);
            Average(arr);
            ArrayWithOdds();
            GreaterThanY(arr, y);
            SquareValues(arr);
            EliminateNegativeNumbers(arr);
            MinMaxAverage(arr);
            ShiftingValues(arr);
            object [] arr1 =new object[] {3,1,8,-4,93,18,4,44,56};
            NumberToString(arr1);
        }

        public static void Print1_255(){
            for (int i = 1; i <= 255; i++){
                System.Console.WriteLine(i);
            }
        }
        public static void PrintOdd1_255(){
            for (int i = 1; i <= 255; i++){
                if (i % 2 == 1){
                    System.Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum(){
            int sum = 0;
            for (int i = 0; i <= 255; i++){
                sum += i;
                System.Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        public static void IteratingAnArray(int[] x){
            foreach (int i in x){
                System.Console.WriteLine(i);
            }
        }
        public static int FindMax(int[] x){
            int max = x[0];
            foreach (int i in x){
                if (i > max){
                    max = i;
                }
            }
            System.Console.WriteLine(max);
            return max;
        }
        public static void Average(int[] x){
            int sum = 0;
            foreach (int i in x){
                sum += i;
                }
            System.Console.WriteLine(sum/x.Length);            
        }
        public static int[] ArrayWithOdds() {
            List<int> y = new List<int>();
            for (int i = 1; i <= 255; i++) {
                if (i % 2 == 1){
                    y.Add(i);
                }
            }
            foreach (int val in y){
                System.Console.WriteLine(val);
            }
            return y.ToArray();
        }
        public static void GreaterThanY(int[] arr, int y) {
            int count = 0;
            foreach (int i in arr) {
                if (i > y) {
                    count += 1;
                }
            }
            System.Console.WriteLine(count);
        }
        public static void SquareValues(int[] arr) {
            for(int i = 0; i < arr.Length; i++) {
                arr[i] *= arr[i];
                System.Console.WriteLine(arr[i]);
            }
        }
        public static void EliminateNegativeNumbers(int[] arr) {
            for(int i = 0; i < arr.Length; i++) {
                if (arr[i] < 0) {
                    arr[i] = 0;
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        public static void MinMaxAverage(int[] arr) {
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];
            int avg = 0;
            for(int i = 1; i < arr.Length; i++) {
                if (arr[i] < min) {
                    min = arr[i];
                }
                if (arr[i] > max) {
                    max = arr[i];
                }
                sum += arr[i]; 
            }
            avg = sum/arr.Length;
            System.Console.WriteLine(min);
            System.Console.WriteLine(max);
            System.Console.WriteLine(avg);
        }
        public static void ShiftingValues(int[] arr) {
            for(int i = 0; i < arr.Length - 1; i++) {
                arr[i] = arr[i + 1];
                System.Console.WriteLine(arr[i]);
            }     
            arr[arr.Length - 1] = 0;
            System.Console.WriteLine(arr[arr.Length - 1]);
        }
        public static object[] NumberToString(object[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                if ((int)arr[i] < 0) {
                    arr[i] = "dojo";
                }
                System.Console.WriteLine(arr[i]);
            }
            return arr;
        }
    }
}
