using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CT_Logic;

namespace WebCT.Models
{
    public class Animal
    {
        public AnimalSize AnimalSize { get; private set; }
        public AnimalType AnimalType { get; private set; }

        public Animal()
        {
            AnimalSize = AnimalSize.Small;
            AnimalType = AnimalType.Carnivore;
        }
    }
}