// -----------------------------------------------------------------------
// <copyright file="EquusEntities.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This class file contains extended properties of auto generated EquusEntities context.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/22/2016
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Data
{
    #region Imports
    using DEF.Services.Data;
    using System.Linq;
    using System.Data.Entity;
    using System;
    using DEF.Data.Entities;
    #endregion

    /// <summary>
    /// Context class for EQUUS database
    /// </summary>
    public partial class EquusEntities
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public long UserName { get; set; }

      

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public override int SaveChanges()
        {
            // Track & Update audit fields
            var auditableEntities = ChangeTracker.Entries<IAuditEntity>();
            if (auditableEntities != null)
            {
                // Update audit fields for new records
                var addedEntities = auditableEntities.Where(x => x.State == EntityState.Added).ToList();
                addedEntities.ForEach(x =>
                {
                    x.Entity.createdBy = this.UserName;
                    x.Entity.createdDateTime = DateTime.Now;
                    x.Entity.updatedBy = this.UserName;
                    x.Entity.updatedDateTime = DateTime.Now;
                });

                // Update audit fields for modified records
                var modifiedEntities = auditableEntities.Where(x => x.State == EntityState.Modified).ToList();
                modifiedEntities.ForEach(x =>
                {
                    x.Entity.updatedBy = this.UserName;
                    x.Entity.updatedDateTime = DateTime.Now;
                });
            }

            return base.SaveChanges();
        }
    }
}