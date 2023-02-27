using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Marines
{
    internal class Shark : Marine
    {
        private int _rowOfTeeth;
        public Shark() : this(0, "0")
        {

        }

        public Shark(double swimSpeed, string eatsFish) : base(swimSpeed, eatsFish)
        {
            _rowOfTeeth = 0;
        }

        public int RowOfTeeth
        {
            get { return _rowOfTeeth; }
            set { _rowOfTeeth = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Row of teeth: {0}\r", _rowOfTeeth);

            return strOut;
        }
    }
}
