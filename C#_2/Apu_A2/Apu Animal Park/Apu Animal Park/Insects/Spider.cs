//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Apu_Animal_Park.Insects
//{
//    internal class Spider : Insect
//    {
//        private int _numberOfFangs; 
//        public Spider() : this(0, 0)
//        {

//        }

//        public Spider(int numOfEyes, double size) : base(numOfEyes, size) 
//        {
//            _numberOfFangs = 0;
//        }

//        public int NumberOfFangs
//        {
//            get { return _numberOfFangs; }
//            set { _numberOfFangs = value; }
//        }

//        /// <summary>
//        /// Overloaded tostring method.
//        /// </summary>
//        /// <returns>Returns a string containing info about animal</returns>
//        public override string ToString()
//        {
//            string strOut = base.ToString();
//            strOut += String.Format("Number of fangs: {0}\r", _numberOfFangs);

//            return strOut;
//        }
//    }
//}
