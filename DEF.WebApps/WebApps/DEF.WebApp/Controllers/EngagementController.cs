using DEF.Services.Business.Interfaces.BriefingSource;
using DEF.Services.Logging;
using DEF.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEF.WebApp.Controllers
{
    public class EngagementController : Controller
    {
        #region Properties
        /// <summary>
        /// Gets or sets the pay invoice facade.
        /// </summary>
        /// <value>
        /// The pay invoice facade.
        /// </value>
        private IBriefingSourceRequestBusiness BriefingSourceRequestBusiness { get; set; }
        #endregion
        public EngagementController(IBriefingSourceRequestBusiness briefingSourceRequestBusiness)
        {
            if (briefingSourceRequestBusiness != null)
            {
                this.BriefingSourceRequestBusiness = briefingSourceRequestBusiness;
            }
        }
        public ActionResult Index()
        {
            var result = this.BriefingSourceRequestBusiness.GetBriefingRequest();
            return View(result);
        }
    }
}