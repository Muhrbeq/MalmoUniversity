using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Xml.Serialization;
using Apu_Animal_Park.Animals;
using System.Runtime.InteropServices;
//using Apu_Animal_Park.Birds;
//using Apu_Animal_Park.Insects;
//using Apu_Animal_Park.Marines;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Apu_Animal_Park
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List of all animals to be filled by function
        List<string> animals = new List<string>();

        //Reference variable
        private AnimalManager animalManager = new AnimalManager();

        public MainWindow()
        {
            InitializeComponent();

            //Init GUI listboxes
            InitializeGUI();

            
        }

        private void InitializeGUI()
        {
            //Fill listboxes
            lsb_GenderType.ItemsSource = Enum.GetValues(typeof(GenderType));
            lsb_CategoryType.ItemsSource = Enum.GetValues(typeof(CategoryType));

            //Select an index because it will limit wrongful usage
            lsb_GenderType.SelectedIndex = 0;
            lsb_CategoryType.SelectedIndex = 0;

            //Fill animallist for checkbox
            FillAnimalList();

            //Headings for listbox
            txbl_AnimalListHeading.Text = "  ID\tName\t\tAge\tGender";
        }

        private void UpdateManagerListBox()
        {
            string[] listboxItems = new string[animalManager.Count()];

            for(int i = 0; i< listboxItems.Length; i++)
            {
                Animal animal = animalManager.GetAnimalAt(i);
                listboxItems[i] = animal.Id + "\t" + animal.Name + "\t" + animal.Age + "\t" + animal.Gender.ToString();
            }

            lsb_Animals.ItemsSource = listboxItems;
        }

        /// <summary>
        /// Resets GUI after add press
        /// </summary>
        private void ResetGUI()
        {
            txb_AgeOfAnimal.Text = String.Empty;
            txb_AnimalProperty_1.Text = String.Empty;
            txb_AnimalProperty_2.Text = String.Empty;
            txb_AnimalProperty_3.Text = String.Empty;
            txb_NameOfAnimal.Text = String.Empty;
        }

        /// <summary>
        /// Fills animal list with all species
        /// </summary>
        private void FillAnimalList()
        {
            foreach (var animal in Enum.GetValues(typeof(MammalSpecies)))
            {
                animals.Add(animal.ToString());
            }

            foreach (var animal in Enum.GetValues(typeof(ReptileSpecies)))
            {
                animals.Add(animal.ToString());
            }

            
            //foreach (var animal in Enum.GetValues(typeof(BirdSpecies)))
            //{
            //    animals.Add(animal.ToString());
            //}

            //foreach (var animal in Enum.GetValues(typeof(InsectSpecies)))
            //{
            //    animals.Add(animal.ToString());
            //}

            //foreach (var animal in Enum.GetValues(typeof(MarineSpecies)))
            //{
            //    animals.Add(animal.ToString());
            //}
            

        }

        /// <summary>
        /// Reads the input from GUI
        /// </summary>
        private Animal ReadInput()
        {
            Animal animal = null;

            //Set standard category
            CategoryType category = CategoryType.Mammal;

            //If the checkbox is checked you will not have category
            if(chbx_ListAllAnimals.IsChecked == false)
            {
                category = ReadCategory();
            }
            else
            {
                //Get the category from species list
                category = CategoryFromAnimal(lsb_Animal_Object.SelectedItem.ToString());
            }
            
            //Create Animal from category
            switch (category)
            {
                case CategoryType.Mammal:
                    animal = CreateMammal();
                    animal.Id = animalManager.GetNewID(CategoryType.Mammal);
                    break;
                case CategoryType.Reptile:
                    animal = CreateReptile();
                    animal.Id = animalManager.GetNewID(CategoryType.Reptile);
                    break;
                //case CategoryType.Marine:
                //    animal = CreateMarine();
                //    animal.Id = "M001";
                //    break;
                //case CategoryType.Insect:
                //    animal = CreateInsect();
                //    animal.Id = "I001";
                //    break;
                //case CategoryType.Bird:
                //    animal = CreateBird();
                //    animal.Id = "B001";
                //    break;
            }

            //Read input from GUI
            

            //Fail safe to handle all inputs
            int animalAge = 0;
            if (!int.TryParse(txb_AgeOfAnimal.Text, out animalAge))
            {
                MessageBox.Show("Please give a valid input of animal age");
            }

            animal.Name = txb_NameOfAnimal.Text;

            animal.Age = animalAge;
            animal.Gender = (GenderType)lsb_GenderType.SelectedIndex;
            animal.Category = category;

            return animal;
            
        }

        /// <summary>
        /// Create Mammal from GUI input
        /// </summary>
        /// <returns>Returns animal casted as species</returns>
        private Animal CreateMammal()
        {
            //Dynamic binding
            Animal animal = null;

            //Read input from Mammal textboxes
            int numLegs = 0;
            if (!int.TryParse(txb_AnimalProperty_1.Text, out numLegs))
            {
                MessageBox.Show("Please give a valid input number of legs");
            }

            int numTeeth = 0;
            if (!int.TryParse(txb_AnimalProperty_2.Text, out numTeeth))
            {
                MessageBox.Show("Please give a valid input number of teeth");
            }

            //Create species from selected in listbox
            MammalSpecies species = (MammalSpecies)Enum.Parse(typeof(MammalSpecies), lsb_Animal_Object.SelectedItem.ToString());

            //Create mammal
            animal = AnimalFactory.CreateMammal(species, numTeeth, numLegs);

            //Depending on species, add more info
            switch(species)
            {
                case MammalSpecies.Dog:
                    ((Dog)animal).Breed = txb_AnimalProperty_3.Text;
                    break;

                case MammalSpecies.Monkey:
                    double swing = 0;
                    if (!double.TryParse(txb_AnimalProperty_3.Text, out swing))
                    {
                        MessageBox.Show("Please give a valid input number for swing altitude");
                    }
                    ((Monkey)animal).SwingAltitude = swing;
                    break;
            }

            //Return animal as casted category
            return animal;
        }

        /// <summary>
        /// Create Reptile from GUI input
        /// </summary>
        /// <returns>Returns animal casted as species</returns>
        private Animal CreateReptile()
        {
            //Dynamic binding
            Animal animal = null;


            //Read input from Reptile textboxes
            int numLegs = 0;

            if (!int.TryParse(txb_AnimalProperty_1.Text, out numLegs))
            {
                MessageBox.Show("Please give a valid input number of legs");
            }

            int eggsHatch = 0;

            if (!int.TryParse(txb_AnimalProperty_2.Text, out eggsHatch))
            {
                MessageBox.Show("Please give a valid input number of eggs Hatching");
            }

            //Create species from selected in listbox
            ReptileSpecies species = (ReptileSpecies)Enum.Parse(typeof(ReptileSpecies), lsb_Animal_Object.SelectedItem.ToString());

            //Create reptile
            animal = AnimalFactory.CreateReptile(species, eggsHatch, numLegs);

            //Depending on species, add more info
            switch (species)
            {
                case ReptileSpecies.Lizard:
                    int lenOfTongue = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out lenOfTongue))
                    {
                        MessageBox.Show("Please give a valid input number for length of tongue");
                    }
                    ((Lizard)animal).LengthOfTongue = lenOfTongue;
                    break;

                case ReptileSpecies.Snake:
                    int venomous = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out venomous))
                    {
                        MessageBox.Show("Please give a valid input number for venomous scale");
                    }
                    ((Snake)animal).VenomousScale = venomous;
                    break;
            }
            //Return animal as casted category
            return animal;
        }

        /*
        /// <summary>
        /// Create Bird from GUI input
        /// </summary>
        /// <returns>Returns animal casted as species</returns>
        private Animal CreateBird()
        {
            //Dynamic binding 
            Animal animal = null;

            //Read input from textboxes
            double wingSpan = 0;

            if (!double.TryParse(txb_AnimalProperty_1.Text, out wingSpan))
            {
                MessageBox.Show("Please give a valid input number of wing span");
            }

            double flySpeed = 0;

            if (!double.TryParse(txb_AnimalProperty_2.Text, out flySpeed))
            {
                MessageBox.Show("Please give a valid input number of fly speed");
            }

            //Create species from selected in listbox
            BirdSpecies species = (BirdSpecies)Enum.Parse(typeof(BirdSpecies), lsb_Animal_Object.SelectedItem.ToString());

            //Create bird
            animal = AnimalFactory.CreateBird(species, wingSpan, flySpeed);

            //Depending on species, add more info
            switch (species)
            {
                case BirdSpecies.Hawk:
                    int amountOfFeathers = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out amountOfFeathers))
                    {
                        MessageBox.Show("Please give a valid input number for amount of feathers");
                    }
                    ((Hawk)animal).AmountOfFeathers = amountOfFeathers;
                    break;

                case BirdSpecies.Crow:
                    int amountOfFriends = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out amountOfFriends))
                    {
                        MessageBox.Show("Please give a valid input number for amount of friends");
                    }
                    ((Crow)animal).AmountOfFriends = amountOfFriends;
                    break;
            }
            //Return animal as casted category
            return animal;
        }
        */


        /*
        /// <summary>
        /// Create Marine from GUI input
        /// </summary>
        /// <returns>Returns animal casted as species</returns>
        private Animal CreateMarine()
        {
            //Dynamic binding
            Animal animal = null;

            //Read input from textboxes
            double swimSpeed = 0;

            //Read input from Marine textboxes
            if (!double.TryParse(txb_AnimalProperty_1.Text, out swimSpeed))
            {
                MessageBox.Show("Please give a valid input number of swim speed");
            }

            string eatsFish = txb_AnimalProperty_2.Text;

            //Create species from selected in listbox
            MarineSpecies species = (MarineSpecies)Enum.Parse(typeof(MarineSpecies), lsb_Animal_Object.SelectedItem.ToString());

            //Create marine
            animal = AnimalFactory.CreateMarine(species, swimSpeed, eatsFish);

            //Depending on species, add specific info
            switch (species)
            {
                case MarineSpecies.Shark:
                    int rowOfTeeth = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out rowOfTeeth))
                    {
                        MessageBox.Show("Please give a valid input number for amount of row of teeth");
                    }
                    ((Shark)animal).RowOfTeeth = rowOfTeeth;
                    break;

                case MarineSpecies.Dolphin:
                    int tricksLearned = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out tricksLearned))
                    {
                        MessageBox.Show("Please give a valid input number for amount of tricks learned");
                    }
                    ((Dolphin)animal).TricksLearned = tricksLearned;
                    break;
            }
            //Return animal as casted category
            return animal;
        }
        */

        /*

        /// <summary>
        /// Create Insect from GUI input
        /// </summary>
        /// <returns>Returns animal casted as species</returns>
        private Animal CreateInsect()
        {
            //Dyunamic binding
            Animal animal = null;

            //Read input
            int numOfEyes = 0;

            if (!int.TryParse(txb_AnimalProperty_1.Text, out numOfEyes))
            {
                MessageBox.Show("Please give a valid input number of eyes");
            }

            double size = 0;

            if (!double.TryParse(txb_AnimalProperty_2.Text, out size))
            {
                MessageBox.Show("Please give a valid input number of fly speed");
            }

            //Create species from selected in listbox
            InsectSpecies species = (InsectSpecies)Enum.Parse(typeof(InsectSpecies), lsb_Animal_Object.SelectedItem.ToString());

            //Create Insect
            animal = AnimalFactory.CreateInsect(species, numOfEyes, size);

            //Depending on speciec, add specific info
            switch (species)
            {
                case InsectSpecies.Bee:
                    ((Bee)animal).FavouriteFlower = txb_AnimalProperty_3.Text;
                    break;

                case InsectSpecies.Spider:
                    int numOfFangs = 0;
                    if (!int.TryParse(txb_AnimalProperty_3.Text, out numOfFangs))
                    {
                        MessageBox.Show("Please give a valid input number for amount of fangs");
                    }
                    ((Spider)animal).NumberOfFangs = numOfFangs;
                    break;
            }
            //Return animal as casted category
            return animal;
        }

        */

        /// <summary>
        /// Function that is called when checking checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbx_ListAllAnimals_Checked(object sender, RoutedEventArgs e)
        {
            lsb_Animal_Object.ItemsSource = animals;
            lsb_CategoryType.IsEnabled = false;
            
            lsb_Animal_Object.SelectedIndex = 0;
        }

        /// <summary>
        /// Function that is called when unchecking checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbx_ListAllAnimals_Unchecked(object sender, RoutedEventArgs e)
        {
            lsb_CategoryType.IsEnabled = true;
            lsb_Animal_Object.ItemsSource = null; 
        }

        /// <summary>
        /// Read input, create animal and display info. Afterwards reset GUI textboxes except info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = ReadInput();
            //txbl_AnimalInfo.Text = animal.ToString();
            animalManager.Add(animal);
            UpdateManagerListBox();
            ResetGUI();
        }


        /// <summary>
        /// Reads category from listbox item
        /// </summary>
        /// <returns>Returns category</returns>
        private CategoryType ReadCategory()
        {
            CategoryType ret;
            Enum.TryParse(lsb_CategoryType.SelectedItem.ToString(), out ret);
            return ret;
        }

        /// <summary>
        /// Displays category specification based on category
        /// </summary>
        /// <param name="ct"></param>
        private void DisplayCategorySpecification(CategoryType ct)
        {
            switch (ct)
            {
                ////Birds
                //case CategoryType.Bird:
                //    txbl_AnimalProperty_1.Text = "Wing span [cm]";
                //    txbl_AnimalProperty_2.Text = "Fly speed";
                //    txbl_Speciec_Specification.Text = "Bird Specification";
                //    break;

                ////Insects
                //case CategoryType.Insect:
                //    txbl_AnimalProperty_1.Text = "Amount of eyes";
                //    txbl_AnimalProperty_2.Text = "Size [cm]";
                //    txbl_Speciec_Specification.Text = "Insect Specification";
                //    break;

                //Mammals
                case CategoryType.Mammal:
                    txbl_AnimalProperty_1.Text = "Amount of legs";
                    txbl_AnimalProperty_2.Text = "Number of teeth";
                    txbl_Speciec_Specification.Text = "Mammal Specification";
                    break;

                //Marines
                //case CategoryType.Marine:
                //    txbl_AnimalProperty_1.Text = "Swim speed";
                //    txbl_AnimalProperty_2.Text = "Eats fish [y/n]";
                //    txbl_Speciec_Specification.Text = "Marine Specification";
                //    break;

                //Reptiles
                case CategoryType.Reptile:
                    txbl_AnimalProperty_1.Text = "Amount of legs";
                    txbl_AnimalProperty_2.Text = "Amount of days until eggs hatch";
                    txbl_Speciec_Specification.Text = "Reptile Specification";
                    break;

                default:
                    break;
            }
            //if the checkbox for all animals is not checked, fill the correct animals from category
            if (chbx_ListAllAnimals.IsChecked == false)
            {
                switch (ct)
                {
                    //Birds
                    //case CategoryType.Bird:
                    //    lsb_Animal_Object.ItemsSource = Enum.GetValues(typeof(BirdSpecies));
                    //    break;

                    ////Insects
                    //case CategoryType.Insect:
                    //    lsb_Animal_Object.ItemsSource = Enum.GetValues(typeof(InsectSpecies));
                    //    break;

                    //Mammals
                    case CategoryType.Mammal:
                        lsb_Animal_Object.ItemsSource = Enum.GetValues(typeof(MammalSpecies));
                        break;

                    //Marines
                    //case CategoryType.Marine:
                    //    lsb_Animal_Object.ItemsSource = Enum.GetValues(typeof(MarineSpecies));
                    //    break;

                    //Reptiles
                    case CategoryType.Reptile:
                        lsb_Animal_Object.ItemsSource = Enum.GetValues(typeof(ReptileSpecies));
                        break;

                    default:
                        break;
                }
                lsb_Animal_Object.SelectedIndex = 0;
            }
                
        }

        /// <summary>
        /// When selection is changed for category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsb_CategoryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayCategorySpecification((CategoryType)lsb_CategoryType.SelectedItem);
        }

        /// <summary>
        /// When selection is changed for animal object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsb_Animal_Object_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lsb_Animal_Object.SelectedIndex != -1)
            {
                DisplayAnimalSpecification(lsb_Animal_Object.SelectedItem.ToString());

                if (chbx_ListAllAnimals.IsChecked == true)
                {
                    DisplayCategorySpecification(CategoryFromAnimal(lsb_Animal_Object.SelectedItem.ToString()));

                }
            }
        }

        /// <summary>
        /// Fetches the category type from the chosen animal
        /// </summary>
        /// <param name="animal"></param>
        /// <returns>Returns the category type of animal</returns>
        private CategoryType CategoryFromAnimal(string animal)
        {
            CategoryType ct = CategoryType.Mammal;

            //foreach (var ani in Enum.GetValues(typeof(BirdSpecies)))
            //{
            //    if(ani.ToString() == animal)
            //    {
            //        return CategoryType.Bird;
            //    }
            //}

            //foreach (var ani in Enum.GetValues(typeof(InsectSpecies)))
            //{
            //    if (ani.ToString() == animal)
            //    {
            //        return CategoryType.Insect;
            //    }
            //}

            foreach (var ani in Enum.GetValues(typeof(MammalSpecies)))
            {
                if (ani.ToString() == animal)
                {
                    return CategoryType.Mammal;
                }
            }

            //foreach (var ani in Enum.GetValues(typeof(MarineSpecies)))
            //{
            //    if (ani.ToString() == animal)
            //    {
            //        return CategoryType.Marine;
            //    }
            //}

            foreach (var ani in Enum.GetValues(typeof(ReptileSpecies)))
            {
                if (ani.ToString() == animal)
                {
                    return CategoryType.Reptile;
                }
            }

            return ct;
        }

        /// <summary>
        /// Displays animal specification from animal
        /// </summary>
        /// <param name="animal"></param>
        private void DisplayAnimalSpecification(string animal)
        {
            switch (animal)
            {
                case "Dog":
                    txbl_AnimalProperty_3.Text = "Breed";
                    //txbl_AnimalProperty_4.Text = "How loud is the woof (1-10)";
                    break;

                case "Monkey":
                    txbl_AnimalProperty_3.Text = "Highest swing altitude";
                    //txbl_AnimalProperty_4.Text = "How many bananas can be eaten";
                    break;

                case "Lizard":
                    txbl_AnimalProperty_3.Text = "Length of tongue";
                    //txbl_AnimalProperty_4.Text = "Regeneration time";
                    break;

                case "Snake":
                    txbl_AnimalProperty_3.Text = "Venomous on a scale (1-10)";
                    //txbl_AnimalProperty_4.Text = "How long is the tail";
                    break;

                //case "Hawk":
                //    txbl_AnimalProperty_3.Text = "Amount of feathers";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                //case "Crow":
                //    txbl_AnimalProperty_3.Text = "Amount of friends";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                //case "Bee":
                //    txbl_AnimalProperty_3.Text = "Favorite flower";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                //case "Spider":
                //    txbl_AnimalProperty_3.Text = "Number of fangs";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                //case "Dolphin":
                //    txbl_AnimalProperty_3.Text = "Tricks learned";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                //case "Shark":
                //    txbl_AnimalProperty_3.Text = "Row of teeth";
                //    //txbl_AnimalProperty_4.Text = "How long is the tail";
                //    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Resets GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetGUI();
        }

        private void lsb_Animals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lsb_Animals.SelectedIndex;
            if (index == -1)
                return;

            Animal animal = animalManager.GetAnimalAt(index);

            FoodSchedule foodSchedule = animal.GetFoodSchedule();

            txbl_EaterTypeDef.Text = foodSchedule.EaterType.ToString();
            string[] foodList = foodSchedule.GetFoodListInfoStrings();

            //lsb_FoodSchedule.Items.Clear();
            lsb_FoodSchedule.ItemsSource = foodList;

            txbl_AnimalInfo.Text = animal.GetExtraInfo();
        }
    }
}
