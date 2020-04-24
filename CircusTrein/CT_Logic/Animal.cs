using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
    public enum AnimalSize
    {
        Small = 1,
        Medium = 3,
        Large = 5
    }

    public enum AnimalType
    {
        Carnivore,
        Herbivore
    }

    public class Animal
    {
        public Animal(AnimalSize size, AnimalType type)
        {
            AnimalSize = size;
            AnimalSizeNumber = (int)size;
            AnimalType = type;
        }

        public AnimalSize AnimalSize { get; private set; }
        public int AnimalSizeNumber { get; private set; }

        public AnimalType AnimalType { get; private set; }

        public override string ToString()
        {
            return AnimalType.ToString() + " - " + AnimalSize.ToString();
        }

    }
}
