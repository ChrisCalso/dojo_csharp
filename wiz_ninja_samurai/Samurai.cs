using System;

namespace ConsoleApplication
{
    public class Samurai : Human
    {
        public Samurai(string n) : base(n)
        {
            // Samurai should have a default health of 200
            health = 200;
        }

        // Samurai should have a method called death_blow, which when invoked should attack an object and decreases its health to 0 if it has less than 50 health
        public void death_blow(object target)
        {
            Human victim = target as Human;
            if (victim.health < 50)
            {
                victim.health = 0;
            }
        }

        // Samurai should have a method called meditate, which when invoked, heals the Samurai back to full health
        public void Meditate()
        {
            health = 200;
        }
    }
}