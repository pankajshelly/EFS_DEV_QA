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
    
    public partial class CORRESPONDENCE
    {
        public long CORES_ID { get; set; }
        public Nullable<long> PERSON_ID { get; set; }
        public Nullable<long> ELEC_CAND_ID { get; set; }
        public Nullable<long> COMM_ID { get; set; }
        public Nullable<long> TREAS_ID { get; set; }
        public Nullable<int> CORES_DOC_ID { get; set; }
        public Nullable<long> SCAN_DOC_ID { get; set; }
        public int CORES_TYPE_ID { get; set; }
        public Nullable<int> MESSAGE_CTR_ID { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public Nullable<int> ELE_CAND_CONT_MAP_ID { get; set; }
        public Nullable<long> PERSON_CONT_MAP_ID { get; set; }
        public Nullable<long> FILER_ID { get; set; }
    
        public virtual COMMITTEE COMMITTEE { get; set; }
        public virtual CORRESPONDENCE_DOCUMENTS CORRESPONDENCE_DOCUMENTS { get; set; }
        public virtual REQUIRED_FILER REQUIRED_FILER { get; set; }
        public virtual MESSAGE_CENTER MESSAGE_CENTER { get; set; }
        public virtual PERSON PERSON { get; set; }
        public virtual SCAN_DOCUMENT SCAN_DOCUMENT { get; set; }
        public virtual TREASURER TREASURER { get; set; }
    }
}
