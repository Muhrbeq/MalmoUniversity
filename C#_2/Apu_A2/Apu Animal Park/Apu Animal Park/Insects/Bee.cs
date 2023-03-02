using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Insects
{
    internal class Bee : Insect
    {
        public string _favouriteFlower;

        public Bee() : this(0,0)
        {

        }

        public Bee(int numberOfEyes, double size) : base(numberOfEyes, size)
        {
            _favouriteFlower= string.Empty;
        }

        public string FavouriteFlower
        {
            get { return _favouriteFlower; }
            set { _favouriteFlower = value; }
        }

        /// <summary>
        /// Overloaded tostring method.
        /// </summary>
        /// <returns>Returns a string containing info about animal</returns>
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += String.Format("Favourite flower {0}\r", _favouriteFlower);

            return strOut;
        }

    }
}
