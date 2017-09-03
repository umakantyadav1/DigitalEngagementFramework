// -----------------------------------------------------------------------
// <copyright file="AqhaConstants.cs" company="ntt India">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description: 
// Changed By : 
// ----------------------------------------------------------------------------
namespace DEF.Services.Utilities
{
    #region "Imports"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Constants for DEF application
    /// </summary>
    public static class DEFConstants
    {
        #region Log Constants

        /// <summary>
        /// Method entry without any parameters
        /// </summary>
        public const string MethodEntryWithoutParameters = "Method entry without any parameters";

        /// <summary>
        /// Method entry with parameters
        /// </summary>
        public const string MethodEntryWithParameters = "Method entry with parameters: {0}";

        /// <summary>
        /// The log method entry with parameters
        /// </summary>
        public const string LogMethodEntryWithParameters = "Entered the method: {0} with parameters ";

        /// <summary>
        /// Method entry
        /// </summary>
        public const string MethodEntry = "Entered the method: {0}";

        /// <summary>
        /// Method entry
        /// </summary>
        public const string RegistrationKey = "Registration Key is Required";

        /// <summary>
        /// Method Exit
        /// </summary>
        public const string MethodExit = "Method Exit";

        #endregion
    }
}
