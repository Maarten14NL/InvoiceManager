using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_Logic
{
    public class Distributor
    {
        private readonly Train _train = new Train();
        private List<Animal> _carnivores;
        private List<Animal> _herbivores;
        public Distributor()
        {

        }

        public Train DistributeAnimals(List<Animal> animalsToBeDistributed)
        {

            _carnivores = new List<Animal>(animalsToBeDistributed.FindAll(IsCarnivore));
            _herbivores = new List<Animal>(animalsToBeDistributed.FindAll(IsHerbivore));

            _carnivores.Sort((x, y) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));
            _herbivores.Sort((x, y) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));


            DevideCarnivoresInWagon();
            DevideHerbivoresInWagon();

            return _train;
        }

        private void DevideCarnivoresInWagon()
        {
            foreach (Animal carnivore in _carnivores)
            {
                Wagon wagon = new Wagon();
                wagon.animalsInWagon.Add(carnivore);

                if (carnivore.AnimalSizeNumber != 5)
                {
                    List<Animal> availableHerbivores = new List<Animal>(_herbivores.Where(x => x.AnimalSizeNumber > carnivore.AnimalSizeNumber).ToList());

                    AddHerbivoresToWagon(wagon, availableHerbivores);
                }

                _train.Wagons.Add(wagon);
            }
        }

        private void DevideHerbivoresInWagon()
        {
            while(_herbivores.Count > 0)
            {
                Wagon wagon = new Wagon();

                while (wagon.SpaceLeft != 0 && _herbivores.Count > 0)
                {
                    List<Animal> removeAnimal = new List<Animal>();
                    foreach (Animal herbivore in _herbivores)
                    {
                        int preCalculate = wagon.SpaceLeft - herbivore.AnimalSizeNumber;
                        if (preCalculate >= 0)
                        {
                            removeAnimal.Add(herbivore);
                            wagon.animalsInWagon.Add(herbivore);
                        }
                    }

                    foreach (Animal remove in removeAnimal)
                    {
                        _herbivores.Remove(remove);
                    }
                }

                _train.Wagons.Add(wagon);
            }
        }

        private void AddHerbivoresToWagon(Wagon wagon, List<Animal> availableHerbivores )
        {
            availableHerbivores.Sort((y, x) => string.Compare(x.AnimalSize.ToString(), y.AnimalSize.ToString()));
            while (wagon.SpaceLeft != 0 && availableHerbivores.Count > 0)
            {
                List<Animal> removeAnimal = new List<Animal>();
                foreach (Animal herbivore in availableHerbivores)
                {
                    int preCalculate = wagon.SpaceLeft - herbivore.AnimalSizeNumber;
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

        private static bool IsCarnivore(Animal animal)
        {
            if(animal.AnimalType.ToString() == "Carnivore")
            {
                return true;
            }
            return false;
        }

        private static bool IsHerbivore(Animal animal)
        {
            if (animal.AnimalType.ToString() == "Herbivore")
            {
                return true;
            }
            return false;
        }
    }
}
