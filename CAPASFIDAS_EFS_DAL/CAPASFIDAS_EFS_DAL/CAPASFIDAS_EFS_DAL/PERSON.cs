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
    
    public partial class PERSON
    {
        public PERSON()
        {
            this.ADDRESSes = new HashSet<ADDRESS>();
            this.AUTHORIZED_SIGNATORY = new HashSet<AUTHORIZED_SIGNATORY>();
            this.BALLOT_CORRESPONDENCE = new HashSet<BALLOT_CORRESPONDENCE>();
            this.CANDIDATEs = new HashSet<CANDIDATE>();
            this.CANDIDATEs1 = new HashSet<CANDIDATE>();
            this.CANDIDATE_OBJECTOR = new HashSet<CANDIDATE_OBJECTOR>();
            this.COMM_OPERATIONAL_INDIVIDUAL = new HashSet<COMM_OPERATIONAL_INDIVIDUAL>();
            this.COMM_PAC_INDIVIDUAL = new HashSet<COMM_PAC_INDIVIDUAL>();
            this.COMM_PAC_SALARIED = new HashSet<COMM_PAC_SALARIED>();
            this.COMM_POINT_OF_CONTACT = new HashSet<COMM_POINT_OF_CONTACT>();
            this.COMMITTEEs = new HashSet<COMMITTEE>();
            this.COMMITTEE_HISTORY = new HashSet<COMMITTEE_HISTORY>();
            this.CONTACTs = new HashSet<CONTACT>();
            this.CORRESPONDENCEs = new HashSet<CORRESPONDENCE>();
            this.COUNTY_OFFICIALS = new HashSet<COUNTY_OFFICIALS>();
            this.EFS_VENDOR_PERSON_MAPPING = new HashSet<EFS_VENDOR_PERSON_MAPPING>();
            this.ESCROW_AUTHORIZED_USER = new HashSet<ESCROW_AUTHORIZED_USER>();
            this.PERSON_ADDR_MAPPING = new HashSet<PERSON_ADDR_MAPPING>();
            this.PERSON_CONTACT_MAPPING = new HashSet<PERSON_CONTACT_MAPPING>();
            this.PERSON_NAME_MAPPING = new HashSet<PERSON_NAME_MAPPING>();
            this.PETITIONs = new HashSet<PETITION>();
            this.TREASURERs = new HashSet<TREASURER>();
            this.TREASURER_HISTORY = new HashSet<TREASURER_HISTORY>();
            this.SUB_TREASURER = new HashSet<SUB_TREASURER>();
            this.STATE_COMMITTEE = new HashSet<STATE_COMMITTEE>();
            this.VOTER_REG_FORM_REQUEST = new HashSet<VOTER_REG_FORM_REQUEST>();
        }
    
        public long PERSON_ID { get; set; }
        public Nullable<int> TITLE_ID { get; set; }
        public string PERSON_GENDER { get; set; }
        public string PERSON_SSN { get; set; }
        public byte[] PERSON_SIGN { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ICollection<ADDRESS> ADDRESSes { get; set; }
        public virtual ICollection<AUTHORIZED_SIGNATORY> AUTHORIZED_SIGNATORY { get; set; }
        public virtual ICollection<BALLOT_CORRESPONDENCE> BALLOT_CORRESPONDENCE { get; set; }
        public virtual ICollection<CANDIDATE> CANDIDATEs { get; set; }
        public virtual ICollection<CANDIDATE> CANDIDATEs1 { get; set; }
        public virtual ICollection<CANDIDATE_OBJECTOR> CANDIDATE_OBJECTOR { get; set; }
        public virtual ICollection<COMM_OPERATIONAL_INDIVIDUAL> COMM_OPERATIONAL_INDIVIDUAL { get; set; }
        public virtual ICollection<COMM_PAC_INDIVIDUAL> COMM_PAC_INDIVIDUAL { get; set; }
        public virtual ICollection<COMM_PAC_SALARIED> COMM_PAC_SALARIED { get; set; }
        public virtual ICollection<COMM_POINT_OF_CONTACT> COMM_POINT_OF_CONTACT { get; set; }
        public virtual ICollection<COMMITTEE> COMMITTEEs { get; set; }
        public virtual ICollection<COMMITTEE_HISTORY> COMMITTEE_HISTORY { get; set; }
        public virtual ICollection<CONTACT> CONTACTs { get; set; }
        public virtual ICollection<CORRESPONDENCE> CORRESPONDENCEs { get; set; }
        public virtual ICollection<COUNTY_OFFICIALS> COUNTY_OFFICIALS { get; set; }
        public virtual ICollection<EFS_VENDOR_PERSON_MAPPING> EFS_VENDOR_PERSON_MAPPING { get; set; }
        public virtual ICollection<ESCROW_AUTHORIZED_USER> ESCROW_AUTHORIZED_USER { get; set; }
        public virtual ICollection<PERSON_ADDR_MAPPING> PERSON_ADDR_MAPPING { get; set; }
        public virtual ICollection<PERSON_CONTACT_MAPPING> PERSON_CONTACT_MAPPING { get; set; }
        public virtual ICollection<PERSON_NAME_MAPPING> PERSON_NAME_MAPPING { get; set; }
        public virtual ICollection<PETITION> PETITIONs { get; set; }
        public virtual ICollection<TREASURER> TREASURERs { get; set; }
        public virtual ICollection<TREASURER_HISTORY> TREASURER_HISTORY { get; set; }
        public virtual ICollection<SUB_TREASURER> SUB_TREASURER { get; set; }
        public virtual ICollection<STATE_COMMITTEE> STATE_COMMITTEE { get; set; }
        public virtual ICollection<VOTER_REG_FORM_REQUEST> VOTER_REG_FORM_REQUEST { get; set; }
        public virtual TITLE TITLE { get; set; }
    }
}
