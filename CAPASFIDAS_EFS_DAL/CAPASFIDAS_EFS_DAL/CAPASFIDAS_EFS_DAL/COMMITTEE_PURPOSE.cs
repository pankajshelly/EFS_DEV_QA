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
    
    public partial class COMMITTEE_PURPOSE
    {
        public int COMM_PURPOSE_ID { get; set; }
        public Nullable<long> FILER_ID { get; set; }
        public Nullable<int> BALLOT_PROP_ID { get; set; }
        public Nullable<int> COMM_PURPOSE_TYPE_ID { get; set; }
        public string R_RECORD_CREATED { get; set; }
        public string R_ACTIVE { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual BALLOT_PROPOSALS BALLOT_PROPOSALS { get; set; }
        public virtual COMM_PURPOSE_TYPE COMM_PURPOSE_TYPE { get; set; }
        public virtual REQUIRED_FILER REQUIRED_FILER { get; set; }
    }
}
