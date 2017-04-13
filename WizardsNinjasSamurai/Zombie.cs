using System;

namespace Warriors
{

    public class Zombie : Creature {
        public Zombie(string n) : base(n) {
            strength = 10;
            dexterity = 2;
        }
       public void Flesh(object obj) {
            Creature enemy = obj as Creature;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                attack(enemy);
                health += 15 * dexterity;
            }
        }

        public void Brains(object obj) {
        Random rand = new Random();
        Human enemy = obj as Human;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                attack(enemy);
                enemy.health -= (rand.Next(2, 11) * dexterity);
                strength += 5;
            }
        }
    }
}