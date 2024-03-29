﻿using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        public List<IAnimal> Animals { get; set; }

        public string[] MoveAnimals()
        {
            List<string> output = new List<string>();
            foreach(var animal in Animals)
            {
                output.Add(animal.Move(Environment.Air));
                output.Add(animal.Move(Environment.Land));
                output.Add(animal.Move(Environment.Watery));
            }
			return output.ToArray();
        }
    }
}