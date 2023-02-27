using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Marines
{
    internal class Dolphin : Marine
    {
        private int _tricksLearned;
        public Dolphin() : this(0, "0")
        {

        }

        public Dolphin(double swimSpeed, string eatsFish) : base(swimSpeed, eatsFish)
        {
            _tricksLearned = 0;
        }

        public int TricksLearned
        {
            get { return _tricksLearned;}
            set { _tricksLearned = value;}
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Tricks learned: {0}\r", _tricksLearned);

            return strOut;
        }

    }
}
