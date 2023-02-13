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
            string expected = name;

            var hero = new Warrior(name);
            string actual = hero.Name;

            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithLevel()
        {
            string name = "Warrior";
            int expected = 1;

            var hero = new Warrior(name);
            int actual = hero.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWarriorHero_ShouldCreateWarriorWithAttributes()
        {
            string name = "Warrior";
            int strength = 5;
            int dexterity = 2;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var hero = new Warrior(name);
            HeroAttribute actual = hero.LevelAttribute;
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithName()
        {
            string name = "Mage";
            string expected = name;

            var hero = new Mage(name);
            string actual = hero.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithLevel()
        {
            string name = "Mage";
            int expected = 1;

            var hero = new Mage(name);
            int actual = hero.Level;
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeMageHero_ShouldCreateMageWithAttributes()
        {
            string name = "Mage";
            int strength = 1;
            int dexterity = 1;
            int intelligence = 8;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var hero = new Mage(name);
            HeroAttribute actual = hero.LevelAttribute;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithName()
        {
            string name = "Ranger";
            string expected = name;

            var hero = new Ranger(name);
            string actual = hero.Name;
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithLevel()
        {
            string name = "Ranger";
            int expected = 1;

            var hero = new Ranger(name);
            int actual = hero.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRangerHero_ShouldCreateRangerWithAttributes()
        {
            string name = "Ranger";
            int strength = 1;
            int dexterity = 7;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var hero = new Ranger(name);
            HeroAttribute actual = hero.LevelAttribute;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithName()
        {
            string name = "Rogue";
            string expected = name;

            var hero = new Rogue(name);
            string actual = hero.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithLevel()
        {
            string name = "Rogue";
            int expected = 1;

            var hero = new Rogue(name);
            int actual = hero.Level;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeRogueHero_ShouldCreateRogueWithAttributes()
        {
            string name = "Rogue";
            int strength = 2;
            int dexterity = 6;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute (strength , dexterity, intelligence);

            var hero = new Rogue(name);
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

        #region HeroEquipItem
        [Fact]
        public void Function_HeroEquippingWrongWeapon_ShouldGiveInvalidWeaponException()
        {
            var warrior = new Warrior("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var expected = "You Do Not Have The Requirement To Equip This Weapon!";
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var actual = Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon)).Message;

            Assert.Equal(expected , actual);
        }
        [Fact]
        public void Function_HeroEquippingWeapon_ShouldBeAbleToEquipIt()
        {

            var warrior = new Warrior("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
            var expected = weapon;

            warrior.Equip(weapon);
            warrior.Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? currentWeapon = item as Weapon;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Function_HeroEquippingWrongArmor_ShouldGiveInvalidArmorException()
        {
            var warrior = new Warrior("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 4;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = "You Do Not Have The Requirement To Equip This Armor!";
            var armor = new Armor(name, requiredLevel, SlotType.Body , ArmorType.Mail , armorAttribute);

            var actual = Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingArmor_ShouldBeAbleToEquipIt()
        {

            var warrior = new Warrior("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            var expected = armor;

            warrior.Equip(armor);
            warrior.Equipments.TryGetValue(SlotType.Body, out Item? item);
            Armor? currentWeapon = item as Armor;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region HeroAttributeCalculation
        [Fact]
        public void Function_CalculatingHeroAttributeWithZeroArmorEquipment_ShouldGiveCorrectAttributeWithoutEquipment()
        {
            var warrior = new Warrior("Jakob");
            int strength = 5;
            int dexterity = 2;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var actual = warrior.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithOneArmorEquipment_ShouldGiveCorrectAttributeOneEquipment()
        {
            var warrior = new Warrior("Jack");
            int expectedStrength = 105;
            int expectedDexterity = 52;
            int expectedIntelligence = 1;
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            warrior.Equip(armor);

            var actual = warrior.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithTwoArmorEquipment_ShouldGiveCorrectAttributeTwoEquipment()
        {
            var warrior = new Warrior("Jack");
            int expectedStrength = 205;
            int expectedDexterity = 102;
            int expectedIntelligence = 1;
            string armorName = "Dawn Armor";
            string helmetName = "Dawn Helmet";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(armorName, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            var armorTwo = new Armor(helmetName, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            warrior.Equip(armor);
            warrior.Equip(armorTwo);

            var actual = warrior.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithWithAReplacedPieceOfArmor_ShouldGiveCorrectAttributeWithTheReplaceEquipment()
        {
            var warrior = new Warrior("Jack");
            int expectedStrength = 5;
            int expectedDexterity = 52;
            int expectedIntelligence = 101;
            string armorName = "Dawn Armor";
            string armorTwoName = "Dusk Armor";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            int armorTwoStrength = 0;
            int armorTwoDexterity = 50;
            int armorTwoIntelligence = 100;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            HeroAttribute armorTwoAttribute = new HeroAttribute(armorTwoStrength, armorTwoDexterity, armorTwoIntelligence);
            var armor = new Armor(armorName, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            var armorTwo = new Armor(armorTwoName, requiredLevel, SlotType.Body, ArmorType.Mail, armorTwoAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            warrior.Equip(armor);
            warrior.Equip(armorTwo);


            var actual = warrior.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroDamageCalculation

        [Fact]
        public void Function_CalculatingHeroDamageWithZeroEquipment_ShouldGiveCorrectHeroDamageWithoutEquipment()
        {
            var warrior = new Warrior("Jakob");
            int heroDamage = 1;
            var expected = heroDamage;

            var actual = warrior.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquipped_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var warrior = new Warrior("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
            warrior.Equip(weapon);
            double damagingAttribute = 5;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;
           
            
            var actual = warrior.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedButSwappedWithAnotherWeapon_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var warrior = new Warrior("Jakob");
            string axeName = "Axecalibur";
            string swordName = "Excalibur";
            int requiredLevel = 1;
            int weaponDamage = 9999;
            int weaponDamageAxe = 999;
            int weaponTwoDamageSword= 9999;
            var weapon = new Weapon(axeName, requiredLevel, WeaponType.Axe, weaponDamageAxe);
            var weaponTwo = new Weapon(swordName, requiredLevel, WeaponType.Sword, weaponTwoDamageSword);
            warrior.Equip(weapon);
            warrior.Equip(weaponTwo);
            double damagingAttribute = 5;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = warrior.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedAndArmor_ShouldGiveCorrectHeroDamageWithWeaponEquippedAndArmor()
        {
            var warrior = new Warrior("Jakob");
            string axeName = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            int weaponDamageAxe = 999;
            var weapon = new Weapon(axeName, requiredLevel, WeaponType.Axe, weaponDamageAxe);
            warrior.Equip(weapon);
            string name = "Dawn Armor";
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            warrior.Equip(armor);
            double damagingAttribute = 105;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = warrior.Damage();

            Assert.Equal(expected, actual);
        }
        #endregion
    }
}   