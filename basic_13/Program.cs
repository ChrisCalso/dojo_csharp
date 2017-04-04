using System;

namespace ConsoleApplication
{
    public class Program
    {
        // Print all the numbers from 1 to 255
        public static void Print_1_to_255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        // Print all the odd numbers from 1 to 255.
        public static void Print_Odds_1_to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        // Print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far
        public static void Print_Odds_1_to255_Deluxe()
        {
            int counter = 0;
             for (int i = 1; i <= 255; i++)
            {
                counter += i;
                Console.WriteLine("New Number: " + i + " Sum so far: "+ counter);
            }           
        }
        // Write a program that would iterate through each member of the array and print each value on the screen
        public static void Array_Iter()
        {
            int[] arr_to_iter = {1, 3, 5, 7, 9, 55};
            foreach (int i in arr_to_iter)
            {
                Console.WriteLine(i);
            }
        }
        // Write a program that takes any array and prints the maximum value in the array
        public static int Find_Max(int[] arr)
        {
            int max = arr[0];
            foreach (int item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        // Write a program that takes an array, and prints the AVERAGE of the values in the array
        public static int Find_Avg(int[] arr)
        {
            int sum = 0;
            foreach (int item in arr)
            {
                sum += item;
            }

            return sum/(arr.Length);
        }
        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        public static void Make_Arr()
        {
            int counter = 0;
            int[] newarr = new int[255];
            foreach (int item in newarr)
            {
                counter++;
                newarr[item] = counter;
                Console.WriteLine(newarr[item]);
            }
        
        }
        // Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y
        public static int Greater_Than_Y(int[] arr, int y)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > y)
                {
                    counter++;
                }
            }
            return counter;
        }
        // Given any array x, create an algorithm (sets of instructions) that multiplies each value in the array by itself
        public static void Square_theValues(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i]*arr[i];
            }

        }
        // Given any array x, create an algorithm that replaces any negative number with the value of 0
        public static void Remove_Negatives(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }
        }
        // Given any array x,, create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static void Max_Min_Avg(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            int avg = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if(arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            avg = sum / arr.Length;
            Console.WriteLine("Max: " + max +  " Min: " + min + " Average: " + avg);
        }
        // Given any array x, create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static void Move_and_Zero(int[] arr)
        {
            int[] newarr = new int[arr.Length];
            int counter = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                newarr[counter] = arr[i];
                counter++;
            }
            newarr[newarr.Length-1] = 0;
            for (int k = 0; k < newarr.Length; k++)
            {
                System.Console.WriteLine(newarr[k]);
            }
        }
        // Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'
        public static void Replace_Neg(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 888888;
                }
                System.Console.WriteLine(arr[i]);
            }

        }
        public static void Main(string[] args)
        {
            // Print_1_to_255();
            // Print_Odds_1_to255();
            // Print_Odds_1_to255_Deluxe();
            // Array_Iter();
            int[] theArray = { -10, 2, 3, 3, 5 };
            //  int max2 = Find_Max(theArray);
            //  Console.WriteLine(max2);
            // int avg = Find_Avg(theArray);
            // Console.WriteLine(avg);
            // Make_Arr();
            // int greaterthany = Greater_Than_Y(theArray, 3);
            // Console.WriteLine(greaterthany);
            // Square_theValues(theArray);
            // Remove_Negatives(theArray);
            // Max_Min_Avg(theArray);
            // Move_and_Zero(theArray);
            Replace_Neg(theArray);

        }
    }
}
