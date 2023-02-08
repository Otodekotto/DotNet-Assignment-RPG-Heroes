using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    internal class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public int AddTwoInstance(int attribute1, int attribute2)
        {
            return attribute1 + attribute2;
        }
        public int IncreaseAttribute(int attribute1, int value) 
        {
            return attribute1 + value;
        }
    }
}
