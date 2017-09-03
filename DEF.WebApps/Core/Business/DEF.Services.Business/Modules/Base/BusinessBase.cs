// -----------------------------------------------------------------------------
// <copyright file="BusinessBase.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// <summary>This is the BusinessBase class.</summary>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains base implementation of Business layer.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/31/2017, 01:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Modules.Base
{
    #region Imports
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.Data;
    using DEF.Services.Utilities;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Base class for Business layer
    /// </summary>
    public class BusinessBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        /// <param name="repositoriesAndCommonBusiness">List of repositories</param>
        public BusinessBase(IUnitOfWork unitOfWork, params IContextBase<EquusEntities>[] repositoriesAndCommonBusiness)
        {
            var userName = 0;
            unitOfWork.UserName = userName;
            unitOfWork.SetContextBehaviour(true);
            // Set write context behaviour for all repositories & common business
            foreach (var repoAndCommonBusiness in repositoriesAndCommonBusiness)
            {
                repoAndCommonBusiness.SetContext(unitOfWork.Context);
            }
        }
    }
}
