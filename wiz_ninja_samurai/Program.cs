using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Wizard sam = new Wizard("Sam");
            // System.Console.WriteLine(sam.name);
            // System.Console.WriteLine(sam.health);
            // sam.Get_Away();
            // System.Console.WriteLine(sam.health);
            Samurai jack = new Samurai("Jack");
            jack.death_blow(sam);
            System.Console.WriteLine("sam health " + sam.health);
        }
    }
}
