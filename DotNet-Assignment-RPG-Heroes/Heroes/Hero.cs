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
        public abstract int[] LevelAttribute { get; set; }
        public abstract string[]? Equipment { get; set; }
        public abstract WeaponType[]? ValidWeaponTypes { get;}
        public abstract ArmorType[]? ValidArmorTypes { get;}

        public Hero(string name)
        {
            this.name = name;
        }
        public abstract void LevelUp();
        public string[] Equip() 
        {
            string[] equips= new string[0];
            return equips; 
        }
        public abstract void Damage();
        public abstract void TotalAttributes();
        public void Display() 
        {
            Console.WriteLine(Name);
            Console.WriteLine(Level);
            Console.WriteLine("Strength: "+ LevelAttribute[0]);
            Console.WriteLine("Dexterity: " + LevelAttribute[1]);
            Console.WriteLine("Intelligence: " + LevelAttribute[2]);
            Console.WriteLine(Equipment);
        }
    }
}
