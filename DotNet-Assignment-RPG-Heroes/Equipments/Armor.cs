using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Equipments
{
    public class Armor : Item
    {

        public override SlotType Slot { get; set; } = SlotType.Body;
        public ArmorType ArmorType { get; set; }
        public HeroAttribute? ArmorAttribute { get; set;} = new HeroAttribute { Strength = 0, Dexterity = 0, Intelligence = 0 };
    }
}
