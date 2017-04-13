using System;

namespace Warriors {


    public class Creature
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Creature(string creature)
        {
            name = creature;
            strength = 5;
            intelligence = 1;
            dexterity = 5;
            health = 200;
        }
        public Creature(string creature, int str, int intel, int dex, int hp)
        {
            name = creature;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                enemy.health -= strength * 4;
            }
        }
    }
}