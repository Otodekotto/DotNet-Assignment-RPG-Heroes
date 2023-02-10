using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using DotNet_Assignment_RPG_Heroes.Heroes;
using DotNet_Assignment_RPG_Heroes.Enums;
using Moq;
using System;
using static System.Net.Mime.MediaTypeNames;
using DotNet_Assignment_RPG_Heroes.CustomExceptions;

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

            int strength = 5;
            int dexterity = 2;
            int intelligence = 1;

            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
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

            int strength = 1;
            int dexterity = 1;
            int intelligence = 8;

            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
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

            int strength = 1;
            int dexterity = 7;
            int intelligence = 1;

            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithName()
        {
            string name = "Rogue";
            var hero = new Rogue(name);

            string expected = name;
            string actual = hero.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithLevel()
        {
            string name = "Rogue";
            var hero = new Rogue(name);

            int expected = 1;
            int actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithAttributes()
        {
            string name = "Rogue";
            var hero = new Rogue(name);

            int strength = 2;
            int dexterity = 6;
            int intelligence = 1;

            HeroAttribute expected = new HeroAttribute (strength , dexterity, intelligence);
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

            int strength = 8;
            int dexterity = 4;
            int intelligence = 2;

            hero.LevelUp();
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_MageLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Mage";
            var hero = new Mage(name);

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
            int strength = 2;
            int dexterity = 2;
            int intelligence = 13;
            hero.LevelUp();
            HeroAttribute expected = new HeroAttribute (strength , dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_RangerLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Ranger";
            var hero = new Ranger(name);
 
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

            hero.LevelUp();
            int strength = 2;
            int dexterity = 12;
            int intelligence = 2;
            HeroAttribute expected = new HeroAttribute ( strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_RogueLevelUp_ShouldLevelUpAndGetALevel()
        {
            string name = "Rogue";
            var hero = new Rogue(name);
            hero.LevelUp();
            var expected = 2;
            var actual = hero.Level;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_RogueLevelUp_ShouldLevelUpAndGetCorrectAttribute()
        {
            string name = "Rogue";
            var hero = new Rogue(name);
            hero.LevelUp();

            int strength = 3;
            int dexterity = 10;
            int intelligence = 2;

            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion

        #region ItemCreation
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectName()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name , requiredLevel, WeaponType.Axe , weaponDamage);

            var expected = name;
            var actual = weapon.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectRequiredLevel()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var expected = requiredLevel;
            var actual = weapon.RequiredLevel;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectSlotType()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var expected = SlotType.Weapon;
            var actual = weapon.Slot;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectWeaponDamage()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var expected = weaponDamage;
            var actual = weapon.WeaponDamage;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeArmor_ShouldCreateArmorWithCorrectName()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute (strength,dexterity,intelligence );
            var armor = new Armor(name, requiredLevel, SlotType.Head , ArmorType.Mail , armorAttribute);

            var expected = name;
            var actual = armor.Name;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateArmorWithCorrectRequiredLevel()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);

            var expected = requiredLevel;
            var actual = armor.RequiredLevel;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateArmorWithCorrectSlotType()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);

            var expected = SlotType.Head;
            var actual = armor.Slot;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateArmorWithCorrectArmorType()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);

            var expected = ArmorType.Mail;
            var actual = armor.ArmorType;
            Assert.Equal(expected, actual);
        }
        public void Constructor_InitializeWeapon_ShouldCreateArmorWithCorrectArmorAttribute()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);

            var expected = armorAttribute;
            var actual = armor.ArmorAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroEquipItem
        [Fact]
        public void Function_HeroEquippingWrongWeapon_ShouldGiveInvalidWeaponException()
        {
            var warrior = new Warrior("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var expected = "You Do Not Have The Requirement To Equip This Weapon!";
            var actual = Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon)).Message;
        }
        [Fact]
        public void Function_HeroEquippingWeapon_ShouldBeAbleToEquipIt()
        {

            var warrior = new Warrior("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            warrior.Equip(weapon);
            
            warrior.Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? currentWeapon = item as Weapon;

            var expected = weapon;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}   