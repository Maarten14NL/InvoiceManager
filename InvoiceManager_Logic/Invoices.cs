using InvoiceManager_Factory;
using InvoiceMananger_DatabaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceManager_Logic.Entities;
namespace InvoiceManager_Logic
{
    public class Invoices
    {
        public void Generate(List<CompanyEntity> companies, string storagePath)
        {
            Companies c = new Companies();
            companies = c.Read(1);
            foreach (CompanyEntity company in companies)
            {
                CompanyContracts cc = new CompanyContracts();
                List<CompanyContractsEntity> companyContractsList = cc.GetByCompany(company.Id);

                GenerateInvoice generateInvoice = new GenerateInvoice(storagePath);


                List<PlaceHolder> replaceWords = new List<PlaceHolder>
                {
                    new PlaceHolder("<Today>", "18-02-2020"),
                    new PlaceHolder("<Organisation.Name>", "test"),
                    new PlaceHolder("<Organisation.Address>", "Radioweg 17"),
                    new PlaceHolder("<Organisation.Postal>", "5844 AA, Stevensbeek"),
                    new PlaceHolder("<Organisation.Phone>", "0620705928"),
                    new PlaceHolder("<Organisation.Email>", "maarten.jakobs@gmail.com"),

                    new PlaceHolder("<Company.Name>", company.Name),
                    new PlaceHolder("<Company.Address>", "Radioweg 17"),
                    new PlaceHolder("<Company.Postal>", "5844 AA, Stevensbeek"),
                    new PlaceHolder("<Company.Phone>", company.PhoneNumber),
                    new PlaceHolder("<Company.CustomerNumber>", company.CustomerNumber),
                };

                List<List<PlaceHolder>> tableFields = new List<List<PlaceHolder>>();
                foreach (CompanyContractsEntity companyContract in companyContractsList)
                {
                    double _price = companyContract.Amount * companyContract.Contract.Price;

                    List<PlaceHolder> tableField = new List<PlaceHolder>
                    {
                        new PlaceHolder("<Invoice.Name>", companyContract.Contract.Name),
                        new PlaceHolder("<Invoice.Amount>", companyContract.Amount.ToString()),
                        new PlaceHolder("<Invoice.Price>", _price.ToString()),
                    };
                    tableFields.Add(tableField);

                }
                generateInvoice.Generate(replaceWords, tableFields);
            }
        }
    }
}
