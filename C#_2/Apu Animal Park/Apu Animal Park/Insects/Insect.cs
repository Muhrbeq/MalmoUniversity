using Apu_Animal_Park.Animals;
using Apu_Animal_Park.Birds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Insects
{
    internal class Insect : Animal
    {
        private int _numOfEyes;
        private double _size;

        public Insect(int numOfEyes, double size)
        {
            _numOfEyes = numOfEyes;
            _size = size;
        }



        public int NumOfEyes
        {
            get { return _numOfEyes; }
            set { _numOfEyes = value; }
        }

        public double Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Number of eyes: {0}\rSize [cm]: {1}\r", _numOfEyes, _size);

            return strOut;
        }
    }

    public enum InsectSpecies
    {
        Bee,
        Spider
    }
}
