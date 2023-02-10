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
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
        }
        protected override string Class { get;} = "Ranger";
        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute ( 1 , 7 , 1 );
        protected override List<WeaponType> ValidWeaponTypes { get; } = new List<WeaponType> { WeaponType.Bow};
        protected override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Leather , ArmorType.Mail };


        public override void LevelUp()
        {
            Level += 1;
            int strength = 1;
            int dexterity = 5;
            int intelligence = 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute ( strength, dexterity, intelligence);
            LevelAttribute += heroLevelUpAttribute;
        }
    }
}
