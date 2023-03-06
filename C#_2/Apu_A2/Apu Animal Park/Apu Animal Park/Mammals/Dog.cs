using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Dog : Mammal
    {
        private int _tricksLearned;
        private int _woofLevel;
        private string _breed;

        private FoodSchedule _foodSchedule;

        public Dog() : this(0, 0)
        {
            
        }

        public Dog(int numberOfTeeth, int amountOfLegs) : base(numberOfTeeth, amountOfLegs)
        {
            _breed = "Unknown";

            SetFoodSchedule();
        }

        public string Breed
        {
            get { return _breed; } 
            set { _breed = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Breed {0}\r", _breed);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            _foodSchedule = new FoodSchedule();
            _foodSchedule.EaterType = EaterType.Omnivorous;
            _foodSchedule.Add("Morning: Flakes");
            _foodSchedule.Add("Lunch: Bones");
            _foodSchedule.Add("Evening: Meat");
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
