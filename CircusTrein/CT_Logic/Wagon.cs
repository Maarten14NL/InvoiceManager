using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
  
    

    public class Wagon
    {
        private readonly int space = 10;
        public int  SpaceLeft
        {
            get
            {
                return SpaceFilled();
            }
        }
        public List<Animal> animalsInWagon = new List<Animal>();

        private int SpaceFilled()
        {
            int spaceUsed = 0;
            if (animalsInWagon != null)
            {
                foreach (Animal animal in animalsInWagon)
                {
                    spaceUsed += animal.AnimalSizeNumber;
                }
            }

            return space - spaceUsed;
        }

        public override string ToString()
        {
            //return animalsInWagon.ToString() + ", ";
            return string.Join(",", animalsInWagon);
        }

    }
}
