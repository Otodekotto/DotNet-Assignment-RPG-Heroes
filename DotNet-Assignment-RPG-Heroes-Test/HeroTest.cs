using DotNet_Assignment_RPG_Heroes.Helper;
using DotNet_Assignment_RPG_Heroes.Heroes;
using Moq;

namespace DotNet_Assignment_RPG_Heroes_Test
{
    public class HeroTest
    {

        #region HeroCreation
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithNameLevelAndAttributes()
        {
            string name = "Warrior";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithLevel()
        {
            string name = "Warrior";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes

            int expected = 1;
            int actual = hero.Level;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithAttributes()
        {
            string name = "Warrior";
            var hero = new Warrior(name);

            HeroAttribute expected = new HeroAttribute { Strength = 5 , Dexterity = 2 , Intelligence = 1 };
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroLevelUp
        [Fact]
        public void Constructor_WarriorLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Warrior";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            var expected = 2;
            var actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_WarriorLevelUp_ShouldLevelUpAndGetCorrectAttribute()
        {
            string name = "Warrior";
            var hero = new Warrior(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            HeroAttribute expected = new HeroAttribute { Strength = 8, Dexterity = 4, Intelligence = 2 };
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        #endregion
    }
}