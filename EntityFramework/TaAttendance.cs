//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaAttendance
    {
        public int CoId { get; set; }
        public string CoUserID { get; set; }
        public string CoAttendanceType { get; set; }
        public Nullable<System.DateTime> CoCreated { get; set; }
        public Nullable<System.DateTime> CoUpdated { get; set; }
        public Nullable<System.TimeSpan> CoStartTime { get; set; }
        public Nullable<System.TimeSpan> CoEndTime { get; set; }
    }
}
