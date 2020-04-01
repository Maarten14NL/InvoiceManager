using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic
{
    public class ContractEntity
    {
        public int Id;
        public string Name;
        public string Description;
        public double Price;
        public bool Hide;

        public ContractEntity(int Id, string Name, string Description, double Price, bool Hide)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Hide = Hide;
        }
    }
}
