// -----------------------------------------------------------------------
// <copyright file="IBriefingSourceRequestBusiness.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// <summary>This is the BriefingSourceRequestBusiness Interface.</summary>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This interface file contains methods of  business for briefing  source.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/31/2017, 01:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Business.Interfaces.BriefingSource
{
    #region "Imports"
    using DEF.Services.ViewModels;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Interface for Briefing Source Reques Business
    /// </summary>
    public interface IBriefingSourceRequestBusiness
    {
        /// <summary>
        /// Gets the briefing request.
        /// </summary>
        /// <returns></returns>
        List<BriefingRequestViewModel> GetBriefingRequest();
    }
}
