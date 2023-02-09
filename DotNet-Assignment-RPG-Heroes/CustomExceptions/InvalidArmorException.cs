using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Assignment_RPG_Heroes.CustomExceptions
{
    internal class InvalidArmorException : Exception
    {
        public override string Message => "You Do Not Have The Requirement To Equip This Armor!";
    }
}
