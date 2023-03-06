using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Animals
{
    internal class FoodSchedule
    {
        private EaterType _eaterType;
        private List<string> _foodList = new List<string>();

        public int Count
        {
            get { return _foodList.Count; }
        }

        public EaterType EaterType
        {
            get { return _eaterType; }
            set { _eaterType = value; }
        }

        public FoodSchedule() 
        { 

        }

        public void Add(string item)
        {
            _foodList.Add(item);
        }

        public bool ChangeAt(int index, string item)
        {
            if (!CheckIndex(index))
            {
                return false;
            }

            _foodList[index] = item;

            return true;
        }

        public bool CheckIndex(int index)
        {
            if ((index < 0) || (index > _foodList.Count))
            {
                return false;
            }
            return true;
        }

        public bool DeleteAt(int index)
        {
            return false;
        }

        public string[] GetFoodListInfoStrings()
        {
            return _foodList.ToArray();
        }

        public string Title()
        {
            return _foodList[0];
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

    public enum EaterType
    {
        Carnivore,
        Herbivore,
        Omnivorous
    }
}
