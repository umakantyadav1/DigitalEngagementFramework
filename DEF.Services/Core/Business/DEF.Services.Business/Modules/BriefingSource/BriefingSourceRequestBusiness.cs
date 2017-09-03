// ------------------------------------------------------------------------------
// <copyright file="ExpireMembershipsBusiness.cs" company="Dell India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is the Expire Memberships Business class.</summary>
// ------------------------------------------------------------------------------
// Author: Dell India
// Date Created: 03/04/2017, 12:35 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// ------------------------------------------------------------------------------
namespace DEF.Services.Business.Modules.BriefingSource
{
    #region
    using DEF.Services.Business.Interfaces.BriefingSource;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    /// <summary>
    /// ExpireMembershipsBusiness Class
    /// </summary>
    public class BriefingSourceRequestBusiness : BusinessBase, IBriefingSourceRequestBusiness
    {
        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpireMembershipsBusiness" /> class.
        /// </summary>
        /// <param name="expireMembershipsRepository">Expire Membership Repository.</param>
        /// <param name="maintainMembershipCommonRepository">Repository instance of the Membership common repository.</param>
        /// <param name="breederProgramCommonRepository">breeder Program Common repository.</param>
        /// <param name="hbrEnrollmentCommonRepository">Horse breed Race Enrollment Common Repository.</param>
        /// <param name="unitOfWork">Unit of work.</param>
        public BriefingSourceRequestBusiness(IExpireMembershipsRepository expireMembershipsRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, maintainMembershipCommonRepository, expireMembershipsRepository, breederProgramCommonRepository, hbrEnrollmentCommonRepository)
        {
            if (expireMembershipsRepository == null)
            {
                throw new ArgumentNullException(Messages.BatchErrors.ExpireMembershipsRepostioryNullErrorMessage);
            }

            if (maintainMembershipCommonRepository == null)
            {
                throw new ArgumentNullException(Messages.BatchErrors.MembershipCommonRepositoryNullErrorMessage);
            }

            if (breederProgramCommonRepository == null)
            {
                throw new ArgumentNullException(Messages.BatchErrors.BreederProgramCommonRepositoryNullErrorMessage);
            }

            this.ExpireMembershipsRepository = expireMembershipsRepository;
            this.MaintainMembershipCommonRepository = maintainMembershipCommonRepository;
            this.BreederProgramCommonRepository = breederProgramCommonRepository;
            this.HbrEnrollmentCommonRepository = hbrEnrollmentCommonRepository;
            this.UnitOfWork = unitOfWork;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Membership Common Repository
        /// </summary>
        private IExpireMembershipsRepository ExpireMembershipsRepository { get; set; }

        /// <summary>
        /// Gets or sets the ExpireMembershipsRepository.
        /// </summary>
        /// <value>
        /// The ExpireMembership Repository.
        /// </value>
        private IMaintainMembershipCommonRepository MaintainMembershipCommonRepository { get; set; }

        /// <summary>
        /// Gets or sets the ExpireMembershipRepository.
        /// </summary>
        /// <value>
        /// The ExpireMembership Repository.
        /// </value>
        private IBreederProgramCommonRepository BreederProgramCommonRepository { get; set; }

        /// <summary>
        /// Gets or sets the ExpireMembershipsRepository.
        /// </summary>
        /// <value>
        /// The Horse breed race Enrollment Common Repository.
        /// </value>
        private IHbrEnrollmentCommonRepository HbrEnrollmentCommonRepository { get; set; }

        /// <summary>
        /// Gets or sets the unit of work object.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        private IUnitOfWork UnitOfWork { get; set; }
        #endregion

        #region public
        /// <summary>
        /// Get Expire Membership List.
        /// </summary>
        /// <returns>Return Expire Membership List.</returns>
        public List<decimal> GetExpireMembershipList()
        {
            try
            {
                List<decimal> membershipIds = new List<decimal>();
                var exipreMembershipList = this.ExpireMembershipsRepository.GetExpireMembershipsList()
                    .Select(x => new
                    {
                        membershipId = (decimal)x.id
                    }).ToList();

                exipreMembershipList.ForEach(x =>
                {
                    membershipIds.Add(x.membershipId);
                });

                return membershipIds;
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }
        }

        /// <summary>
        /// Get Expire Membership List Count.
        /// </summary>
        /// <returns>Return Expire Membership List Count.</returns>
        public int GetCountOfExpireMembership()
        {
            int countOfExpireMembership = this.ExpireMembershipsRepository.GetMembershipsToBeCancelled()
                   .Select(x => new MembershipToBeCancelledDto
                   {
                       CustomerId = x.CustomerId,
                       MembershipTypeCode = x.MembershipTypeCode
                   }).Count();

            return countOfExpireMembership;
        }

        /// <summary>
        /// Expire Membership
        /// </summary>
        /// <param name="expireList">Expire List.</param>
        /// <returns>Returns boolean.</returns>
        public bool ExpireMemberships(List<decimal> expireList)
        {
            try
            {
                LogManager.ServiceLog.Verbose(AQHAConstants.MethodEntryWithParameters, string.Format("Membership Item id='{0}'", JsonConvert.SerializeObject(expireList)));

                for (int i = 0; i < expireList.Count; i = i + AqhaEnums.MembershipRetrieveCount)
                {
                    var item = expireList.Skip(i).Take(AqhaEnums.MembershipRetrieveCount);
                    this.PrepareExpireMembershipForSave(item.ToList());
                    this.UnitOfWork.Save();
                    this.NonMembershipHBR_BRPStatusForSave(item.ToList());
                    this.UnitOfWork.Save();
                    LogManager.ServiceLog.Verbose(AQHAConstants.MethodExit);
                }

                return true;
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }
        }

        /// <summary>
        /// Expire Membership to be Cancelled
        /// </summary>
        /// <returns>return true or false.</returns>
        public bool GetCancelledMemberships()
        {
            try
            {
                LogManager.ServiceLog.Verbose(AQHAConstants.MethodEntryWithoutParameters);

                List<MembershipToBeCancelledDto> getCancelledMembershipList = new List<MembershipToBeCancelledDto>();
                var membershipsToBeCancelled = this.ExpireMembershipsRepository.GetMembershipsToBeCancelled()
                   .Select(x => new MembershipToBeCancelledDto
                   {
                       CustomerId = x.CustomerId,
                       MembershipTypeCode = x.MembershipTypeCode
                   }).ToList();
                
                for (int i = 0; i < membershipsToBeCancelled.Count; i = i + AqhaEnums.MembershipRetrieveCount)
                {
                    var item = membershipsToBeCancelled.Skip(i).Take(AqhaEnums.MembershipRetrieveCount).ToList();
                    this.PrepareMembershipCancellationForSave(item.ToList());
                    this.UnitOfWork.Save();
                }

                return true;
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }
        }
        
        #endregion

        #region private

        /// <summary>
        /// Prepare Expire Membership For Save.
        /// </summary>
        /// <param name="expiredMemberships">Expired Membership.</param>
        private void PrepareExpireMembershipForSave(List<decimal> expiredMemberships)
        {
            LogManager.ServiceLog.Verbose(AQHAConstants.MethodEntryWithParameters, string.Format("Membership Item id='{0}'", JsonConvert.SerializeObject(expiredMemberships)));
            try
            {
                expiredMemberships.ForEach(x =>
                {
                    var item = this.MaintainMembershipCommonRepository.GetMembershipById(x).FirstOrDefault();
                    item.membershipStatus_code = AqhaEnums.MembershipTypeStatusExpire;
                });
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }

            LogManager.ServiceLog.Verbose(AQHAConstants.MethodExit);
        }

        /// <summary>
        /// Check Other Active Membership.
        /// </summary>
        /// <param name="expiredMemberships">Expired Membership.</param>       
        private void NonMembershipHBR_BRPStatusForSave(List<decimal> expiredMemberships)
        {
            try
            {
                expiredMemberships.ForEach(x =>
                {
                    decimal? customerId;
                    bool blnCheck = this.ExpireMembershipsRepository.GetActiveMembershipsStatus(x, out customerId);

                    if (!blnCheck)
                    {
                        var breederTransaction = this.BreederProgramCommonRepository.GetBreederTransactionByCustomerId(customerId ?? 0).ToList();

                        foreach (var item in breederTransaction)
                        {
                            item.status_code = AqhaEnums.BreederStatusCode.NONMEM.ToString();
                        }

                        var hbrEnrollment = this.HbrEnrollmentCommonRepository.GetHBREnrollmentByCustomerId(customerId ?? 0).ToList();

                        foreach (var item in hbrEnrollment)
                        {
                            item.enrollmentStatus_code = AqhaEnums.HBRStatusNONMEMBER.ToString();
                        }
                    }
                });
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }

            LogManager.ServiceLog.Verbose(AQHAConstants.MethodExit);
                    }

        /// <summary>
        /// Prepare Expire Membership For Save.
        /// </summary>
        /// <param name="expiredMemberships">Expired Membership.</param>
        private void PrepareMembershipCancellationForSave(List<MembershipToBeCancelledDto> expiredMemberships)
        {
            LogManager.ServiceLog.Verbose(AQHAConstants.MethodEntryWithParameters, string.Format("Membership Item id='{0}'", JsonConvert.SerializeObject(expiredMemberships)));
            try
            {
                expiredMemberships.ForEach(x =>
                {
                    DateTime now180DaysOld = DateTime.Now.AddDays(AqhaEnums.MembershipCancelDays);
                    var result = this.ExpireMembershipsRepository.GetMembershipByCustomerIDMembershipType(x.CustomerId ?? 0, x.MembershipTypeCode).ToList();
                    foreach (var res in result)
                    {
                        if (res.endDate <= now180DaysOld)
                        {
                            res.membershipStatus_code = AqhaEnums.MembershipTypeStatusCancel;
                        }
                    }
                });
            }
            catch (Exception exp)
            {
                LogManager.ErrorLog.Error(exp.Message, exp.InnerException);
                throw new Exception(Messages.BatchErrors.ExpireMembershipsErrorMessage + " " + exp.Message);
            }

            LogManager.ServiceLog.Verbose(AQHAConstants.MethodExit);
        }
        #endregion
    }
}
