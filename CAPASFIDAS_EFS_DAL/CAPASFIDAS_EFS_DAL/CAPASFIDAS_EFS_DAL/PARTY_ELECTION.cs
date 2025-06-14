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
    
    public partial class PARTY_ELECTION
    {
        public PARTY_ELECTION()
        {
            this.COMMITTEEs = new HashSet<COMMITTEE>();
            this.COMMITTEE_HISTORY = new HashSet<COMMITTEE_HISTORY>();
            this.ELECTION_CAND_MAPPING = new HashSet<ELECTION_CAND_MAPPING>();
            this.ELECTION_OFFICE = new HashSet<ELECTION_OFFICE>();
            this.PARTY_ELECTION_HISTORY = new HashSet<PARTY_ELECTION_HISTORY>();
            this.PETITION_HISTORY = new HashSet<PETITION_HISTORY>();
            this.PETITIONs = new HashSet<PETITION>();
            this.STATE_COMMITTEE = new HashSet<STATE_COMMITTEE>();
        }
    
        public int PARTY_ELECT_ID { get; set; }
        public int PARTY_ID { get; set; }
        public int ELECTION_YEAR_ID { get; set; }
        public byte[] PARTY_EMBLEM_IMG { get; set; }
        public Nullable<int> PARENT_PARTY_ID { get; set; }
        public string PARTY_COLOR { get; set; }
        public Nullable<int> PARTY_ORDER { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public string PARTY_SYMBOL { get; set; }
        public string PARTY_EMBLEM_DESC { get; set; }
    
        public virtual ICollection<COMMITTEE> COMMITTEEs { get; set; }
        public virtual ICollection<COMMITTEE_HISTORY> COMMITTEE_HISTORY { get; set; }
        public virtual ICollection<ELECTION_CAND_MAPPING> ELECTION_CAND_MAPPING { get; set; }
        public virtual ICollection<ELECTION_OFFICE> ELECTION_OFFICE { get; set; }
        public virtual ICollection<PARTY_ELECTION_HISTORY> PARTY_ELECTION_HISTORY { get; set; }
        public virtual ICollection<PETITION_HISTORY> PETITION_HISTORY { get; set; }
        public virtual ICollection<PETITION> PETITIONs { get; set; }
        public virtual ICollection<STATE_COMMITTEE> STATE_COMMITTEE { get; set; }
    }
}
