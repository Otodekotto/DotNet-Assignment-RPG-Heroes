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
        public override string Class { get; } = "Warrior";
        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute ( 5 ,  2 ,  1);
        public override List<WeaponType> ValidWeaponTypes { get;} = new List<WeaponType> { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword};
        public override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Mail, ArmorType.Plate };

       

        public override void LevelUp()
        {
            Level += 1;
            int strength = 3;
            int dexterity = 2;
            int intelligence = 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute ( strength, dexterity , intelligence );
            LevelAttribute += heroLevelUpAttribute; 
        }
    }
}
