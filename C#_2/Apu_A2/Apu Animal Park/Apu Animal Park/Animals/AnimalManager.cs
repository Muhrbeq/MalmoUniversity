using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Animals
{
    internal class AnimalManager
    {
        private List<Animal> _animalList = new List<Animal>();
        private int startID = 0;

        public AnimalManager()
        {

        }

        public bool Add(Animal a)
        {
            if(a == null)
            {
                return false;
            }
            _animalList.Add(a);
            return true;
        }

        public int Count()
        {
            return startID;
        }

        public Animal GetAnimalAt(int index)
        {
            return _animalList[index];
        }

        public string[] GetAnimalInfoStrings()
        {
            string[] strlist = new string[_animalList.Count];
            int index = 0;

            foreach (var animal in _animalList)
            {
                strlist[index] = animal.ToString();
                index++;
            }

            return strlist;
        }

        public string GetNewID(CategoryType c)
        {
            string str = "";
            switch (c)
            {
                case CategoryType.Mammal:
                    str += "M";
                    break;
                case CategoryType.Reptile: 
                    str += "R";
                    break;
            }
            str += startID.ToString();

            startID++;

            return str;
        }
        
    }
}
