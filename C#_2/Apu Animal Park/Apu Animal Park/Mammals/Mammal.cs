using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Mammal : Animal
    {
        private int _amountOfLegs;
        private int _numberOfTeeth;


        public Mammal(int numberOfTeeth, int amountOfLegs)
        {
            _amountOfLegs = amountOfLegs;
            _numberOfTeeth = numberOfTeeth;
        }



        public int AmountOfLegs
        {
            get { return _amountOfLegs;}
            set { _amountOfLegs = value;}
        }

        public int NumberOfTeeth
        {
            get { return _numberOfTeeth;}
            set { _numberOfTeeth = value;}
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Amount of legs: {0}\rAmount of teeth: {1}\r", _amountOfLegs, _numberOfTeeth);

            return strOut;
        }
    }

    public enum MammalSpecies
    {
        Dog,
        Monkey
    }
}
