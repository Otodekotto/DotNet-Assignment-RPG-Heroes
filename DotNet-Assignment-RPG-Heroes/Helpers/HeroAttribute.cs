using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Helper
{
    public class HeroAttribute
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is HeroAttribute attribute &&
                   Strength == attribute.Strength &&
                   Dexterity == attribute.Dexterity &&
                   Intelligence == attribute.Intelligence;
        }

        public HeroAttribute(int strength, int dexterity , int intelligence)
        {
            this.Strength = strength;
            this.Dexterity = dexterity;
            this.Intelligence = intelligence;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength, Dexterity, Intelligence);
        }

        public static HeroAttribute operator + ( HeroAttribute heroCurrentAttribute, HeroAttribute heroLevelUpAttribute)
        {
            return new HeroAttribute (heroCurrentAttribute.Strength + heroLevelUpAttribute.Strength, heroCurrentAttribute.Dexterity + heroLevelUpAttribute.Dexterity, heroCurrentAttribute.Intelligence + heroLevelUpAttribute.Intelligence);
        }


    }
}
