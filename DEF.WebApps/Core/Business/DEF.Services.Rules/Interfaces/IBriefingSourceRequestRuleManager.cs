// ---------------------------------------------------------------------------
// <copyright file="IBriefingSourceRequestRuleManager.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------
// File Description:
// =================             
// This interface file contains rules for Briefing Source Request.
// ----------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 03/09/2017, 15:00 IST
// ----------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ----------------------------------------------------------------------------
namespace DEF.Services.Rules.Interfaces
{
    #region "Imports"
    using DEF.Services.DataObjects.Common.Base;
    using DEF.Services.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public interface IBriefingSourceRequestRuleManager
    {
        /// <summary>
        /// Checks the new request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="briefingRequest">The briefing request.</param>
        /// <returns>Rule Response Message</returns>
        RuleResponse CheckNewRequest(decimal requestId, BriefingRequestViewModel briefingRequest);
    }
}
