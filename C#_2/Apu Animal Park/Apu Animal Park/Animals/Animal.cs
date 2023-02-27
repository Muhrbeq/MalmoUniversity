using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Animals
{
    internal class Animal
    {
        //private variables for Animal class
        private string _id;
        private string _name;
        private CategoryType _category;
        private int _age;
        private GenderType _gender;

        /// <summary>
        /// Constructor, Resets the animal
        /// </summary>
        public Animal()
        {
            Reset();
        }

        /// <summary>
        /// Resets the animal
        /// </summary>
        public void Reset()
        {
            _id = string.Empty;
            _name = string.Empty;
            _category = CategoryType.Bird;
            _age = 0;
            _gender = GenderType.Unknown;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public CategoryType Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
            }
        }

        public GenderType Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Overloaded tostring method
        /// </summary>
        /// <returns>Returns a string with animal info</returns>
        public override string ToString()
        {
            string strOut = base.ToString();

            strOut = String.Format("ID: {0}\rName: {1}\rCategory: {2}\rAge: {3}\rGender: {4}\r", _id, _name, _category, _age, _gender);

            return strOut;
        }

    }

   
}
