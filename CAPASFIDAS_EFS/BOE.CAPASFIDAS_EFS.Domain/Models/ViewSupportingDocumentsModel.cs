using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ViewSupportingDocumentsGridModel
    {
        public String SupportDocID { get; set; }
        public String ScanDocID { get; set; }
        public String OfficeTypeID { get; set; }
        public String ElectTypeID { get; set; }
        public String PolCalDateID { get; set; }

        public String DateReceived { get; set; }
        public String DocumentType { get; set; }
        public String Amended { get; set; }
        public String ReportYear { get; set; }
        public String OfficeType { get; set; }
        public String ElectionType { get; set; }
        public String ElectionDate { get; set; }
        public String DisclosurePeriod { get; set; }
        public String R_Status { get; set; }
        public String FileType { get; set; }
        public String Size { get; set; }
        public String FilingMethod { get; set; }
    }
}
