using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Snake : Reptile
    {
        private int _venomousScale;
        private int _lengthOfTail;


        public Snake() : this(0, 0)
        {

        }

        public Snake(int amountOfLegs, int amountOfDaysUntilEggsHatch) : base(amountOfLegs, amountOfDaysUntilEggsHatch)
        {
            _venomousScale = 0;
        }

        public int VenomousScale
        {
            get { return _venomousScale; }
            set { _venomousScale = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Venomous scale: {0}\r", _venomousScale);

            return strOut;
        }
    }
}
