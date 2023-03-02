using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Animals
{
    internal interface IAnimal
    {
        string Name { get; set; }
        string Id { get; set; }
        GenderType Gender { get; set; }

        FoodSchedule GetFoodSchedule();
        string GetExtraInfo();
    }
}
