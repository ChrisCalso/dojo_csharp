using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> basic_list = new List<object>();
            int int_adder = 0;
            // Add the following values to the list: 7, 28, -1, true, "chair"
            basic_list.Add(7);
            basic_list.Add(28);
            basic_list.Add(-1);
            basic_list.Add(true);
            basic_list.Add("chair");
            // Loop through the list and print all values (Hint: Type Inference might help here!)
            for (int i = 0; i < basic_list.Count; i++)
            {
                Console.WriteLine(basic_list[i]);
                if (basic_list[i] is int)
                {
                    int_adder += (int)basic_list[i];
                }
            }

            Console.WriteLine(int_adder);
        }
    }
}
