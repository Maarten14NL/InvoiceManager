using InvoiceMananger_DatabaseInterface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic.Entities
{
    public class ContractEntity
    {
        public int Id;
        public string Name;
        public string Description;
        public double Price;
        public bool Hide;

        [JsonConstructor]
        public ContractEntity(int Id, string Name, string Description, double Price, bool Hide)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Hide = Hide;
        }

        public ContractEntity(ContractDto contract)
        {
            this.Id = contract.Id;
            this.Name = contract.Name;
            this.Description = contract.Description;
            this.Price = contract.Price;
            this.Hide = contract.Hide;
        }

        public bool Valid()
        {
            if (
                Name == "" ||
                Description == "" ||
                Price == 0
                )
            {
                return false;
            }
            return true;
        }
    }
}
