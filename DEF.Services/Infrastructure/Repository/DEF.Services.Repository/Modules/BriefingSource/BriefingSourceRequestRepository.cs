// ------------------------------------------------------------------------------
// <copyright file="ExpireMembershipsRepository.cs" company="Dell India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is the ExpireMembershipsRepository interface.</summary>
// ------------------------------------------------------------------------------
// Author: Dell India
// Date Created: 03/04/2017, 12:45 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ------------------------------------------------------------------------------
namespace DEF.Services.Repository.Modules.BriefingSource
{
     #region Imports
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data.Entities;
    using Equus.DataObjects.Common.Accounting;
    using Equus.Repository.Common.Base;
    using Equus.Services.Utilities;
    using Equus.Utilities;
    using Interfaces.Accounting;
    #endregion

    /// <summary>
    /// This class is used to get the Expire Membership
    /// </summary>
    public class BriefingSourceRequestRepository : RepositoryBase<CustomerMembership>, IExpireMembershipsRepository
    {
        #region Public methods
        /// <summary>
        /// Get the ExpireSubscription 
        /// </summary>
        /// <returns> Returns Subscription list to expire. </returns>
        public IQueryable<CustomerMembership> GetExpireMembershipsList()
        {
            var expiredMemberships = this.context.CustomerMembership
                                        .Where(x => (x.endDate < DateTime.Now &&
                                                     x.membershipStatus_code == AqhaConstants.MembershipTypeStatusActive &&
                                                     !x.isDeleted)).OrderByDescending(y => y.id);
            return expiredMemberships;
        }

        /// <summary>
        /// Gets the List of Active Memberships.
        /// </summary>
        /// <param name="membership_Id">membership Id.</param>
        /// <param name="customerId">customer Id.</param>
        /// <returns>return true or false.</returns>
        public bool GetActiveMembershipsStatus(decimal membership_Id, out decimal? customerId)
        {
            var customer_id = this.context.CustomerMembership
                            .Where(x => x.id == membership_Id).Select(y => y.customer_id).FirstOrDefault();

            var query = this.context.CustomerMembership
                            .Where(x => (x.customer_id == customer_id
                            && x.membershipStatus_code == AqhaConstants.MembershipTypeStatusActive));
            customerId = customer_id ?? 0;

            return query.Any();
        }

        /// <summary>
        /// Gets the List of Expire Memberships to be cancelled.
        /// </summary>       
        /// <returns>List of Customer Memberships to be cancelled.</returns>
        public IQueryable<MembershipToBeCancelledDto> GetMembershipsToBeCancelled()
        {
            DateTime now180DaysOld = DateTime.Now.AddDays(AqhaEnums.MembershipCancelDays);

            try
            {
                var consolidatedData = this.context.CustomerMembership
                   .Where(x => x.endDate <= now180DaysOld && x.membershipStatus_code != AqhaEnums.MembershipTypeStatusCancel)
                   .GroupBy(x => new { x.customer_id, x.membershipType_code, x.membershipStatus_code })
                                       .Select(y => new
                                       {
                                           CustomerId = y.Key.customer_id,
                                           MembershipTypeCode = y.Key.membershipType_code
                                       });

                var consolidatedData2 = this.context.CustomerMembership
                   .Where(x => x.endDate > now180DaysOld && x.membershipStatus_code != AqhaEnums.MembershipTypeStatusCancel)
                                       .Select(y => new
                                       {
                                           CustomerId = y.customer_id,
                                           MembershipTypeCode = y.membershipType_code
                                       });

                var result = from a in consolidatedData
                              join b in consolidatedData2 on new { f1 = a.CustomerId, f2 = a.MembershipTypeCode } equals
                              new { f1 = b.CustomerId, f2 = b.MembershipTypeCode } into temp
                              from g in temp.DefaultIfEmpty()
                              where g.MembershipTypeCode == null
                              select new MembershipToBeCancelledDto
                              {
                                  CustomerId = a.CustomerId,
                                  MembershipTypeCode = a.MembershipTypeCode
                              };
                return result;
            }
            catch (Exception exp)
            {
                throw new Exception(Messages.BatchErrors.ExpireSubscriptionsErrorMessage + " " + exp.Message);
            }
        }

        /// <summary>
        /// Gets the membership by identifier.
        /// </summary>
        /// <param name="customerId">customer Id.</param>
        /// <param name="membershipTypeCode">Membership Type Code.</param>        
        /// <returns>
        /// Returns Membership details
        /// </returns>
        public IQueryable<CustomerMembership> GetMembershipByCustomerIDMembershipType(decimal customerId, string membershipTypeCode)
        {
            return this.context.CustomerMembership.Where(x => x.membershipType_code == membershipTypeCode
                && x.customer_id == customerId
                && x.membershipStatus_code == AqhaEnums.MembershipTypeStatusExpire);
        }
        
        #endregion      
    }
}
