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
    
    public partial class VW_Reviewer
    {
        public int REVIEWER_ID { get; set; }
        public int EMP_ID { get; set; }
        public string EMP_USERID { get; set; }
        public string EMP_FIRST_NAME { get; set; }
        public string EMP_MIDDLE_NAME { get; set; }
        public string EMP_LAST_NAME { get; set; }
        public int UNIT_ID { get; set; }
        public int ROLE_ID { get; set; }
        public string ROLE_DESCRIPTION { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    }
}
