using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
        }

        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute { Strength = 1, Dexterity = 1, Intelligence = 8 };
        public override string[]? Equipment { get; set; }
        public override WeaponType[]? ValidWeaponTypes { get; } = { WeaponType.Staff, WeaponType.Wand};
        public override ArmorType[]? ValidArmorTypes { get; } = { ArmorType.Cloth};

        public override void Damage()
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
            Level += 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute { Strength = 1, Dexterity = 1, Intelligence = 5 };
            LevelAttribute += heroLevelUpAttribute;
        }
    }
}
