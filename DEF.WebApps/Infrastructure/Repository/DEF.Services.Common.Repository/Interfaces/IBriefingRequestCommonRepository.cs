// -----------------------------------------------------------------------
// <copyright file="IBriefingRequestCommonRepository.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Interfaces
{
    #region "Imports"
    using DEF.Services.Common.Repository.Interfaces.Base;
    using DEF.Services.Data;
    using DEF.Services.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public interface IBriefingRequestCommonRepository : IRepositoryBase<EquusEntities, BriefingRequest>
    {
        /// <summary>
        /// Finds the briefing requests.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Briefing Requests</returns>
        IQueryable<BriefingRequest> FindBriefingRequests(BriefingRequestViewModel item);
    }
}
