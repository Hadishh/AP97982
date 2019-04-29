using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge : IAnimal, IWalkable, IFlyable
    {
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

        public double SpeedRate { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Health { get; set; }

        public string EatFood()
        {
            string output = Name + " is a Partridge and is eating";
            return output;
        }

        public string Fly()
        {
            string output = Name + " is a Partridge and is flying";
            return output;
        }

        public string Move(Environment moveType)
        {
            if (moveType == Environment.Land)
            {
                return this.Walk();
            }
            else if (moveType == Environment.Air)
            {
                return this.Fly();
            }
            else
            {
                string output = Name + " is a Partridge and can't move in " +
                    moveType.ToString() + " environment";
                return output;
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string output = this.Name + " is a Partridge and reproductive with " +
                animal.Name;
            return output;
        }

        public string Walk()
        {
            string output = Name + " is a Partridge and is walking";
            return output;
        }
    }
}