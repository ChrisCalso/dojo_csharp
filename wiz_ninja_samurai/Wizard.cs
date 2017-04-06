using System;

namespace ConsoleApplication
{
    public class Wizard : Human
    {
        // Wizard should have a default health of 50 and intelligence of 25
        public Wizard(string n) : base(n)
        {
            health = 50;
            intelligence = 25;
        }

        // Wizard should have a method called heal, which when invoked, heals the Wizard by 10 * intelligence
        public void Heal()
        {
            health += 10 * intelligence;
        }

        // Wizard should have a method called fireball, which when invoked, decreases the health of whichever object it attacked by some random integer between 20 and 50
        public void Fireball(object target)
        {
            Random randInt = new Random();
            Human victim = target as Human;
            victim.health -= randInt.Next(20, 51);
        }
    }
}