using DotNet_Assignment_RPG_Heroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Equipments
{
    public class Weapon : Item
    {
        public Weapon(string name, int requiredLevel) : base(name, requiredLevel)
        {
        }

        public override SlotType Slot { get; set; } = SlotType.Weapon;

        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }
    }
}
