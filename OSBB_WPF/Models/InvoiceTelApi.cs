using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_WPF.Models
{
    public class InvoiceTelApi
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string ProviderName { get; set; }
        public string Payment { get; set; }
        public string Debt { get; set; }
        public string Overpaid { get; set; }

        public string TelNumber { get; set; }

        public string FlatNumber { get; set; }
        public string MonthName { get; set; }
    }
}
