// ---------------------------------------------------------------------------
// <copyright file="BriefingSourceRequestRuleManager.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------
// File Description:
// =================             
// This interface file contains rules for Briefing Source Request.
// ----------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/29/2017, 17:00 IST
// ----------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ----------------------------------------------------------------------------
namespace DEF.Services.Rules.Modules
{
    #region "Imports"
    using DEF.Services.Common.Repository.Interfaces;
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.DataObjects.Common.Base;
    using DEF.Services.Rules.Interfaces;
    using DEF.Services.Rules.Modules.Base;
    using DEF.Services.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class BriefingSourceRequestRuleManager : RulesBase, IBriefingSourceRequestRuleManager
    {
        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRuleManager" /> class.
        /// </summary>
        /// <param name="readRepository">Maintain User read repository</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public BriefingSourceRequestRuleManager(IBriefingRequestCommonRepository readRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, readRepository)
        {
            this.ReadRepository = readRepository;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets Read Repository
        /// </summary>
        private IBriefingRequestCommonRepository ReadRepository { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Checks the new request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="briefingRequest">The briefing request.</param>
        /// <returns>Rule Response Message</returns>
        public RuleResponse CheckNewRequest(decimal requestId, BriefingRequestViewModel briefingRequest)
        {
            bool duplicateDefaultAddress = false;
            RuleResponse response = new RuleResponse() { Result = true };
            // Process for assign error error
            if (duplicateDefaultAddress)
            {
                ///// use  common repository class BriefingRequestCommonRepository to  get data
                //    response.Result = false;
                //    response.RuleErrors.ValidationHeaderMessage = "Duplicate Default Customer Address";
                //    response.RuleErrors.TryAdd("CustomerAddress", new List<string> { "Customer default address had been modified by other users and only one address can be default, please refresh and try again" });
            }

            return response;
        }
        #endregion
    }
}
