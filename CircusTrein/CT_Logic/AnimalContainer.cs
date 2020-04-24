using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
    public class AnimalContainer
    {
        public List<Animal> animals = new List<Animal>();
        public List<Animal> AddAnimal(string size, string type)
        {
            AnimalSize asize = (AnimalSize)Enum.Parse(typeof(AnimalSize), size);
            AnimalType atype = (AnimalType)Enum.Parse(typeof(AnimalType), type);

            animals.Add(new Animal(asize, atype));

            return animals;
        }

        public void generateAnimals(int amount = 100)
        {
            var AnimalSizeList = Enum.GetValues(typeof(AnimalSize)).Cast<AnimalSize>().ToList();
            var AnimalTypeList = Enum.GetValues(typeof(AnimalType)).Cast<AnimalType>().ToList();

            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                int sizeIndex = rand.Next(AnimalSizeList.Count);
                int typeIndex = rand.Next(AnimalTypeList.Count);

                string size = AnimalSizeList[sizeIndex].ToString();
                string type = AnimalTypeList[typeIndex].ToString();

                AddAnimal(size, type);
            }
        }
    }
}
