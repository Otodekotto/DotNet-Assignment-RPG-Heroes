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
    public class MageTest
    {
        #region HeroCreation
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
        #endregion

        #region HeroLevelUp
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
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);
            HeroAttribute actual = hero.LevelAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroEquipItem
        [Fact]
        public void Function_HeroEquippingWrongWeapon_ShouldGiveInvalidWeaponException()
        {
            var mage = new Mage("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var expected = "You Do Not Have The Requirement To Equip This Weapon!";
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var actual = Assert.Throws<InvalidWeaponException>(() => mage.Equip(weapon)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingWeapon_ShouldBeAbleToEquipIt()
        {

            var mage = new Mage("Jakob");
            string name = "Wandibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Wand, weaponDamage);
            var expected = weapon;

            mage.Equip(weapon);
            mage.Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? currentWeapon = item as Weapon;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Function_HeroEquippingWrongArmor_ShouldGiveInvalidArmorException()
        {
            var mage = new Mage("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 4;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = "You Do Not Have The Requirement To Equip This Armor!";
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);

            var actual = Assert.Throws<InvalidArmorException>(() => mage.Equip(armor)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingArmor_ShouldBeAbleToEquipIt()
        {

            var mage = new Mage("Jakob");
            string name = "Dawn Robe";
            int requiredLevel = 1;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);
            var expected = armor;

            mage.Equip(armor);
            mage.Equipments.TryGetValue(SlotType.Body, out Item? item);
            Armor? currentWeapon = item as Armor;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region HeroAttributeCalculation
        [Fact]
        public void Function_CalculatingHeroAttributeWithZeroArmorEquipment_ShouldGiveCorrectAttributeWithoutEquipment()
        {
            var mage = new Mage("Jakob");
            int strength = 1;
            int dexterity = 1;
            int intelligence = 8;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var actual = mage.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithOneArmorEquipment_ShouldGiveCorrectAttributeOneEquipment()
        {
            var mage = new Mage("Jack");
            int expectedStrength = 101;
            int expectedDexterity = 51;
            int expectedIntelligence = 8;
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            mage.Equip(armor);

            var actual = mage.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithTwoArmorEquipment_ShouldGiveCorrectAttributeTwoEquipment()
        {
            var mage = new Mage("Jack");
            int expectedStrength = 201;
            int expectedDexterity = 101;
            int expectedIntelligence = 8;
            string armorName = "Dawn Armor";
            string helmetName = "Dawn Helmet";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(armorName, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);
            var armorTwo = new Armor(helmetName, requiredLevel, SlotType.Head, ArmorType.Cloth, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            mage.Equip(armor);
            mage.Equip(armorTwo);

            var actual = mage.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithWithAReplacedPieceOfArmor_ShouldGiveCorrectAttributeWithTheReplaceEquipment()
        {
            var mage = new Mage("Jack");
            int expectedStrength = 1;
            int expectedDexterity = 51;
            int expectedIntelligence = 108;
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
            var armor = new Armor(armorName, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);
            var armorTwo = new Armor(armorTwoName, requiredLevel, SlotType.Body, ArmorType.Cloth, armorTwoAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            mage.Equip(armor);
            mage.Equip(armorTwo);


            var actual = mage.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroDamageCalculation

        [Fact]
        public void Function_CalculatingHeroDamageWithZeroEquipment_ShouldGiveCorrectHeroDamageWithoutEquipment()
        {
            var mage = new Mage("Jakob");
            int heroDamage = 1;
            var expected = heroDamage;

            var actual = mage.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquipped_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var mage = new Mage("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Wand, weaponDamage);
            mage.Equip(weapon);
            double damagingAttribute = 8;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;


            var actual = mage.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedButSwappedWithAnotherWeapon_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var mage = new Mage("Jakob");
            string wandName = "Wandibur";
            string staffName = "Staffibur";
            int requiredLevel = 1;
            int weaponDamage = 9999;
            int weaponDamageAxe = 999;
            int weaponTwoDamageSword = 9999;
            var weapon = new Weapon(wandName, requiredLevel, WeaponType.Wand, weaponDamageAxe);
            var weaponTwo = new Weapon(staffName, requiredLevel, WeaponType.Staff, weaponTwoDamageSword);
            mage.Equip(weapon);
            mage.Equip(weaponTwo);
            double damagingAttribute = 8;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = mage.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedAndArmor_ShouldGiveCorrectHeroDamageWithWeaponEquippedAndArmor()
        {
            var mage = new Mage("Jakob");
            string wandName = "Wandibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            int weaponDamageAxe = 999;
            var weapon = new Weapon(wandName, requiredLevel, WeaponType.Wand, weaponDamageAxe);
            mage.Equip(weapon);
            string name = "Dawn Armor";
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 100;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Cloth, armorAttribute);
            mage.Equip(armor);
            double damagingAttribute = 108;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = mage.Damage();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region Heroes Dispaly
        [Fact]
        public void Function_CallOnDisplayFunctionForMage_ShouldDisplayCorrectMageState()
        {
            string name = "Julian";
            int level = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 8;
            int damage = 1;
            var mage = new Mage(name);
            StringBuilder mageStatus = new();
            mageStatus.AppendLine($"Name: {name}");
            mageStatus.AppendLine($"Level: {level}");
            mageStatus.AppendLine($"Total Strength: {strength}");
            mageStatus.AppendLine($"Total Dexterity: {dexterity}");
            mageStatus.AppendLine($"Total Intelligence: {intelligence}");
            mageStatus.AppendLine($"Damage: {damage}");
            var expected = mageStatus.ToString();

            var actual = mage.Display();

            Assert.Equal(expected, actual);
        }
      
        #endregion
    }
}
