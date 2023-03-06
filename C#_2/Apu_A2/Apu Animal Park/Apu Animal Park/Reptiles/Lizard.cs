using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Lizard : Reptile
    {
        private int _lengthOfTongue;
        private double _regenerationTime;
        private string _breed;

        FoodSchedule _foodSchedule;

        public Lizard() : this(0, 0)
        {

        }

        public Lizard(int amountOfLegs, int amountOfDaysUntilEggsHatch) : base(amountOfLegs, amountOfDaysUntilEggsHatch)
        {
            _lengthOfTongue = 0;
            SetFoodSchedule();
        }

        public int LengthOfTongue
        {
            get { return _lengthOfTongue; }
            set { _lengthOfTongue = value;}
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Length of tongue {0}\r", _lengthOfTongue);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            _foodSchedule = new FoodSchedule();
            _foodSchedule.EaterType = EaterType.Omnivorous;
            _foodSchedule.Add("Morning: 1 Fly");
            _foodSchedule.Add("Lunch: Nothing");
            _foodSchedule.Add("Evening: Bones");
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
