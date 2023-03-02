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

        public Dog() : this(0, 0)
        {
            
        }

        public Dog(int numberOfTeeth, int amountOfLegs) : base(numberOfTeeth, amountOfLegs)
        {
            _breed = "Unknown";
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
