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
    
    public partial class PackageIndustry
    {
        public long PackageIndustriesID { get; set; }
        public long PackageID { get; set; }
        public short IndustryID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    
        public virtual Industry Industry { get; set; }
        public virtual Package Package { get; set; }
    }
}
