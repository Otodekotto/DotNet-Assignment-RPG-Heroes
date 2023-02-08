using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
        }

        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute { Strength = 2, Dexterity = 6, Intelligence = 1 };
        public override List<WeaponType> ValidWeaponTypes { get; } = new List<WeaponType> { WeaponType.Dagger, WeaponType.Sword };
        public override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Leather , ArmorType.Mail };

        public override void Damage()
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
            Level += 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute { Strength = 1, Dexterity = 4, Intelligence = 1 };
            LevelAttribute += heroLevelUpAttribute;
        }
    }
}
