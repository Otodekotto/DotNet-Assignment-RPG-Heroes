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

        public override SlotType Slot { get; } = SlotType.Body;
        public ArmorType ArmorType { get; set; }
        public HeroAttribute? ArmorAttribute { get; set;} = new HeroAttribute ( 0, 0, 0 );

        public Armor(string name, int requiredLevel, SlotType slotType, ArmorType armorType, HeroAttribute armorAttribute)
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            this.Slot = slotType;
            this.ArmorType = armorType;
            this.ArmorAttribute = armorAttribute;
        }
    }
}
