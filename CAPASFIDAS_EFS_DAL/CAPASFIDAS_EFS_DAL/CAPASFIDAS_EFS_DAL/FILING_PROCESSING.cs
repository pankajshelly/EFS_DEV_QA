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
    
    public partial class FILING_PROCESSING
    {
        public long FILING_PROCCESING_ID { get; set; }
        public Nullable<long> FILER_ID { get; set; }
        public string FREPORT_ID { get; set; }
        public string TRANSACTION_CODE { get; set; }
        public string E_YEAR { get; set; }
        public Nullable<System.DateTime> DATE1_10 { get; set; }
        public Nullable<System.DateTime> DATE2_12 { get; set; }
        public string CONTRIB_CODE_20 { get; set; }
        public string CONTRIB_TYPE_CODE_25 { get; set; }
        public string CORP_30 { get; set; }
        public string FIRST_NAME_40 { get; set; }
        public string MID_INIT_42 { get; set; }
        public string LAST_NAME_44 { get; set; }
        public string ADDR_1_50 { get; set; }
        public string CITY_52 { get; set; }
        public string STATE_54 { get; set; }
        public string ZIP_56 { get; set; }
        public string CHECK_NO_60 { get; set; }
        public Nullable<System.DateTime> CHECK_DATE_62 { get; set; }
        public Nullable<int> AMOUNT_70 { get; set; }
        public Nullable<int> AMOUNT2_72 { get; set; }
        public string DESCRIPTION_80 { get; set; }
        public string OTHER_RECPT_CODE_90 { get; set; }
        public string PURPOSE_CODE1_100 { get; set; }
        public string PURPOSE_CODE2_102 { get; set; }
        public string EXPLANATION_110 { get; set; }
        public string XFER_TYPE_120 { get; set; }
        public string CHKBOX_130 { get; set; }
        public string CREREC_UID { get; set; }
        public Nullable<System.DateTime> CREREC_DATE { get; set; }
        public string FILER_TYPE { get; set; }
        public string CONTRIBUTION_RECEIVER { get; set; }
        public string COUNTY { get; set; }
        public Nullable<int> T3_TRID { get; set; }
        public string AMEND_KEY { get; set; }
        public string LOAD_DATE { get; set; }
        public string LOAD_ID { get; set; }
        public Nullable<System.DateTime> REAL_LOAD_DATE { get; set; }
        public string VENDOR_SOURCE { get; set; }
    }
}
