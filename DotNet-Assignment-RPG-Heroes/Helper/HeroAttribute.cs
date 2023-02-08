using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.Helper
{
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is HeroAttribute attribute &&
                   Strength == attribute.Strength &&
                   Dexterity == attribute.Dexterity &&
                   Intelligence == attribute.Intelligence;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength, Dexterity, Intelligence);
        }

        public static HeroAttribute operator + ( HeroAttribute heroCurrentAttribute, HeroAttribute heroLevelUpAttribute)
        {
            return new HeroAttribute { Strength = heroCurrentAttribute.Strength + heroLevelUpAttribute.Strength, Dexterity = heroCurrentAttribute.Dexterity + heroLevelUpAttribute.Dexterity, Intelligence = heroCurrentAttribute.Intelligence + heroLevelUpAttribute.Intelligence};
        }


    }
}
