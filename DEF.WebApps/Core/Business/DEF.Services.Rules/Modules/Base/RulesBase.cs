// -----------------------------------------------------------------------------
// <copyright file="RulesBase.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains base properties of rules.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 02/09/2017, 01:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Rules.Modules.Base
{
    #region Imports
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.Data;
    using DEF.Services.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Base class for Rules layer
    /// </summary>
    public class RulesBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RulesBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        /// <param name="repositories">List of repositories</param>
        public RulesBase(IUnitOfWork unitOfWork, params IContextBase<EquusEntities>[] repositories)
        {
            // Disable auto detection & save behaviour
            unitOfWork.SetContextBehaviour(true);

            // Set the read-only context to all repositories of rules manager
            foreach (var repository in repositories)
            {
                repository.SetContext(unitOfWork.Context);
            }
        }
    }
}
