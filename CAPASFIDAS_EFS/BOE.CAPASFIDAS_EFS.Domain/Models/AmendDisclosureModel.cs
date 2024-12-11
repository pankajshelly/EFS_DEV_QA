using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AmendDisclosureModel
    {
        public String Cycle { get; set; }
        public String DisclosureType { get; set; }
        public String ReportingCycle { get; set; }
        public String ReportPeriod { get; set; }
        public String DateSubmitted { get; set; }
        public String Status { get; set; }
        public String OpeningBalance { get; set; }
        public String ClosingBalance { get; set; }
    }
}
