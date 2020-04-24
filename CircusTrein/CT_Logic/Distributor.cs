using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
    public class Distributor
    {

        public Distributor()
        {

        }

        public Train DistributeAnimals(List<Animal> animalsToBeDistributed)
        {
            Train train = new Train();


            List<Animal> carnivores = new List<Animal>(animalsToBeDistributed.FindAll(isCarnivore));
            List<Animal> herbivores = new List<Animal>(animalsToBeDistributed.FindAll(isHerbivore));

            carnivores.Sort((x, y) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));
            herbivores.Sort((x, y) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));


            sortCarnivores(carnivores, herbivores, train);
            sortHerbivores(herbivores, train);

            return train;
        }

        private void sortCarnivores(List<Animal> carnivores, List<Animal> herbivores, Train train)
        {
            foreach (Animal carnivore in carnivores)
            {
                Wagon wagon = new Wagon();
                wagon.animalsInWagon.Add(carnivore);

                if (carnivore.AnimalSizeNumber != 5)
                {
                    List<Animal> availableHerbivores = new List<Animal>(herbivores.Where(x => x.AnimalSizeNumber > carnivore.AnimalSizeNumber).ToList());

                    addHerbivoresToWagon(wagon, availableHerbivores);
                }

                train.Wagons.Add(wagon);
            }
        }

        private void sortHerbivores(List<Animal> herbivores, Train train)
        {
            while(herbivores.Count > 0)
            {
                Wagon wagon = new Wagon();

                while (wagon.spaceLeft != 0 && herbivores.Count > 0)
                {
                    List<Animal> removeAnimal = new List<Animal>();
                    foreach (Animal herbivore in herbivores)
                    {
                        int preCalculate = wagon.spaceLeft - herbivore.AnimalSizeNumber;
                        if (preCalculate >= 0)
                        {
                            removeAnimal.Add(herbivore);
                            wagon.animalsInWagon.Add(herbivore);
                        }
                    }

                    foreach (Animal remove in removeAnimal)
                    {
                        herbivores.Remove(remove);
                    }
                }

                train.Wagons.Add(wagon);
            }
        }

        private void addHerbivoresToWagon(Wagon wagon, List<Animal> availableHerbivores )
        {
            availableHerbivores.Sort((y, x) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));
            while (wagon.spaceLeft != 0 && availableHerbivores.Count > 0)
            {
                List<Animal> removeAnimal = new List<Animal>();
                foreach (Animal herbivore in availableHerbivores)
                {
                    int preCalculate = wagon.spaceLeft - herbivore.AnimalSizeNumber;
                    if (preCalculate >= 0)
                    {
                        wagon.animalsInWagon.Add(herbivore);
                        //herbivores.Remove(herbivore);
                    }
                    removeAnimal.Add(herbivore);
                }

                foreach (Animal remove in removeAnimal)
                {
                    availableHerbivores.Remove(remove);
                }
            }
        }

        private static bool isCarnivore(Animal animal)
        {
            if(animal.AnimalType.ToString() == "Carnivore")
            {
                return true;
            }
            return false;
        }

        private static bool isHerbivore(Animal animal)
        {
            if (animal.AnimalType.ToString() == "Herbivore")
            {
                return true;
            }
            return false;
        }
    }
}
