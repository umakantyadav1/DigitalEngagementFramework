//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEF.Services.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BriefingRequest
    {
        public long RequestID { get; set; }
        public string BriefingSourceRequestID { get; set; }
        public string Requester { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}
