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

        FoodSchedule _foodSchedule;

        public Monkey(int numberOfTeeth, int amountOfLegs) : base(numberOfTeeth, amountOfLegs)
        {
            _swingAltitude = 0;
            SetFoodSchedule();
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

        private void SetFoodSchedule()
        {
            _foodSchedule = new FoodSchedule();
            _foodSchedule.EaterType = EaterType.Omnivorous;
            _foodSchedule.Add("Morning: Banans");
            _foodSchedule.Add("Lunch: Bananas");
            _foodSchedule.Add("Evening: More bananas");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return _foodSchedule;
        }

        public override string GetExtraInfo()
        {
            return ToString();
        }

    }
}
