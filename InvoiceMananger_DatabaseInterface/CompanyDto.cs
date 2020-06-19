using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMananger_DatabaseInterface
{
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
            return dateTime?.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
