using DotNet_Assignment_RPG_Heroes.CustomExceptions;
using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using DotNet_Assignment_RPG_Heroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes_Test
{
    public class RangerTest
    {

        #region HeroCreation
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
        #endregion

        #region HeroLevelUp
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
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroEquipItem
        [Fact]
        public void Function_HeroEquippingWrongWeapon_ShouldGiveInvalidWeaponException()
        {
            var ranger = new Ranger("Jakob");
            string name = "Bowibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var expected = "You Do Not Have The Requirement To Equip This Weapon!";
            var weapon = new Weapon(name, requiredLevel, WeaponType.Bow, weaponDamage);

            var actual = Assert.Throws<InvalidWeaponException>(() => ranger.Equip(weapon)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingWeapon_ShouldBeAbleToEquipIt()
        {

            var ranger = new Ranger("Jakob");
            string name = "Bowibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Bow, weaponDamage);
            var expected = weapon;

            ranger.Equip(weapon);
            ranger.Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? currentWeapon = item as Weapon;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Function_HeroEquippingWrongArmor_ShouldGiveInvalidArmorException()
        {
            var ranger = new Ranger("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 4;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = "You Do Not Have The Requirement To Equip This Armor!";
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);

            var actual = Assert.Throws<InvalidArmorException>(() => ranger.Equip(armor)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingArmor_ShouldBeAbleToEquipIt()
        {

            var ranger = new Ranger("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            var expected = armor;

            ranger.Equip(armor);
            ranger.Equipments.TryGetValue(SlotType.Body, out Item? item);
            Armor? currentWeapon = item as Armor;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region HeroAttributeCalculation
        [Fact]
        public void Function_CalculatingHeroAttributeWithZeroArmorEquipment_ShouldGiveCorrectAttributeWithoutEquipment()
        {
            var ranger = new Ranger("Jakob");
            int strength = 1;
            int dexterity = 7;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var actual = ranger.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithOneArmorEquipment_ShouldGiveCorrectAttributeOneEquipment()
        {
            var ranger = new Ranger("Jack");
            int expectedStrength = 101;
            int expectedDexterity = 57;
            int expectedIntelligence = 1;
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            ranger.Equip(armor);

            var actual = ranger.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithTwoArmorEquipment_ShouldGiveCorrectAttributeTwoEquipment()
        {
            var ranger = new Ranger("Jack");
            int expectedStrength = 201;
            int expectedDexterity = 107;
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
            ranger.Equip(armor);
            ranger.Equip(armorTwo);

            var actual = ranger.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithWithAReplacedPieceOfArmor_ShouldGiveCorrectAttributeWithTheReplaceEquipment()
        {
            var ranger = new Ranger("Jack");
            int expectedStrength = 1;
            int expectedDexterity = 57;
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
            ranger.Equip(armor);
            ranger.Equip(armorTwo);


            var actual = ranger.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroDamageCalculation

        [Fact]
        public void Function_CalculatingHeroDamageWithZeroEquipment_ShouldGiveCorrectHeroDamageWithoutEquipment()
        {
            var ranger = new Ranger("Jakob");
            double weaponDamage = 1;
            double damagingAttribute = 7;
            double heroDamage = Math.Round(weaponDamage * (1 + (damagingAttribute / 100)),2);
            var expected = heroDamage;

            var actual = ranger.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquipped_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var ranger = new Ranger("Jakob");
            string name = "Bowibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Bow, weaponDamage);
            ranger.Equip(weapon);
            double damagingAttribute = 7;
            var heroDamage = Math.Round((weaponDamage * (1 + (damagingAttribute / 100))),2);
            var expected = heroDamage;


            var actual = ranger.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedButSwappedWithAnotherWeapon_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var ranger = new Ranger("Jakob");
            string bowName = "Bowibur";
            string ultraBowName = "Ultra Bowibur";
            int requiredLevel = 1;
            int weaponDamage = 9999;
            int weaponDamageAxe = 999;
            int weaponTwoDamageSword = 9999;
            var weapon = new Weapon(bowName, requiredLevel, WeaponType.Bow, weaponDamageAxe);
            var weaponTwo = new Weapon(ultraBowName, requiredLevel, WeaponType.Bow, weaponTwoDamageSword);
            ranger.Equip(weapon);
            ranger.Equip(weaponTwo);
            double damagingAttribute = 7;
            var heroDamage = (weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = ranger.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedAndArmor_ShouldGiveCorrectHeroDamageWithWeaponEquippedAndArmor()
        {
            var ranger = new Ranger("Jakob");
            string bowName = "Bowibur";
            int requiredLevel = 1;
            double weaponDamage = 999;
            int weaponDamageAxe = 999;
            var weapon = new Weapon(bowName, requiredLevel, WeaponType.Bow, weaponDamageAxe);
            ranger.Equip(weapon);
            string name = "Dawn Armor";
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            ranger.Equip(armor);
            double damagingAttribute = 57;
            var heroDamage = (weaponDamage * (1 + (damagingAttribute / 100)));
            double expected = Math.Round(heroDamage,2);

            var actual = ranger.Damage();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region Heroes Dispaly
        [Fact]
        public void Function_CallOnDisplayFunctionForRanger_ShouldDisplayCorrectRangerState()
        {
            string name = "Joseph";
            int level = 1;
            int strength = 1;
            double dexterity = 7;
            int intelligence = 1;
            int weaponDamage = 1;
            double damage = Math.Round(weaponDamage * (1 + (dexterity / 100)), 2);
            string heroClass = "Ranger";
            var ranger = new Ranger(name);
            StringBuilder rangerStatus = new();
            rangerStatus.AppendLine($"Name: {name}");
            rangerStatus.AppendLine($"Class: {heroClass}");
            rangerStatus.AppendLine($"Level: {level}");
            rangerStatus.AppendLine($"Total Strength: {strength}");
            rangerStatus.AppendLine($"Total Dexterity: {dexterity}");
            rangerStatus.AppendLine($"Total Intelligence: {intelligence}");
            rangerStatus.AppendLine($"Damage: {damage}");
            var expected = rangerStatus.ToString();

            var actual = ranger.Display();

            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
