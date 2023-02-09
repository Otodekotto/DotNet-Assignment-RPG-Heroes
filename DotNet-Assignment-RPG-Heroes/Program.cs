using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Heroes;

namespace DotNet_Assignment_RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var armor = new Armor { Name = "Dawn Armor", RequiredLevel = 1, ArmorType = ArmorType.Mail};
            //Console.WriteLine(armor.Name);
            //Console.WriteLine(armor.RequiredLevel);
            //Console.WriteLine(armor.ArmorType);

            string name = "Axecalibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var hero = new Warrior("Moon");
            hero.Equip(weapon);
            //hero.Equip(armor);
            hero.Display();
        }
    }
}