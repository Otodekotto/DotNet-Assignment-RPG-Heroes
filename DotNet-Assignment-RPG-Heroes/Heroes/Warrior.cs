using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
        }
        public override string Class { get; set; } = "Warrior";
        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute { Strength = 5 , Dexterity = 2 , Intelligence = 1};
        public override List<WeaponType> ValidWeaponTypes { get;} = new List<WeaponType> { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword};
        public override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Mail, ArmorType.Plate };

       

        public override void LevelUp()
        {
            Level += 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute { Strength = 3 , Dexterity = 2 , Intelligence= 1 };
            LevelAttribute += heroLevelUpAttribute; 
        }
    }
}
