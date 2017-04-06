using System;

namespace ConsoleApplication
{
    public class Ninja : Human
    {
        public Ninja(string n) : base(n)
        {
            // Ninja should have a default dexterity of 175
            dexterity = 175;
        }

        // Ninja should have a steal method, which when invoked, attacks an object and increases the Ninjas health by 10
        public void Steal(object target)
        {
            Human victim = target as Human;
            health += 10;
        }

        // Ninja should have a get_away method, which when invoked, decreases its health by 15
        public void Get_Away()
        {
            health -= 15;
        }
    }
}