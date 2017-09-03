// ---------------------------------------------------------------------------
// <copyright file="RuleResponse.cs" company="NTT DATA>
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------
// File Description:
// =================             
// This class file contains properties of rule response
// ----------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/27/2017, 3:00 AM IST
// ----------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ----------------------------------------------------------------------------
namespace DEF.Services.DataObjects.Common.Base
{
    #region "Imports"
    using DEF.Services.DataObjects.Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class RuleResponse
    {
        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleResponse"/> class.
        /// </summary>
        public RuleResponse()
        {
            this.RuleErrors = new ValidationErrorDictionary();
            this.OverridableErrors = new List<OverridableMessage>();
            this.Warnings = new List<OverridableMessage>();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether Result is success or failure
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Gets or sets Error/Success messages
        /// </summary>
        public ValidationErrorDictionary RuleErrors { get; set; }

        /// <summary>
        /// Gets or sets warning messages
        /// </summary>
        public List<OverridableMessage> Warnings { get; set; }

        /// <summary>
        /// Gets or sets override error messages
        /// </summary>
        public List<OverridableMessage> OverridableErrors { get; set; }

        #endregion
    }
}
