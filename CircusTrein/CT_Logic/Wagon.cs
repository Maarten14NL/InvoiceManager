using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
  
    

    public class Wagon
    {
        private int space = 10;
        public int spaceLeft
        {
            get
            {
                return spaceFilled();
            }
        }
        public List<Animal> animalsInWagon = new List<Animal>();

        public Wagon()
            { 
                //spaceLeft = 10 - spaceFilled();
            }

        //public void addAnimalToWagon(Animal animal)
        //{
        //    animalsInWagon.Add(animal);
        //}

        private int spaceFilled()
        {
            int spaceUsed = 0;
            if (animalsInWagon != null)
            {
                foreach (Animal animal in animalsInWagon)
                {
                    spaceUsed += animal.AnimalSizeNumber;
                }
            }

            return 10 - spaceUsed;
        }

        public override string ToString()
        {
            //return animalsInWagon.ToString() + ", ";
            return string.Join(",", animalsInWagon);
        }

    }

    //private int wagonSpace = 10;
}
