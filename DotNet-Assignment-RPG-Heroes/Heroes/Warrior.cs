using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
        }

        public override int[] LevelAttribute { get; set; } = { 5, 2, 1 };
        public override string[]? Equipment { get ; set; }
        public override WeaponType[]? ValidWeaponTypes { get;} = { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword};
        public override ArmorType[]? ValidArmorTypes { get; } = { ArmorType.Mail, ArmorType.Plate };

        public override void Damage()
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
        }

        public override void TotalAttributes()
        {
            throw new NotImplementedException();
        }
    }
}
