//using Apu_Animal_Park.Birds;
//using Apu_Animal_Park.Insects;
//using Apu_Animal_Park.Marines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apu_Animal_Park.Animals
{
    internal class AnimalFactory
    {
        /// <summary>
        /// Creates mammal based on specie
        /// </summary>
        /// <param name="species">specie of mammal</param>
        /// <param name="numOfTeeth">Number of teeth on mammal</param>
        /// <param name="numOfLegs">Number of legs on mammal</param>
        /// <returns>Returns a mammal based on specie</returns>
        public static Mammal CreateMammal(MammalSpecies species, int numOfTeeth, int numOfLegs)
        {
            Mammal mammal = null;

            switch (species)
            {
                case MammalSpecies.Dog:
                    mammal = new Dog(numOfTeeth, numOfLegs);
                    break;

                case MammalSpecies.Monkey:
                    mammal = new Monkey(numOfTeeth, numOfLegs);
                    break;
            }

            return mammal;
        }


        /// <summary>
        /// Creates insect based on specie
        /// </summary>
        /// <param name="species">Specie of insect</param>
        /// <param name="numOfEyes">Number of eyes on insect</param>
        /// <param name="size">size in cm of insect</param>
        /// <returns></returns>
        //public static Insect CreateInsect(InsectSpecies species, int numOfEyes, double size)
        //{
        //    Insect insect = null;

        //    switch (species)
        //    {
        //        case InsectSpecies.Bee:
        //            insect = new Bee(numOfEyes, size);
        //            break;

        //        case InsectSpecies.Spider:
        //            insect = new Spider(numOfEyes, size);
        //            break;
        //    }

        //    return insect;
        //}

        /// <summary>
        /// Creates a bird based on the specie
        /// </summary>
        /// <param name="species">Specie of bird</param>
        /// <param name="wingSpan">Wing span of bird</param>
        /// <param name="flySpeed">Fly speed of bird</param>
        /// <returns>Returns a Bird </returns>
        //public static Bird CreateBird(BirdSpecies species, double wingSpan, double flySpeed)
        //{
        //    Bird bird = null;

        //    switch (species)
        //    {
        //        case BirdSpecies.Crow:
        //            bird = new Crow(wingSpan, flySpeed);
        //            break;

        //        case BirdSpecies.Hawk:
        //            bird = new Hawk(wingSpan, flySpeed);
        //            break;
        //    }

        //    return bird;
        //}

        /// <summary>
        /// Creates Marine
        /// </summary>
        /// <param name="species">Specie of marine</param>
        /// <param name="swimSpeed">Swim speed of animal</param>
        /// <param name="eatsFish">Eats fish [y/n]</param>
        /// <returns>Returns animal based on specie</returns>
        //public static Marine CreateMarine(MarineSpecies species, double swimSpeed, string eatsFish)
        //{
        //    Marine marine = null;

        //    switch (species)
        //    {
        //        case MarineSpecies.Dolphin:
        //            marine = new Dolphin(swimSpeed, eatsFish);
        //            break;

        //        case MarineSpecies.Shark:
        //            marine = new Shark(swimSpeed, eatsFish);
        //            break;
        //    }

        //    return marine;
        //}

        /// <summary>
        /// Creates a reptile based on species
        /// </summary>
        /// <param name="species">Reptile specie</param>
        /// <param name="amountOfLegs">Amount of legs</param>
        /// <param name="amountOfDaysUntilEggsHatch">Days until eggs hatch</param>
        /// <returns>Returns animal based on specie</returns>
        public static Reptile CreateReptile(ReptileSpecies species, int amountOfLegs, int amountOfDaysUntilEggsHatch)
        {
            Reptile reptile = null;

            switch (species)
            {
                case ReptileSpecies.Lizard:
                    reptile = new Lizard(amountOfLegs, amountOfDaysUntilEggsHatch);
                    break;

                case ReptileSpecies.Snake:
                    reptile = new Snake(amountOfLegs, amountOfDaysUntilEggsHatch);
                    break;
            }

            return reptile;
        }

    }
}
