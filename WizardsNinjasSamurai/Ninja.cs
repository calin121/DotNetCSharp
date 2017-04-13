using System;

namespace Warriors {

    public class Ninja : Human {
        public Ninja(string n) : base(n) {
            dexterity = 75;
        }
        public void Steal(object obj) {
            Creature enemy = obj as Creature;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                attack(enemy);
                health += 10;
            }
        }
        
        public void Get_Away(object obj) {
            Creature enemy = obj as Creature;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                enemy.health -= dexterity;
            }
            health -= 15;
        }
    }
}