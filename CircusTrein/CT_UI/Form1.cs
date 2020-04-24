using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CT_Logic;

namespace CT_UI
{
    public partial class Form1 : Form
    {
        AnimalContainer animalContainer = new AnimalContainer();

        public Form1()
        {
            InitializeComponent();
            animalContainer.generateAnimals();
            lbxAnimals.DataSource = animalContainer.animals;

        }


        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            animalContainer.AddAnimal(cbxAnimalSize.SelectedItem.ToString(), cbxAnimalType.SelectedItem.ToString());
            lbxAnimals.DataSource = animalContainer.animals;
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            List<Animal> animalsToBeDestribted = new List<Animal>();
            animalsToBeDestribted = animalContainer.animals;

            Distributor distributor = new Distributor();
            Train t = distributor.DistributeAnimals(animalsToBeDestribted);
            lbxTrain.DataSource = t.Wagons;
            lblTrainLength.Text = Convert.ToString(t.Wagons.Count);
        }
    }
}
