using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using DotNet_Assignment_RPG_Heroes.Heroes;

namespace DotNet_Assignment_RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength , dexterity , intelligence);
            var armor = new Armor ("Dawn Armor", 1, SlotType.Body , ArmorType.Mail , armorAttribute );
            Console.WriteLine(armor.Name);
            Console.WriteLine(armor.RequiredLevel);
            Console.WriteLine(armor.ArmorType);

            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var hero = new Warrior("Moon");
            hero.Equip(weapon);
            hero.Equip(armor);

            hero.Display();
        }
    }
}