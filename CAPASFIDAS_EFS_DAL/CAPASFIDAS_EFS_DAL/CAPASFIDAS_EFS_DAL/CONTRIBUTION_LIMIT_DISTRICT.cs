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
    
    public partial class CONTRIBUTION_LIMIT_DISTRICT
    {
        public int CNTRB_LMT_DIST_ID { get; set; }
        public int ELECT_ID { get; set; }
        public int PARTY_ELECT_ID { get; set; }
        public int DIST_MAP_ID { get; set; }
        public int MASTER_TYPE_ID { get; set; }
        public int CNTRB_LMT_TOTALS { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ELECTION ELECTION { get; set; }
        public virtual MASTER_TYPE MASTER_TYPE { get; set; }
    }
}
