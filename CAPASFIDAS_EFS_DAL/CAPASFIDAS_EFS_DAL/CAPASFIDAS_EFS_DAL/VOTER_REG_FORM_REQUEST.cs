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
    
    public partial class VOTER_REG_FORM_REQUEST
    {
        public int VTR_REG_FRM_REQ_ID { get; set; }
        public long PERSON_ID { get; set; }
        public long ADDR_ID { get; set; }
        public int COUNTY_ID { get; set; }
        public string LANGUAGE { get; set; }
        public int QUANTITY { get; set; }
        public Nullable<System.DateTime> PRINTED_DATE { get; set; }
        public string PRINTED_UID { get; set; }
        public string R_PRINTED_STATUS { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ADDRESS ADDRESS { get; set; }
        public virtual ADDRESS ADDRESS1 { get; set; }
        public virtual COUNTY COUNTY { get; set; }
        public virtual PERSON PERSON { get; set; }
    }
}
