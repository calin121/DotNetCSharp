using System;

namespace Warriors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Wizard wiz = new Wizard("Wizzy");
            Ninja nin = new Ninja("Ninny");
            Samurai sam = new Samurai("Sammy");
            Zombie zom = new Zombie("Zoey");
            Spider spi = new Spider("Spidy");
            Samurai.How_Many();
            wiz.Heal();
            zom.Brains(wiz);
            sam.Death_Blow(zom);
            spi.Coocoon(sam);
            nin.Steal(spi);
            wiz.Fireball(zom);
            System.Console.WriteLine("Wizzy's health: {0} - Ninny's health: {1} - Sammy's health: {2} - Zoey's health: {3} - Spidy's health: {4}", wiz.health, nin.health, sam.health, zom.health, spi.health);
        }
    }
}
