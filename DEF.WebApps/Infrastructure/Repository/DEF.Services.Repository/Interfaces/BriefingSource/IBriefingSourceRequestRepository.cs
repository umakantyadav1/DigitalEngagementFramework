// ------------------------------------------------------------------------------
// <copyright file="IBriefingSourceRequestRepository.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is Repository for IBriefingSourceRequestRepository class.</summary>
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/24/2017, 12:35 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ------------------------------------------------------------------------------

namespace DEF.Services.Repository.Interfaces.BriefingSources
{
    #region Imports
    using System.Collections.Generic;
    using System.Linq;
    using DEF.Services.Common.Repository.Interfaces.Base;
    using DEF.Services.Data;
    #endregion
    /// <summary>
    /// This is interface for Briefing Source Request Repository.
    /// </summary>
    public interface IBriefingSourceRequestRepository : IRepositoryBase<Data.EquusEntities,BriefingRequest>
    {
        /// <summary>
        /// Gets the List of BriefingRequest.
        /// </summary>
        /// <returns>IQueryable GetBriefingRequestList.</returns>
        IQueryable<BriefingRequest> GetBriefingRequestList();     
    }
}
