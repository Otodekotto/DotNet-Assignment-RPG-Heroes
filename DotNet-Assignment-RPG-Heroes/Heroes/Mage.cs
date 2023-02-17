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
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
        }
        protected override string Class { get; } = "Mage";
        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute(1, 1, 8);
        protected override List<WeaponType> ValidWeaponTypes { get; } = new List<WeaponType> { WeaponType.Staff, WeaponType.Wand };
        protected override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Cloth };

        protected override string DamageAttribute { get; } = "Intelligence";

        public override void LevelUp()
        {
            Level += 1;

            int strength = 1;
            int dexterity = 1;
            int intelligence = 5;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute(strength, dexterity, intelligence);

            LevelAttribute += heroLevelUpAttribute;
        }
    }
}
