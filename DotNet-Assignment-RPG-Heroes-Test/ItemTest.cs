using DotNet_Assignment_RPG_Heroes.Enums;
using DotNet_Assignment_RPG_Heroes.Equipments;
using DotNet_Assignment_RPG_Heroes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes_Test
{
    public class ItemTest
    {
        #region ItemCreation
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectName()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var expected = name;

            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
            var actual = weapon.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectRequiredLevel()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var expected = requiredLevel;

            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
            var actual = weapon.RequiredLevel;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectSlotType()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var expected = SlotType.Weapon;

            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
            var actual = weapon.Slot;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateWeaponWithCorrectWeaponDamage()
        {
            string name = "Axecalibur";
            int requiredLevel = 1;
            int weaponDamage = 999;
            var expected = weaponDamage;

            var weapon = new Weapon(name, requiredLevel, WeaponType.Axe, weaponDamage);
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
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = name;

            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);
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
            var expected = requiredLevel;

            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);
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
            var expected = SlotType.Head;

            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);
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
            var expected = ArmorType.Mail;

            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);
            var actual = armor.ArmorType;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Constructor_InitializeWeapon_ShouldCreateArmorWithCorrectArmorAttribute()
        {
            string name = "Dawn Armor";
            int requiredLevel = 1;
            int strength = 1;
            int dexterity = 1;
            int intelligence = 1;
            HeroAttribute armorAttribute = new HeroAttribute(strength, dexterity, intelligence);
            var expected = armorAttribute;

            var armor = new Armor(name, requiredLevel, SlotType.Head, ArmorType.Mail, armorAttribute);

            var actual = armor.ArmorAttribute;
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
