using DotNet_Assignment_RPG_Heroes.Helper;
using DotNet_Assignment_RPG_Heroes.Heroes;
using Moq;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace DotNet_Assignment_RPG_Heroes_Test
{
    public class HeroTest
    {

        #region HeroCreation
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithName()
        {
            string name = "Warrior";
            var hero = new Warrior(name);

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithLevel()
        {
            string name = "Warrior";
            var hero = new Warrior(name);

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
        
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithName()
        {
            string name = "Mage";
            var hero = new Mage(name);

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithLevel()
        {
            string name = "Mage";
            var hero = new Mage(name);

            int expected = 1;
            int actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithAttributes()
        {
            string name = "Mage";
            var hero = new Mage(name);

            HeroAttribute expected = new HeroAttribute { Strength = 1, Dexterity = 1, Intelligence = 8 };
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithName()
        {
            string name = "Ranger";
            var hero = new Ranger(name);

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithLevel()
        {
            string name = "Ranger";
            var hero = new Ranger(name);

            int expected = 1;
            int actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithAttributes()
        {
            string name = "Ranger";
            var hero = new Ranger(name);

            HeroAttribute expected = new HeroAttribute { Strength = 1, Dexterity = 7, Intelligence = 1 };
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

        [Fact]
        public void Constructor_MageLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Mage";
            var hero = new Mage(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            var expected = 2;
            var actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_MageLevelUp_ShouldLevelUpAndGetCorrectAttribute()
        {
            string name = "Mage";
            var hero = new Mage(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            HeroAttribute expected = new HeroAttribute { Strength = 2, Dexterity = 2, Intelligence = 13 };
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_RangerLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Ranger";
            var hero = new Ranger(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            var expected = 2;
            var actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_RangerLevelUp_ShouldLevelUpAndGetCorrectAttribute()
        {
            string name = "Ranger";
            var hero = new Ranger(name);
            //todo: Check Level and Attributes
            hero.LevelUp();
            HeroAttribute expected = new HeroAttribute { Strength = 2, Dexterity = 12, Intelligence = 2 };
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}   