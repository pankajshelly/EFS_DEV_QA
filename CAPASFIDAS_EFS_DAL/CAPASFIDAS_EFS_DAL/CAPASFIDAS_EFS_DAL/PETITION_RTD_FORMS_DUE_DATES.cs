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
    
    public partial class PETITION_RTD_FORMS_DUE_DATES
    {
        public int DUE_DATE_ID { get; set; }
        public System.DateTime DUE_DATE { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public long ELECTION_CAND_MAPPING_ID { get; set; }
    
        public virtual ELECTION_CAND_MAPPING ELECTION_CAND_MAPPING { get; set; }
    }
}
