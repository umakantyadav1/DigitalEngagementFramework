// -----------------------------------------------------------------------
// <copyright file="Audit.cs" company="NTT DATA">
//  Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of Audit.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------

namespace DEF.Services.DataObjects.Common.Base
{
    #region References
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// This class contains definitions for Auditing fields.
    /// </summary>
    public abstract class Audit
    {

        /// <summary>
        /// Gets or sets the updated date time.
        /// </summary>
        /// <value>
        /// The updated date time.
        /// </value>
        public virtual DateTime UpdatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public virtual long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the Created date time.
        /// </summary>
        /// <value>
        /// The updated date time.
        /// </value>
        public virtual DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Created by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public virtual long CreatedBy { get; set; }
    }
}
