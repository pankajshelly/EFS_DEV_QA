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
    
    public partial class RESIGNATION_TERMINATION_TYPE
    {
        public RESIGNATION_TERMINATION_TYPE()
        {
            this.FILINGS = new HashSet<FILING>();
        }
    
        public int RESIG_TERM_TYPE_ID { get; set; }
        public string RESIG_TERM_TYPE_DESC { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ICollection<FILING> FILINGS { get; set; }
    }
}
