using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Marines
{
    internal class Marine : Animal
    {
        private double _swimSpeed;
        private string _eatsFish;

        public Marine(double swimSpeed, string eatsFish)
        {
            _swimSpeed = swimSpeed;
            _eatsFish = eatsFish;
        }
        


        public double SwimSpeed
        {
            get { return _swimSpeed; }
            set { _swimSpeed = value; }
        }

        public string EatsFish
        {
            get { return _eatsFish; }
            set { _eatsFish = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Swim speed: {0}\rEats fish: {1}\r", _swimSpeed, _eatsFish);

            return strOut;
        }

    }

    public enum MarineSpecies
    {
        Dolphin,
        Shark
    }
}
