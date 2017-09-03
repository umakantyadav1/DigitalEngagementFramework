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
    
    public partial class Activity
    {
        public Activity()
        {
            this.ActivityAssets = new HashSet<ActivityAsset>();
            this.ActivityBenefits = new HashSet<ActivityBenefit>();
            this.ActivityDependencies = new HashSet<ActivityDependency>();
            this.ActivityIndustries = new HashSet<ActivityIndustry>();
            this.ActivityInternalResources = new HashSet<ActivityInternalResource>();
            this.ActivityNextSteps = new HashSet<ActivityNextStep>();
            this.ActivityTips = new HashSet<ActivityTip>();
            this.ActivityVisitorResources = new HashSet<ActivityVisitorResource>();
            this.PackageActivities = new HashSet<PackageActivity>();
            this.Activity1 = new HashSet<Activity>();
        }
    
        public long ActivityID { get; set; }
        public Nullable<long> ParentActivityID { get; set; }
        public string ActivityName { get; set; }
        public string VersionName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public short MinDuration { get; set; }
        public short MaxDuration { get; set; }
        public Nullable<short> DefaultDuration { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<short> AgendaDuration { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    
        public virtual ICollection<ActivityAsset> ActivityAssets { get; set; }
        public virtual ICollection<ActivityBenefit> ActivityBenefits { get; set; }
        public virtual ICollection<ActivityDependency> ActivityDependencies { get; set; }
        public virtual ICollection<ActivityIndustry> ActivityIndustries { get; set; }
        public virtual ICollection<ActivityInternalResource> ActivityInternalResources { get; set; }
        public virtual ICollection<ActivityNextStep> ActivityNextSteps { get; set; }
        public virtual ICollection<ActivityTip> ActivityTips { get; set; }
        public virtual ICollection<ActivityVisitorResource> ActivityVisitorResources { get; set; }
        public virtual ICollection<PackageActivity> PackageActivities { get; set; }
        public virtual ICollection<Activity> Activity1 { get; set; }
        public virtual Activity Activity2 { get; set; }
    }
}