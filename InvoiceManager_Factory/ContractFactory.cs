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
        public static List<ContractDto> Read(int? id = null)
        {
            IContract dal = new ContractsCrud();
            return dal.Read(id);
        }

        public static bool Create(ContractDto contract)
        {
            IContract dal = new ContractsCrud();
            return dal.Create(contract);
        }

        public static bool Update(ContractDto contract)
        {
            IContract dal = new ContractsCrud();
            return dal.Update(contract);
        }

        public static bool Delete(ContractDto contract)
        {
            IContract dal = new ContractsCrud();
            return dal.Delete(contract);
        }
    }
}
