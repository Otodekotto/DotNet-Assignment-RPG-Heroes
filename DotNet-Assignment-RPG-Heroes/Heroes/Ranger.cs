﻿using DotNet_Assignment_RPG_Heroes.Enums;
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
        public override string Class { get; set; } = "Ranger";
        public override HeroAttribute LevelAttribute { get; set; } = new HeroAttribute { Strength = 1, Dexterity = 7, Intelligence = 1 };
        public override List<WeaponType> ValidWeaponTypes { get; } = new List<WeaponType> { WeaponType.Bow};
        public override List<ArmorType> ValidArmorTypes { get; } = new List<ArmorType> { ArmorType.Leather , ArmorType.Mail };


        public override void LevelUp()
        {
            Level += 1;
            HeroAttribute heroLevelUpAttribute = new HeroAttribute { Strength = 1, Dexterity = 5, Intelligence = 1 };
            LevelAttribute += heroLevelUpAttribute;
        }
    }
}
