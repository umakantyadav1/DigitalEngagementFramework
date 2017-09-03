using DEF.Services.Business.Interfaces.BriefingSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEF.WebApp.Controllers
{
    public class HomeController : Controller
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
        public HomeController(IBriefingSourceRequestBusiness briefingSourceRequestBusiness)
        {
            if (briefingSourceRequestBusiness != null)
            {
                this.BriefingSourceRequestBusiness = briefingSourceRequestBusiness;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}