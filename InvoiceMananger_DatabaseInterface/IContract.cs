﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMananger_DatabaseInterface
{
    public interface IContract
    {
        List<ContractDto> Read(int? id = null);
        bool Create(ContractDto company);
        bool Update(ContractDto company);
        bool Delete(ContractDto company);

    }

    public struct ContractDto
    {
        public int Id;
        public string Name;
        public string Description;
        public double Price;
        public bool Hide;
    }
}