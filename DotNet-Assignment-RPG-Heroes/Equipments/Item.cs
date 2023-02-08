using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_Assignment_RPG_Heroes.Enums;

namespace DotNet_Assignment_RPG_Heroes.Equipments
{
    abstract class Item
    {
        public string? Name { get; set; }
        public int RequiredLevel { get; set; }
        public SlotType Slot { get; set; }
    }
}
