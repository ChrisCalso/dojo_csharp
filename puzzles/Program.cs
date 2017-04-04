using System;

namespace ConsoleApplication
{
    public class Program
    {
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array 
        // Print the sum of all the values
        public static int[] Random_Array()
        {
            Random rand = new Random();
            int[] newarr = new int [10];
            int min = 27;
            int max = newarr[0];
            int sum = 0;
            for (int i = 0; i < newarr.Length; i++)
            {
                newarr[i] = rand.Next(5,26);
                sum += newarr[i];
                if (newarr[i] < min)
                {
                    min = newarr[i];
                }

                if (newarr[i] > max)
                {
                    max = newarr[i];
                }
            }
            System.Console.WriteLine("Sum: " + sum);
            System.Console.WriteLine("Min: " + min);
            System.Console.WriteLine("Max: " + max);
            return newarr;
        }
        // Create a function called TossCoin() that returns a string
        //Have the function print "Tossing a Coin!"
        //Randomize a coin toss with a result signaling either side of the coin
        //Have the function print either "Heads" or "Tails"
        //return the result
        public static string TossCoin()
        {
            System.Console.WriteLine("Tossing a Coin!");
            Random head_or_tail = new Random();
            string result;
            if (head_or_tail.Next(0,2) == 0)
            {
                result = "Heads!";
                System.Console.WriteLine(result);
            }
            
            else
            {
                result = "Tails!";
                System.Console.WriteLine(result);
            }

            return result;
        }
        // Create another function called TossMultipleCoins(int num) that returns a Double
        // Have the function call the tossCoin function multiple times based on num value
        // Have the function return a Double that reflects the ratio of head toss to total toss
        public static Double TossMultipleCoins(int num)
        {
            double head_counter = 0;
            double tail_counter = 0;
            double ratio = 0;
            while (num >= 0)
            {
                string result = TossCoin();
                if (result == "Heads!")
                {
                    head_counter++;
                }
                
                else
                {
                    tail_counter++;
                }
                num--;
            }
            ratio = head_counter/(head_counter + tail_counter);
            return ratio;
        }
        // Build a function Names that returns an array of strings
        // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        // Shuffle the array and print the values in the new order
        // Return an array that only includes names longer than 5 characters
        public static string[] Names()
        {
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] newarr = new string[4];
            int index = 0;
            for (int i = 0; i < names.Length; i++)
            {
                string temp = names[i];
                if (temp.Length > 5)
                {
                    newarr[index] = temp;
                    // System.Console.WriteLine("index " + index + " is "+ temp);
                    index++;

                }
            }
            
            return newarr;
            
        }
        public static void Main(string[] args)
        {
            // Random_Array();
            // TossCoin();
            // double tester = TossMultipleCoins(5);
            // System.Console.WriteLine(tester);
            Names();
        }
    }
}
