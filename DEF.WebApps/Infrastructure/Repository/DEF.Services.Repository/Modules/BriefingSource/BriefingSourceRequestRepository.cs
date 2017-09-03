// ------------------------------------------------------------------------------
// <copyright file="BriefingSourceRequestRepository.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is the BriefingSourceRequestRepository interface.</summary>
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/30/2017, 12:45 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ------------------------------------------------------------------------------
namespace DEF.Services.Repository.Modules.BriefingSource
{
     #region Imports
    using DEF.Services.Common.Repository.Modules.Base;
    using DEF.Services.Data;
    using DEF.Services.Repository.Interfaces.BriefingSources;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    #endregion

    /// <summary>
    /// This class is used to get the Briefing Source Request
    /// </summary>
    public class BriefingSourceRequestRepository : RepositoryBase<BriefingRequest>, IBriefingSourceRequestRepository
    {
        #region Public methods
        public IQueryable<BriefingRequest> GetBriefingRequestList()
        {
            return context.BriefingRequests;
        }
        #endregion      
    }
}
