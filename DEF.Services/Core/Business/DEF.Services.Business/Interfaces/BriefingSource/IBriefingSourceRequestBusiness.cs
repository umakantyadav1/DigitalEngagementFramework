// -----------------------------------------------------------------------
// <copyright file="IBriefingSourceRequestBusiness.cs" company="NTT DATA">
// Copyright (c) 2015. All rights reseved.
// </copyright>
// <summary>This is the BriefingSourceRequestBusiness Interface.</summary>
// -----------------------------------------------------------------------
// File Description:
// =================  
// This interface file contains methods of  business for briefing  source.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------

namespace DEF.Services.Business.Interfaces.BriefingSource
{
    #region "Imports"
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
        bool GetBriefingRequest();
    }
}
