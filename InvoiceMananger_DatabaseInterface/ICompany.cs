using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceMananger_DatabaseInterface;

namespace InvoiceMananger_DatabaseInterface
{
    public interface ICompany
    {
        List<CompanyDto> Read(int? id = null);
        bool Create(CompanyDto company);
        bool Update(CompanyDto company);
        bool Delete(CompanyDto company);

    }
}
