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
    
    public partial class ELECTION_CAND_SIGNATURE
    {
        public int ELECTION_CAND_SIGN_ID { get; set; }
        public Nullable<long> PET_ID { get; set; }
        public long ELECT_CAND_ID { get; set; }
        public Nullable<int> PET_FRM_MAP_ID { get; set; }
        public Nullable<int> OBJ_SIGNATURE_NUM { get; set; }
        public Nullable<int> OBJ_SIGNATURE_FILED { get; set; }
        public Nullable<int> VALID_SIGNATURE_NUM { get; set; }
        public Nullable<int> INVALID_SIGNATURE_NUM { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ELECTION_CANDIDATE ELECTION_CANDIDATE { get; set; }
        public virtual PETITION PETITION { get; set; }
        public virtual PETITION_FORM_MAPPING PETITION_FORM_MAPPING { get; set; }
    }
}
