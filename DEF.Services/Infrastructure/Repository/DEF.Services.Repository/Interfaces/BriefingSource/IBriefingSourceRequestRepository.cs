// ------------------------------------------------------------------------------
// <copyright file="IAutoRenewMembershipRepository.cs" company="Dell India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is Repository for AutoRenewMembership class.</summary>
// ------------------------------------------------------------------------------
// Author: Dell India
// Date Created: 03/04/2017, 12:35 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ------------------------------------------------------------------------------

namespace DEF.Services.Repository.Interfaces.BriefingSource
{
    #region Imports
    using System.Collections.Generic;
    using System.Linq;
    using Data.Entities;
    using Equus.DataObjects.Common.Accounting;
    using Equus.DataObjects.Common.Accounting.MaintainTransaction;
    using Equus.Interfaces.Common.Base;
    #endregion
    /// <summary>
    /// This is interface for ExpireSubscriptionRepository.
    /// </summary>
    public interface IBriefingSourceRequestRepository : IRepositoryBase<Data.IEquusEntities, CustomerMembership>
    {
        /// <summary>
        /// Gets the List of Memberships.
        /// </summary>
        /// <returns>IQueryable Memberships to expire.</returns>
        IQueryable<CustomerMembership> GetExpireMembershipsList();

        /// <summary>
        /// Gets the List of Active Memberships.
        /// </summary>
        /// <param name="membership_Id">membership id.</param>
        /// <param name="customerId">customer id.</param>
        /// <returns>IQueryable Memberships.</returns>
        bool GetActiveMembershipsStatus(decimal membership_Id, out decimal? customerId);
        
        /// <summary>
        /// Gets the List of Expire Memberships to be cancelled.
        /// </summary>       
        /// <returns>List of Customer Memberships to be cancelled.</returns>
        IQueryable<MembershipToBeCancelledDto> GetMembershipsToBeCancelled();

        /// <summary>
        /// Gets the membership by identifier.
        /// </summary>
        /// <param name="customerId">customer Id.</param>
        /// <param name="MembershipTypeCode">Membership Type Code.</param>        
        /// <returns>
        /// Returns Membership details
        /// </returns>
        IQueryable<CustomerMembership> GetMembershipByCustomerIDMembershipType(decimal customerId, string MembershipTypeCode);        
    }
}
