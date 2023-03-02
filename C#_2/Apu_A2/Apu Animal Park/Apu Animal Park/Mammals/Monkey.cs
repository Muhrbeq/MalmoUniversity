using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Monkey : Mammal
    {
        private double _swingAltitude;
        private int _eatAmountBananas;

        public Monkey(int numberOfTeeth, int amountOfLegs) : base(numberOfTeeth, amountOfLegs)
        {
            _swingAltitude = 0;
        }

        public double SwingAltitude
        {
            get { return _swingAltitude; }
            set { _swingAltitude = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Swing Altitude: {0}", _swingAltitude);

            return strOut;
        }

        public override FoodSchedule GetFoodSchedule()
        {
            throw new NotImplementedException();
        }

        public override string GetExtraInfo()
        {
            throw new NotImplementedException();
        }

    }
}
