using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck mydeck = new Deck();
            Card dealtcard = mydeck.Deal();
            mydeck.Reset();
            mydeck.Shuffle();
            Player newplayer = new Player("NIcole");
            newplayer.Draw(mydeck);
            newplayer.Draw(mydeck);
            newplayer.Draw(mydeck);
            newplayer.Draw(mydeck);
            newplayer.Discard(5);
            System.Console.WriteLine(dealtcard);
        }
    }
}
