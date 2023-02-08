using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Name { get => name; set => name = value; }

        public int Level { get; set; } = 1;
        public abstract HeroAttribute LevelAttribute { get; set; }
        public Dictionary<SlotType, Item?> Equipments = new Dictionary<SlotType, Item?>
        {
            [SlotType.Head] = null,
            [SlotType.Body] = null,
            [SlotType.Legs] = null,
            [SlotType.Weapon]  = null
        };
        public abstract List<WeaponType> ValidWeaponTypes { get;}
        public abstract List<ArmorType> ValidArmorTypes { get;}

        public Hero(string name)
        {
            this.name = name;
        }
        public abstract void LevelUp();
        public void Equip(Item item) 
        {
            
        }
        public abstract void Damage();
        public void TotalAttributes()
        {
            Console.WriteLine("Total Attributes: " + (LevelAttribute.Strength + LevelAttribute.Dexterity + LevelAttribute.Intelligence));
        }
        public void Display() 
        {
            Console.WriteLine(Name);
            Console.WriteLine(Level);
            Console.WriteLine("Strength: "+ LevelAttribute.Strength );
            Console.WriteLine("Dexterity: " + LevelAttribute.Dexterity );
            Console.WriteLine("Intelligence: " + LevelAttribute.Intelligence );
            foreach(var item in Equipments)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
