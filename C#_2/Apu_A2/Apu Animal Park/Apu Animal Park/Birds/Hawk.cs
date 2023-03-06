//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Apu_Animal_Park.Birds
//{
//    internal class Hawk : Bird
//    {
//        private int _amountOfFeathers;

//        public Hawk(): this(0,0) { }

//        public Hawk(double wingSpan, double flySpeed) : base(wingSpan, flySpeed) 
//        {
//            _amountOfFeathers = 0;
//        }

//        public int AmountOfFeathers
//        {
//            get { return _amountOfFeathers;}
//            set { _amountOfFeathers = value;}
//        }

//        /// <summary>
//        /// Overloaded tostring method.
//        /// </summary>
//        /// <returns>Returns a string containing info about animal</returns>
//        public override string ToString()
//        {
//            string strOut = base.ToString();
//            strOut += String.Format("Amount of feathers: {0}\r", _amountOfFeathers);

//            return strOut;
//        }

//    }
//}
