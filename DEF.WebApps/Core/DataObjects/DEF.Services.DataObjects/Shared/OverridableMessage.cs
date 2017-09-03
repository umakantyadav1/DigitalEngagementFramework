// -----------------------------------------------------------------------------
// <copyright file="OverridableMessage.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================             
// This class file contains properties for overridable/ignorable message.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/28/2017, 8:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.DataObjects.Shared
{
    /// <summary>
    /// View model for error message
    /// </summary>
    public class OverridableMessage
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether error/warning ignored or not.
        /// </summary>
        /// <value>
        /// The error override flag.
        /// </value>
        public bool IsOverrided { get; set; }
    }
}
