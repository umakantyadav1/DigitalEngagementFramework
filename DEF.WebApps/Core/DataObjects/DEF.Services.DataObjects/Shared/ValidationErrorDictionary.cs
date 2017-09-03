// -----------------------------------------------------------------------------
// <copyright file="ValidationErrorDictionary.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================             
// This class file is common dictionary to send the errors to client.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/27/2017, 5:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.DataObjects.Shared
{
    #region "Imports"
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Validation error dictionary to send the errors to client.
    /// </summary>
    public class ValidationErrorDictionary : ConcurrentDictionary<string, ICollection<string>>
    {
        /// <summary>
        /// Gets or sets Validation Header Message
        /// </summary>
        public string ValidationHeaderMessage { get; set; }
    }
}
