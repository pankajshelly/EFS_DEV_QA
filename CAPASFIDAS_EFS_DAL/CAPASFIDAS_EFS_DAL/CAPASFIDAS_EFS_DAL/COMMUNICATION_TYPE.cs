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
    
    public partial class COMMUNICATION_TYPE
    {
        public COMMUNICATION_TYPE()
        {
            this.IE_COMMUNICATION_FILE = new HashSet<IE_COMMUNICATION_FILE>();
            this.SUPPORTING_DOCUMENTS = new HashSet<SUPPORTING_DOCUMENTS>();
        }
    
        public int COMM_TYPE_ID { get; set; }
        public string COMM_DESC { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ICollection<IE_COMMUNICATION_FILE> IE_COMMUNICATION_FILE { get; set; }
        public virtual ICollection<SUPPORTING_DOCUMENTS> SUPPORTING_DOCUMENTS { get; set; }
    }
}
