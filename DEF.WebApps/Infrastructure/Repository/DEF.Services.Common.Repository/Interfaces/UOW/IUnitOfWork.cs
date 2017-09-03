// -----------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains the methods/properties of Equus unit of work.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/29/2017, 06:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Interfaces.UOW
{
    #region Imports
    using DEF.Services.Data;
    #endregion

    /// <summary>
    /// Interface for Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        long UserName { get; set; }

        /// <summary>
        /// Gets the EQUUS Context
        /// </summary>
        EquusEntities Context { get; }

        /// <summary>
        /// Gets the get parallel context.
        /// </summary>
        /// <value>
        /// The get parallel context.
        /// </value>
        EquusEntities GetParallelContext { get; }

        /// <summary>
        /// Save Changes on context
        /// </summary>
        /// <returns>Save Result</returns>
        int Save();

        /// <summary>
        /// Set context behavior read/write
        /// </summary>
        /// <param name="readOnly">True if read only, otherwise false</param>
        void SetContextBehaviour(bool readOnly);
    }
}
