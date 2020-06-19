using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Factory;
using InvoiceManager_Logic.Entities;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceManager_Logic
{
    public class Contracts
    {
        private readonly IContract _ContractDal = ContractFactory.GetContract();
        public List<ContractEntity> Read(int? id = null)
        {
            List<ContractDto> contractsList = _ContractDal.Read(id);
            List<ContractEntity> contractEntities = new List<ContractEntity>();
            foreach (var contract in contractsList)
            {
                ContractEntity contractEntity = new ContractEntity(contract);

                contractEntities.Add(contractEntity);
            }
            return contractEntities;
        }
        public bool Create(ContractEntity contract)
        {
            if (contract.Valid())
            {
                return _ContractDal.Create(SetContractDto(contract));
            }
            return false;
        }

        public bool Update(ContractEntity contract)
        {
            if (contract.Valid() && contract.Id >= 0)
            {
                return _ContractDal.Update(SetContractDto(contract));
            }
            return false;
        }

        public bool Delete(ContractEntity contract)
        {
            if (contract.Valid())
            {
                return _ContractDal.Delete(SetContractDto(contract));
            }
            return false;
        }

        public ContractDto SetContractDto(ContractEntity contract)
        {
            ContractDto contractDto = new ContractDto
            {
                Id = contract.Id,
                Name = contract.Name,
                Description = contract.Description,
                Price = contract.Price,
                Hide = contract.Hide
            };

            return contractDto;
        }

    }
}
