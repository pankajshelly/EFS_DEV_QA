using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContributionLimitsModel
    {
        public String ElectionCycle { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String Party { get; set; }
        public String NonFamilyLimit { get; set; }
        public String FamilyLimit { get; set; }
    }
}
