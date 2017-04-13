using System;

namespace Warriors
{

    public class Spider : Creature {
        public Spider(string n) : base(n) {
            health = 300;
            intelligence = 5;
        }
        public void Web_Climb() {
        health = 10 * intelligence;
    }

        public void Coocoon(object obj) {
        Random rand = new Random();
        Human enemy = obj as Human;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                attack(enemy);
                enemy.health -= (rand.Next(2, 10) * intelligence);
            }
        }
    }
}