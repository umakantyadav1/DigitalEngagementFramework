// -----------------------------------------------------------------------
// <copyright file="IAuditEntity.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This interface file contains the audit properties.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 03/30/2017
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Data.Entities
{
    #region Imports
    using System;
    #endregion

    /// <summary>
    /// Auditable entity interface
    /// </summary>
    public interface IAuditEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        long createdBy { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        DateTime createdDateTime { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        long updatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date time.
        /// </summary>
        /// <value>
        /// The updated date time.
        /// </value>
        DateTime updatedDateTime { get; set; }
    }
}
