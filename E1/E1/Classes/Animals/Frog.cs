using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog : IAnimal ,IWalkable, ISwimable
    {
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        public double SpeedRate { get; set; }

        public string Name { get; }

        public int Age { get; set; }

        public double Health { get; set; }

        public string EatFood()
        {
            string output = Name + " is a Frog and is eating";
            return output;
        }

        public string Move(Environment moveType)
        {
            if (moveType == Environment.Land)
            {
                return this.Walk();
            }
            else if (moveType == Environment.Watery)
            {
                return this.Swim();
            }
            else
            {
                string output = Name + " is a Frog and can't move in " +
                    moveType.ToString() + " environment";
                return output;
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string output = this.Name + " is a Frog and reproductive with " +
                animal.Name;
            return output;
        }

        public string Swim()
        {
            string output = Name + " is a Frog and is swimming";
            return output;
        }

        public string Walk()
        {
            string output = Name + " is a Frog and is walking";
            return output;
        }
    }
}