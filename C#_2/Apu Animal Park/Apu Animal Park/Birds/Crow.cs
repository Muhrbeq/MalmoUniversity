using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Birds
{
    internal class Crow : Bird
    {
        private int _amountOfFriends;

        public Crow() : this(0, 0) { }

        public Crow(double wingSpan, double flySpeed) : base(wingSpan, flySpeed)
        {
            _amountOfFriends = 0;
        }

        public int AmountOfFriends
        {
            get { return _amountOfFriends; }
            set { _amountOfFriends = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Amount of friends: {0}\r", _amountOfFriends);

            return strOut;
        }
    }
}
