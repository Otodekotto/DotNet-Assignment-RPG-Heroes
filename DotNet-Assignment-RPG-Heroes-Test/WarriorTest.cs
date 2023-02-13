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
    public class WarriorTest
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

            Assert.Equal(expected, actual);
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
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);

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
            int weaponTwoDamageSword = 9999;
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

        #region Heroes Dispaly
        [Fact]
        public void Function_CallOnDisplayFunctionForWarrior_ShouldDisplayCorrectWarriorState()
        {
            string name = "Jimmy";
            int level = 1;
            int strength = 5;
            int dexterity = 2;
            int intelligence = 1;
            int damage = 1;
            var warrior = new Warrior(name);
            StringBuilder warriorStatus = new();
            warriorStatus.AppendLine($"Name: {name}");
            warriorStatus.AppendLine($"Level: {level}");
            warriorStatus.AppendLine($"Total Strength: {strength}");
            warriorStatus.AppendLine($"Total Dexterity: {dexterity}");
            warriorStatus.AppendLine($"Total Intelligence: {intelligence}");
            warriorStatus.AppendLine($"Damage: {damage}");
            var expected = warriorStatus.ToString();

            var actual = warrior.Display();

            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
