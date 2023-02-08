using DotNet_Assignment_RPG_Heroes.Heroes;

namespace DotNet_Assignment_RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hero = new Warrior("Jonny");
            hero.LevelUp();
            hero.Display();
            
        }
    }
}