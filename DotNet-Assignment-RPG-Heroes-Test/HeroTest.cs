using DotNet_Assignment_RPG_Heroes.Heroes;
using Moq;

namespace DotNet_Assignment_RPG_Heroes_Test
{
    public class HeroTest
    {
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithNameLevelAndAttributes()
        {
            string name = "Jonny";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithLevel()
        {
            string name = "Jonny";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes

            int expected = 1;
            int actual = hero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithAttributes()
        {
            string name = "Jonny";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes

            int[] expected = {5,2,1 };
            int[] actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
    }
}