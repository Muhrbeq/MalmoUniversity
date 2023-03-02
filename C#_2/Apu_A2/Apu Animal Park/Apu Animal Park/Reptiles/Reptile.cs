using Apu_Animal_Park.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park
{
    internal class Reptile : Animal
    {
        //Private variable
        private int _amountOfLegs;
        private int _amountOfDaysUntilEggsHatch;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="amountOfLegs">Amount of legs of reptile</param>
        /// <param name="amountOfDaysUntilEggsHatch">Days until eggs hatch</param>
        public Reptile(int amountOfLegs, int amountOfDaysUntilEggsHatch)
        {
            _amountOfLegs = amountOfLegs;
            _amountOfDaysUntilEggsHatch = amountOfDaysUntilEggsHatch;
        }



        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Amount of legs: {0}\rAmount of days until eggs hatch: {1}\r", _amountOfLegs, _amountOfDaysUntilEggsHatch);

            return strOut;
        }
    }

    /// <summary>
    /// Enum for all reptile species
    /// </summary>
    public enum ReptileSpecies
    {
        Lizard,
        Snake
    }
}
