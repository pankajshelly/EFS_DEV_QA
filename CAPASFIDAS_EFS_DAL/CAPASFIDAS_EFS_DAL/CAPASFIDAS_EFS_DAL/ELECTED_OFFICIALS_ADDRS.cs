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
    
    public partial class ELECTED_OFFICIALS_ADDRS
    {
        public int ELECT_OFFCL_ADDR_ID { get; set; }
        public Nullable<int> OFF_DIST_MAP_ID { get; set; }
        public Nullable<long> ADDR_ID { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ADDRESS ADDRESS { get; set; }
        public virtual OFFICE_DISTRICT_MAPPING OFFICE_DISTRICT_MAPPING { get; set; }
    }
}
