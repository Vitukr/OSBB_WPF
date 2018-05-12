using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_WPF.Models
{
    public class ContributionApi
    {
        public string FlatNumber { get; set; }
        public string UserName { get; set; }
        public string Payment { get; set; }
        public DateTime PaymentDate { get; set; }
        public string MonthName { get; set; }
    }
}
