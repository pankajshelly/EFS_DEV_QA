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
    
    public partial class POLITICAL_CALENDAR_SUBHEADING
    {
        public POLITICAL_CALENDAR_SUBHEADING()
        {
            this.POLITICAL_CALENDAR_FORM_MAP = new HashSet<POLITICAL_CALENDAR_FORM_MAP>();
        }
    
        public int POL_CAL_SUB_HEADING_ID { get; set; }
        public int POL_CAL_HEADING_ID { get; set; }
        public string POL_CAL_SUB_HEADING_DESC { get; set; }
        public int POL_CAL_SORT_ORDER { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        public virtual ICollection<POLITICAL_CALENDAR_FORM_MAP> POLITICAL_CALENDAR_FORM_MAP { get; set; }
        public virtual POLITICAL_CALENDAR_HEADING POLITICAL_CALENDAR_HEADING { get; set; }
    }
}
