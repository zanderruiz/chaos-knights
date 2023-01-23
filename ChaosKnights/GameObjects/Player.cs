using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class Player
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public Character Character { get; private set; }

        public int Health;

        public bool Revealed;

        public Player(string name, Character character)
        {
            Name = name;
            Character = character;
            Health = character.MaxHealth;
        }
    }
}
