// -----------------------------------------------------------------------------
// <copyright file="BusinessBase.cs" company="Dell India">
// Copyright (c) 2016. All rights reserved.
// </copyright>
// <summary>This is the BusinessBase class.</summary>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains base implementation of Business layer.
// ------------------------------------------------------------------------------
// Author: Dell India
// Date Created: 02/24/2016, 01:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Business.Modules.BriefingSource
{
    #region Imports
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
        public BusinessBase(IUnitOfWork unitOfWork, params IContextBase<IEquusEntities>[] repositoriesAndCommonBusiness)
        {
            var userName = ConfigurationManager.AppSettings["AuditUserName"];
            unitOfWork.UserName = userName == null ? string.Empty : userName.ToString();

            // Set write context behaviour for all repositories & common business
            foreach (var repoAndCommonBusiness in repositoriesAndCommonBusiness)
            {
                repoAndCommonBusiness.SetContext(unitOfWork.Context);
            }
        }
    }
}
