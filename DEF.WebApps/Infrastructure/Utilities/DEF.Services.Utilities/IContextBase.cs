// -----------------------------------------------------------------------------
// <copyright file="IContextBase.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This interface file contains base methods for repository layer.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/29/2017, 11:00 AM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Utilities
{
    #region Imports
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Base interface for repository
    /// </summary>
    /// <typeparam name="T">Type of context</typeparam>
    public interface IContextBase<T>
    {
        /// <summary>
        /// Set context for the repository
        /// </summary>
        /// <param name="context">The context</param>
        void SetContext(T context);
    }
}
