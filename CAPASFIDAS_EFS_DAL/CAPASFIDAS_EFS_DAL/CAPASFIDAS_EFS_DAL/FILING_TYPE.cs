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
    
    public partial class FILING_TYPE
    {
        public FILING_TYPE()
        {
            this.FILING_PERIOD = new HashSet<FILING_PERIOD>();
        }
    
        public int FILING_TYPE_ID { get; set; }
        public int ELECT_TYPE_ID { get; set; }
        public string FILING_ABBREV { get; set; }
        public string FILING_DESC { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ELECTION_TYPE ELECTION_TYPE { get; set; }
        public virtual ICollection<FILING_PERIOD> FILING_PERIOD { get; set; }
    }
}
