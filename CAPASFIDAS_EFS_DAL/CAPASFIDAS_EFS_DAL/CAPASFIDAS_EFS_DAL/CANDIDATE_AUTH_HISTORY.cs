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
    
    public partial class CANDIDATE_AUTH_HISTORY
    {
        public int CAND_COMM_AUTH_HIST_ID { get; set; }
        public int CAND_COMM_AUTH_ID { get; set; }
        public long CAND_ID { get; set; }
        public long COMM_ID { get; set; }
        public Nullable<int> AUTH_TYPE_ID { get; set; }
        public System.DateTime FILED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual AUTHORIZATION_TYPE AUTHORIZATION_TYPE { get; set; }
        public virtual CANDIDATE_COMMITTEE_AUTH CANDIDATE_COMMITTEE_AUTH { get; set; }
        public virtual COMMITTEE COMMITTEE { get; set; }
    }
}
