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
        public override SlotType Slot { get; } = SlotType.Weapon;
        public WeaponType WeaponType { get; private set; }
        public int WeaponDamage { get; private set; } = 1;

        public Weapon(string name, int requiredLevel , WeaponType weaponType , int weaponDamage) 
        {
            this.name = name;
            this.requiredLevel = requiredLevel;
            this.WeaponType = weaponType;
            this.WeaponDamage = weaponDamage;
        }
    }
}
