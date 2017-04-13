namespace Warriors
{


    public class Samurai : Human {
        public static int count = 0;
        public Samurai(string n) : base(n) {
            count++;
            health = 200;
        }
        public void Death_Blow(object obj) {
            Creature enemy = obj as Creature;
            if (enemy == null) {
                System.Console.WriteLine("Failed Attack");
            }
            else {
                attack(enemy);
                if (enemy.health < 50) {
                    enemy.health = 0;
                }
            }
        }
        
        public void Medidate() {
            health = 200;
        }
        
        public static void How_Many() {
            System.Console.WriteLine(count);
        }
    }
}