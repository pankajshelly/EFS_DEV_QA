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
    
    public partial class POLITICAL_CALENDAR_DATE_HIST
    {
        public int POL_CAL_DATE_HIST_ID { get; set; }
        public int POL_CAL_DATE_ID { get; set; }
        public Nullable<System.DateTime> POL_CAL_PREV_DATE { get; set; }
        public Nullable<int> POL_CAL_PREV_SIG_REQS { get; set; }
        public Nullable<System.TimeSpan> POL_CAL_PREV_ELEC_HRS { get; set; }
        public string R_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    }
}
