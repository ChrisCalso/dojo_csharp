using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human player1 = new Human("Great Hero", 20, 8, 16, 500);
            Human player2 = new Human("Random NPC");
            player1.Attack(player2);
            Console.WriteLine($"After being attacked by the {player1.name}, the {player2.name}'s health is now {player2.health}");
        }
    }
}
