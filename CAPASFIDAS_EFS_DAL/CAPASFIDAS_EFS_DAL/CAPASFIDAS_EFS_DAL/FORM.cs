//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPASFIDAS_EFS_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class FORM
    {
        public FORM()
        {
            this.FILER_HOLD_HISTORY = new HashSet<FILER_HOLD_HISTORY>();
            this.FILING_EXEMPTION = new HashSet<FILING_EXEMPTION>();
            this.SUPPORTING_DOCUMENTS = new HashSet<SUPPORTING_DOCUMENTS>();
            this.SCAN_DOCUMENT = new HashSet<SCAN_DOCUMENT>();
        }
    
        public int FORM_ID { get; set; }
        public string FORM_DESC { get; set; }
        public string FORM_CODE { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ICollection<FILER_HOLD_HISTORY> FILER_HOLD_HISTORY { get; set; }
        public virtual ICollection<FILING_EXEMPTION> FILING_EXEMPTION { get; set; }
        public virtual ICollection<SUPPORTING_DOCUMENTS> SUPPORTING_DOCUMENTS { get; set; }
        public virtual ICollection<SCAN_DOCUMENT> SCAN_DOCUMENT { get; set; }
    }
}
