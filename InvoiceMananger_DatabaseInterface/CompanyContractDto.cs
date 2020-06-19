using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMananger_DatabaseInterface
{
    public struct CompanyContractsDto
    {
        public int Id;
        public CompanyDto Company;
        public ContractDto Contract;
        public int Amount;
        public Nullable<DateTime> StartDate;
        public Nullable<DateTime> EndDate;

        public string ConvertNullableDateTimeToString(Nullable<DateTime> dateTime)
        {
            return (dateTime != null) ? dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
