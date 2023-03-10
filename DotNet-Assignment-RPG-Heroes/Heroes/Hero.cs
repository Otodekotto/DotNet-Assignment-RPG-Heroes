using DotNet_Assignment_RPG_Heroes.CustomExceptions;
using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    public abstract class Hero
    {
        protected string name;
        public string Name { get => name; private set => name = value; }
        protected abstract string Class { get; }
        public int Level { get; set; } = 1;
        protected abstract string DamageAttribute { get; }
        public abstract HeroAttribute LevelAttribute { get; set; }
        public Dictionary<SlotType, Item?> Equipments = new()
        {
             {SlotType.Head, null},
             {SlotType.Body, null},
             {SlotType.Legs, null},
             {SlotType.Weapon, null},
        };
        protected abstract List<WeaponType> ValidWeaponTypes { get; }
        protected abstract List<ArmorType> ValidArmorTypes { get; }

        public Hero(string name)
        {
            this.name = name;
        }
        public abstract void LevelUp();
        public void Equip(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType) && Level >= weapon.RequiredLevel && weapon.Slot == SlotType.Weapon)
                Equipments[SlotType.Weapon] = weapon;
            else
                throw new InvalidWeaponException();
        }

        public void Equip(Armor armor)
        {

            if (ValidArmorTypes.Contains(armor.ArmorType) && Level >= armor.RequiredLevel && armor.Slot != SlotType.Weapon)
                Equipments[armor.Slot] = armor;
            else
                throw new InvalidArmorException();
        }

        public double Damage()
        {
            double damagingAttribute = GetDamagingAttribute();
            double heroDamage;
            Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            if (item is not Weapon weapon)
            {
                heroDamage = (1 * (1 + (damagingAttribute / 100)));
                return Math.Round(heroDamage, 2);
            }
            else
            {
                heroDamage = (weapon.WeaponDamage * (1 + (damagingAttribute / 100)));
                return Math.Round(heroDamage, 2);
            }
        }
        private int GetDamagingAttribute()
        {
            HeroAttribute totalAttributes = TotalAttributes();

            if (DamageAttribute == "Strength")
                return totalAttributes.Strength;
            else if (DamageAttribute == "Intelligence")
                return totalAttributes.Intelligence;
            else
                return totalAttributes.Dexterity;


        }
        public HeroAttribute TotalAttributes()
        {
            //Adding Level Attribute to Total Attribute
            HeroAttribute totalAttributes = LevelAttribute;
            foreach (var item in Equipments)
            {
                if (item.Value as Armor != null)
                {
                    var armor = (Armor)item.Value;
                    if (armor.ArmorAttribute != null)
                        totalAttributes += armor.ArmorAttribute;
                }
            }
            return totalAttributes;
        }
        public string Display()
        {
            HeroAttribute totalAttributes = TotalAttributes();

            StringBuilder sb = new();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Class: {Class}");
            sb.AppendLine($"Level: {Level}");
            sb.AppendLine($"Total Strength: {totalAttributes.Strength}");
            sb.AppendLine($"Total Dexterity: {totalAttributes.Dexterity}");
            sb.AppendLine($"Total Intelligence: {totalAttributes.Intelligence}");
            sb.AppendLine($"Damage: " + Damage());
            return sb.ToString();
        }
    }
}
