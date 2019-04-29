using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake : IAnimal, ICrawlable
    {

        public string Name { get; }

        public int Age { get; set; }
    
        public double Health { get; set; }

        public double SpeedRate { get; set; }

        public string Crawl()
        {
            string output = Name + " is a Snake and is crawling";
            return output;
        }
        public string EatFood()
        {
            string output = Name + " is a Snake and is eating";
            return output;
        }

        public string Move(Environment moveType)
        {
            string output = string.Empty;
            if(moveType == Environment.Land)
            {
                return this.Crawl();
            }
            else
            {
                output = Name + " is a Snake and can't move in " + 
                    moveType.ToString() + " environment";
                return output;
            }
        }

        public string Reproduction(IAnimal animal)
        {
            string output = this.Name + " is a Snake and reproductive with " + animal.Name;
            return output;
        }

        
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }
    }
}