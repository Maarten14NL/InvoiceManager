using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceMananger_DatabaseInterface;
using InvoiceManager_Database;

namespace InvoiceManager_Factory
{
    public static class CompanyFactory
    {
        public static List<CompanyDto> Read(int? id = null)
        {
            ICompany dal = new CompanyCrud();
            return dal.Read(id);
        }

        public static bool Create(CompanyDto company)
        {
            ICompany dal = new CompanyCrud();
            return dal.Create(company);
        }

        public static bool Update(CompanyDto company)
        {
            ICompany dal = new CompanyCrud();
            return dal.Create(company);
        }

        public static bool Delete(CompanyDto company)
        {
            ICompany dal = new CompanyCrud();
            return dal.Create(company);
        }
    }
}
