using System;

namespace Warriors
{

    public class Wizard : Human {
        public Wizard(string n) : base(n) {
            health = 50;
            intelligence = 25;
        }
        public void Heal() {
        health = 10 * intelligence;
    }

        public void Fireball(object obj) {
        Random rand = new Random();
        Creature enemy = obj as Creature;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                enemy.health -= (rand.Next(2, 6) * intelligence);
            }
        }
    }
}