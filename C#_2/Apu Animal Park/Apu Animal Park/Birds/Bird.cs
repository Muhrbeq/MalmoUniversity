using Apu_Animal_Park.Animals;
using Apu_Animal_Park.Marines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Birds
{
    internal class Bird : Animal
    {
        //Private variables for Bird class
        private double _wingSpan;
        private double _flySpeed;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wingSpan">Wing span of bird</param>
        /// <param name="flySpeed">Fly speed of bird</param>
        public Bird(double wingSpan, double flySpeed)
        {
            _wingSpan = wingSpan;
            _flySpeed = flySpeed;
        }



        public double WingSpan
        {
            get { return _wingSpan; }
            set { _wingSpan = value; }
        }

        public double FlySpeed
        {
            get { return _flySpeed; }
            set { _flySpeed = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Wing span: {0}\rFly speed: {1}\r", _wingSpan, _flySpeed);

            return strOut;
        }
    }

    public enum BirdSpecies
    {
        Crow,
        Hawk
    }
}
