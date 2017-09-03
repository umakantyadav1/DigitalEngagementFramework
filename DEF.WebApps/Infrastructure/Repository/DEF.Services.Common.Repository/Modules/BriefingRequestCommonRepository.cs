// -----------------------------------------------------------------------
// <copyright file="CustomerCommonRepository.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This interface class file contains interface definitions for Briefing Read
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Modules
{
    #region "Imports"
    using DEF.Services.Common.Repository.Interfaces;
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.Common.Repository.Modules.Base;
    using DEF.Services.Data;
    using DEF.Services.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class BriefingRequestCommonRepository : RepositoryBase<BriefingRequest>, IBriefingRequestCommonRepository
    {

        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="BriefingRequestCommonRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public BriefingRequestCommonRepository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        public IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Finds the briefing requests.
        /// </summary>
        /// <param name="searchKey">The search key.</param>
        /// <returns></returns>
        public IQueryable<BriefingRequest> FindBriefingRequests(BriefingRequestViewModel searchKey)
        {
            return this.context.BriefingRequests.Where(m => m.Requester == searchKey.Requester);
        }
        #endregion
    }
}
