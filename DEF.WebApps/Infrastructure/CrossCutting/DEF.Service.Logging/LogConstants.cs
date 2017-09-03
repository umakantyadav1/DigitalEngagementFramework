// -----------------------------------------------------------------------
// <copyright file="LogConstants.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
namespace DEF.Services.Logging
{
    #region "Imports"
    using System;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    #endregion

    /// <summary>
    /// Log Constants Class
    /// </summary>
    public static class LogConstants
    {
        /// <summary>
        /// The UI trace
        /// </summary>
        public const string UiTrace = "UiTrace";

        /// <summary>
        /// The application trace
        /// </summary>
        public const string ApplicaitonTrace = "ApplicationTrace";

        /// <summary>
        /// The error trace
        /// </summary>
        public const string ErrorTrace = "ErrorTrace";

        /// <summary>
        /// The Debug trace
        /// </summary>
        public const string DebugTrace = "DebugTrace";

        /// <summary>
        /// The application trace filter
        /// </summary>
        public const string ApplicationTraceFilter = "Application Trace Filter";

        /// <summary>
        /// The error trace filter
        /// </summary>
        public const string ErrorTraceFilter = "Error Trace Filter";

        /// <summary>
        /// Gets a value indicating whether log enabled or not
        /// </summary>
        public static bool IsLogEnabled
        {
            get
            {
                var enableLogging = ConfigurationManager.AppSettings["EnableLogging"];

                bool isLogEnabled;
                bool.TryParse(enableLogging, out isLogEnabled);

                return isLogEnabled;
            }
        }

        /// <summary>
        /// Gets a value of LogCategoryFilter
        /// </summary>
        public static string LogCategoryFilter
        {
            get
            {
                var logCategoryFilter = ConfigurationManager.AppSettings["LogCategoryFilter"];

                if (string.IsNullOrWhiteSpace(logCategoryFilter))
                {
                    logCategoryFilter = string.Empty;
                }

                return logCategoryFilter;
            }
        }
    }
}
