using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEF.Services.ViewModels
{
    public class BriefingRequestViewModel
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public long RequestID { get; set; }

        /// <summary>
        /// Gets or sets the briefing source request identifier.
        /// </summary>
        /// <value>
        /// The briefing source request identifier.
        /// </value>
        public string BriefingSourceRequestID { get; set; }

        /// <summary>
        /// Gets or sets the requester.
        /// </summary>
        /// <value>
        /// The requester.
        /// </value>
        public string Requester { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public long ModifiedBy { get; set; }
    }
}
