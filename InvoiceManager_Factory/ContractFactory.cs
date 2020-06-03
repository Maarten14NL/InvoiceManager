using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceMananger_DatabaseInterface;
using InvoiceManager_Database;

namespace InvoiceManager_Factory
{
    public class ContractFactory
    {
        public static IContract GetContract()
        {
            return new ContractsCrud();
        }
    }
}
