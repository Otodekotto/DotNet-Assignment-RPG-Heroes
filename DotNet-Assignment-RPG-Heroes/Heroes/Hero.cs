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
        public abstract string Class { get;}
        public int Level { get; set; } = 1;
        public abstract HeroAttribute LevelAttribute { get;  set; }
        public Dictionary<SlotType, Item?> Equipments = new Dictionary<SlotType, Item?>
        {
            //[SlotType.Head] = new Armor { Name = "Naked"},
            //[SlotType.Body] = new Armor { Name = "Naked" },
            //[SlotType.Legs] = new Armor { Name = "Naked" },
            [SlotType.Weapon] = new Weapon("Bare Hands", 0, WeaponType.BareHands , 1)
        };
        public abstract List<WeaponType> ValidWeaponTypes { get; }
        public abstract List<ArmorType> ValidArmorTypes { get; }

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

        public int Damage() 
        {
            int damagingAttribute = GetDamagingAttribute();
            int heroDamage;
            Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? weapon = item as Weapon;

            heroDamage = weapon.WeaponDamage * (1 + damagingAttribute / 100);

            return heroDamage;
        }
        private int GetDamagingAttribute()
        {
            HeroAttribute totalAttributes = TotalAttributes();

            if (Class == "Warrior")
                return totalAttributes.Strength;
            else if (Class == "Mage")
                return totalAttributes.Intelligence;
            else
                return totalAttributes.Dexterity;
            

        }
        public HeroAttribute TotalAttributes()
        {
            HeroAttribute totalAttributes = new HeroAttribute(0,0,0);
            foreach(var item in Equipments)
            { 
                if(item.Value.Slot == SlotType.Head || item.Value.Slot == SlotType.Body || item.Value.Slot == SlotType.Legs)
                {
                    var armor = (Armor)item.Value;
                    totalAttributes.Strength += armor.ArmorAttribute.Strength;
                    totalAttributes.Dexterity += armor.ArmorAttribute.Dexterity;
                    totalAttributes.Intelligence += armor.ArmorAttribute.Intelligence;   
                }
            }
            totalAttributes.Strength += LevelAttribute.Strength;
            totalAttributes.Dexterity += LevelAttribute.Dexterity;
            totalAttributes.Intelligence += LevelAttribute.Intelligence;

            return totalAttributes;
        }
        public void Display() 
        {
            HeroAttribute totalAttributes = TotalAttributes();
            var damage = Damage();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Level: {Level}");
            sb.AppendLine($"Total Strength: {totalAttributes.Strength}");
            sb.AppendLine($"Total Dexterity: {totalAttributes.Dexterity}");
            sb.AppendLine($"Total Intelligence: {totalAttributes.Intelligence}");
            sb.AppendLine($"Damage: {damage}");
            Console.WriteLine(sb.ToString());
        }
    }
}
