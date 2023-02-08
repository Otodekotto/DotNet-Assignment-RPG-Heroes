using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Heroes;

namespace DotNet_Assignment_RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var armor = new Armor { Name = "Dawn Armor", RequiredLevel = 21, ArmorType = ArmorType.Cloth };
            Console.WriteLine(armor.Name);
            Console.WriteLine(armor.RequiredLevel);
            Console.WriteLine(armor.ArmorType);

            var hero = new Warrior("Moon");
            hero.Display();
        }
    }
}