using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow : IFlyable, IAnimal
    {
        public Crow(string name, int age, double health, double speedRate)
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
            string output = Name + " is a Crow and is eating";
            return output;
        }

        public string Fly()
        {
            string output = Name + " is a Crow and is flying";
            return output;
        }

        public string Move(Environment moveType)
        {
            string output = string.Empty;
            if (moveType == Environment.Air)
            {
                return this.Fly();
            }
            else
            {
                output = Name + " is a Crow and can't move in " +
                    moveType.ToString() + " environment";
                return output;
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string output = this.Name + " is a Crow and reproductive with " +
                animal.Name;
            return output;
        }
    }
}