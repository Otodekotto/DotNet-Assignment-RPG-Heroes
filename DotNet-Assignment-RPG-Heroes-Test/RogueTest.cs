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
    public class RogueTest
    {
        #region HeroCreation
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
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var hero = new Rogue(name);
            HeroAttribute actual = hero.LevelAttribute;

            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroLevelUp
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
            var rogue = new Rogue("Jakob");
            string name = "Axecalibur";
            int requiredLevel = 4;
            int weaponDamage = 999;
            var expected = "You Do Not Have The Requirement To Equip This Weapon!";
            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);

            var actual = Assert.Throws<InvalidWeaponException>(() => rogue.Equip(weapon)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingWeapon_ShouldBeAbleToEquipIt()
        {
            var rogue = new Rogue("Jakob");
            string name = "Daggeribur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Dagger, weaponDamage);
            var expected = weapon;

            rogue.Equip(weapon);
            rogue.Equipments.TryGetValue(SlotType.Weapon, out Item? item);
            Weapon? currentWeapon = item as Weapon;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Function_HeroEquippingWrongArmor_ShouldGiveInvalidArmorException()
        {
            var rogue = new Rogue("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 4;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = "You Do Not Have The Requirement To Equip This Armor!";
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);

            var actual = Assert.Throws<InvalidArmorException>(() => rogue.Equip(armor)).Message;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_HeroEquippingArmor_ShouldBeAbleToEquipIt()
        {

            var rogue = new Rogue("Jakob");
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 100;
            int dexterity = 50;
            int intelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            var expected = armor;

            rogue.Equip(armor);
            rogue.Equipments.TryGetValue(SlotType.Body, out Item? item);
            Armor? currentWeapon = item as Armor;
            var actual = currentWeapon;

            Assert.Equal(expected, actual);
        }

        #endregion

        #region HeroAttributeCalculation
        [Fact]
        public void Function_CalculatingHeroAttributeWithZeroArmorEquipment_ShouldGiveCorrectAttributeWithoutEquipment()
        {
            var rogue = new Rogue("Jakob");
            int strength = 2;
            int dexterity = 6;
            int intelligence = 1;
            HeroAttribute expected = new HeroAttribute(strength, dexterity, intelligence);

            var actual = rogue.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithOneArmorEquipment_ShouldGiveCorrectAttributeOneEquipment()
        {
            var rogue = new Rogue("Jack");
            int expectedStrength = 102;
            int expectedDexterity = 56;
            int expectedIntelligence = 1;
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            HeroAttribute expected = new HeroAttribute(expectedStrength, expectedDexterity, expectedIntelligence);
            rogue.Equip(armor);

            var actual = rogue.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithTwoArmorEquipment_ShouldGiveCorrectAttributeTwoEquipment()
        {
            var rogue = new Rogue("Jack");
            int expectedStrength = 202;
            int expectedDexterity = 106;
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
            rogue.Equip(armor);
            rogue.Equip(armorTwo);

            var actual = rogue.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroAttributeWithWithAReplacedPieceOfArmor_ShouldGiveCorrectAttributeWithTheReplaceEquipment()
        {
            var rogue = new Rogue("Jack");
            int expectedStrength = 2;
            int expectedDexterity = 56;
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
            rogue.Equip(armor);
            rogue.Equip(armorTwo);


            var actual = rogue.TotalAttributes();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region HeroDamageCalculation

        [Fact]
        public void Function_CalculatingHeroDamageWithZeroEquipment_ShouldGiveCorrectHeroDamageWithoutEquipment()
        {
            var rogue = new Rogue("Jakob");
            int heroDamage = 1;
            var expected = heroDamage;

            var actual = rogue.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquipped_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var rogue = new Rogue("Jakob");
            string name = "Daggeribur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var weapon = new Weapon(name, requiredLevel, WeaponType.Dagger, weaponDamage);
            rogue.Equip(weapon);
            double damagingAttribute = 6;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;


            var actual = rogue.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedButSwappedWithAnotherWeapon_ShouldGiveCorrectHeroDamageWithWeaponEquipped()
        {
            var rogue = new Rogue("Jakob");
            string daggerName = "Daggeribur";
            string swordName = "Excalibur";
            int requiredLevel = 1;
            int weaponDamage = 9999;
            int weaponDamageAxe = 999;
            int weaponTwoDamageSword = 9999;
            var weapon = new Weapon(daggerName, requiredLevel, WeaponType.Dagger, weaponDamageAxe);
            var weaponTwo = new Weapon(swordName, requiredLevel, WeaponType.Sword, weaponTwoDamageSword);
            rogue.Equip(weapon);
            rogue.Equip(weaponTwo);
            double damagingAttribute = 6;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = rogue.Damage();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Function_CalculatingHeroDamageWithAWeaponEquippedAndArmor_ShouldGiveCorrectHeroDamageWithWeaponEquippedAndArmor()
        {
            var rogue = new Rogue("Jakob");
            string daggerName = "Daggeribur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            int weaponDamageAxe = 999;
            var weapon = new Weapon(daggerName, requiredLevel, WeaponType.Dagger, weaponDamageAxe);
            rogue.Equip(weapon);
            string name = "Dawn Armor";
            int armorStrength = 100;
            int armorDexterity = 50;
            int armorIntelligence = 0;
            HeroAttribute armorAttribute = new HeroAttribute(armorStrength, armorDexterity, armorIntelligence);
            var armor = new Armor(name, requiredLevel, SlotType.Body, ArmorType.Mail, armorAttribute);
            rogue.Equip(armor);
            double damagingAttribute = 56;
            var heroDamage = (int)(weaponDamage * (1 + (damagingAttribute / 100)));
            var expected = heroDamage;

            var actual = rogue.Damage();

            Assert.Equal(expected, actual);
        }
        #endregion

        #region Heroes Dispaly

        [Fact]
        public void Function_CallOnDisplayFunctionForRogue_ShouldDisplayCorrectRogueState()
        {
            string name = "James";
            int level = 1;
            int strength = 2;
            int dexterity = 6;
            int intelligence = 1;
            int damage = 1;
            var rogue = new Rogue(name);
            StringBuilder rogueStatus = new();
            rogueStatus.AppendLine($"Name: {name}");
            rogueStatus.AppendLine($"Level: {level}");
            rogueStatus.AppendLine($"Total Strength: {strength}");
            rogueStatus.AppendLine($"Total Dexterity: {dexterity}");
            rogueStatus.AppendLine($"Total Intelligence: {intelligence}");
            rogueStatus.AppendLine($"Damage: {damage}");
            var expected = rogueStatus.ToString();

            var actual = rogue.Display();

            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
