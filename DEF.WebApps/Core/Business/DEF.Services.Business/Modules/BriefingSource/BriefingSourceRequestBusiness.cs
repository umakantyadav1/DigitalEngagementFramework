// ------------------------------------------------------------------------------
// <copyright file="BriefingSourceRequestBusiness.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// <summary>This is the Briefing Source Request Business class.</summary>
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 31/08/2017, 12:35 PM IST
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
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.Common.Repository.Modules.Base;
    using DEF.Services.Logging;
    using DEF.Services.Repository.Interfaces.BriefingSources;
    using DEF.Services.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    /// <summary>
    /// BriefingSourceRequestBusiness Class
    /// </summary>
    public class BriefingSourceRequestBusiness : BusinessBase, IBriefingSourceRequestBusiness
    {
        #region Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="BriefingSourceRequestBusiness"/> class.
        /// </summary>
        /// <param name="briefingSourceRequestRepository">The briefing source request repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public BriefingSourceRequestBusiness(IBriefingSourceRequestRepository briefingSourceRequestRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, briefingSourceRequestRepository)
        {

            this.BriefingSourceRequestRepository = briefingSourceRequestRepository;
            this.UnitOfWork = unitOfWork;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the briefing source request repository.
        /// </summary>
        /// <value>
        /// The briefing source request repository.
        /// </value>
        private IBriefingSourceRequestRepository BriefingSourceRequestRepository { get; set; }

        /// <summary>
        /// Gets or sets the unit of work object.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        private IUnitOfWork UnitOfWork { get; set; }

        /////// <summary>
        /////// Gets mapper for show details
        /////// </summary>
        /////// <value>
        /////// The IMapper.
        /////// </value>
        ////private IMapper AutoMapperToDto
        ////{
        ////    get
        ////    {
        ////        var config = new MapperConfiguration(x =>
        ////        {
        ////            x.CreateMap<PayInvoiceShoppingCartViewModel, PayInvoiceAddToCartDto>();
        ////        });

        ////        return config.CreateMapper();
        ////    }
        ////}
        #endregion

        #region public

        /// <summary>
        /// Gets the briefing request.
        /// </summary>
        /// <returns>List of briefing request</returns>
        public List<BriefingRequestViewModel> GetBriefingRequest()
        {
            try
            {
                var result = this.BriefingSourceRequestRepository.GetBriefingRequestList()
                    .Select(m => new BriefingRequestViewModel
                    {
                        RequestID = m.RequestID,
                        BriefingSourceRequestID = m.BriefingSourceRequestID,
                        Requester = m.Requester,
                        DateCreated = m.DateCreated
                    });
                return result.ToList();
            }
            catch (Exception ex)
            {
                LogManager.ErrorLog.Error(ex.Message, ex.InnerException);
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region private

        #endregion
    }
}
