using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an array to hold integer values 0 through 9
            int[] arr_zero_to_nine = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] name_array = new string[4] { "Tim", "Martin", "Nikki", "Sara" };

            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] bool_array = new bool[10] { true, false, true, false, true, false, true, false, true, false };

            // With the values 1-10, use code to generate a multiplication table like the one below.
            // Use a multidimensional array to store all values
            int[,,] mult_table = new int[10, 10, 1] {
                { {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10} },
                { {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20} },
                { {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30} },
                { {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40} },
                { {41}, {42}, {43}, {44}, {45}, {46}, {47}, {48}, {49}, {50} },
                { {51}, {52}, {53}, {54}, {55}, {56}, {57}, {58}, {59}, {60} },
                { {61}, {62}, {63}, {64}, {65}, {66}, {67}, {68}, {69}, {70} },
                { {71}, {72}, {73}, {74}, {75}, {76}, {77}, {78}, {79}, {80} },
                { {81}, {82}, {83}, {84}, {85}, {86}, {87}, {88}, {89}, {90} },
                { {91}, {92}, {93}, {94}, {95}, {96}, {97}, {98}, {99}, {100} }

            };
            // Console.WriteLine(mult_table[9, 3, 0]);

            // Create a list of Ice Cream flavors that holds at least 5 different flavors
            // Output the length of this list after building it
            // Output the third flavor in the list, then remove this value.Output the new length of the list (Note it should just be one less~)
            List<string> icecream_flavors = new List<string>();
            icecream_flavors.Add("Chocolate");
            icecream_flavors.Add("Vanilla");
            icecream_flavors.Add("Strawberry");
            icecream_flavors.Add("Mint");
            icecream_flavors.Add("Banana");
            // Console.WriteLine(icecream_flavors.Count);
            // Console.WriteLine(icecream_flavors[2]);
            icecream_flavors.RemoveAt(2);
            // Console.WriteLine(icecream_flavors.Count);

            // Create a Dictionary that will store both string keys as well as string values
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            // For each name key, select a random flavor from the flavor list above and store it as the value
            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            Dictionary<string, string> name_and_icecream_flavor = new Dictionary<string, string>();
            name_and_icecream_flavor.Add("Tim", "Chocolate");
            name_and_icecream_flavor.Add("Martin", "Vanilla");
            name_and_icecream_flavor.Add("Nikki", "Mint");
            name_and_icecream_flavor.Add("Sara", "Banana");
            foreach (var pair in name_and_icecream_flavor)
            {
                Console.WriteLine("Name: " + pair.Key + " Flavor: " + pair.Value);
            }
        }
    }
}
