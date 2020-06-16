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

    public struct CompanyDto
    {
        public int Id;
        public string Name;
        public string CustomerNumber;
        public string Iban;
        public string IbanAscription;
        public string PhoneNumber;
        public string Website;
        public string Email;
        public Nullable<DateTime> MandateDate;
        public bool Hide;
        public int? TotalContracts;

        public string ConvertNullableDateTimeToString(Nullable<DateTime> dateTime)
        {
            return (dateTime != null) ? dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
