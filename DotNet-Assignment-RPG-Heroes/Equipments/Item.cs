using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_Assignment_RPG_Heroes.Enums;

namespace DotNet_Assignment_RPG_Heroes.Equipments
{
    public abstract class Item
    {
        protected string? name;
        protected int requiredLevel;
        public string? Name { get => name; set => name = value; }
        public int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
        public abstract SlotType Slot { get; }


        public Item()
        {
        }
        public Item(string name, int requiredLevel)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
        }
    }
}
