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
    
    public partial class FILING_SCHEDULE_COMM_MAPPING
    {
        public int FILING_SCHED_COMM_MAP_ID { get; set; }
        public int FILING_SCHED_ID { get; set; }
        public int COMM_TYPE_ID { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual COMMITTEE_TYPE COMMITTEE_TYPE { get; set; }
        public virtual FILING_SCHEDULES FILING_SCHEDULES { get; set; }
    }
}
