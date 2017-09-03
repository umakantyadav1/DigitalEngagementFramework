// -----------------------------------------------------------------------
// <copyright file="LogManager.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
namespace DEF.Services.Logging
{
    #region "Imports"
    using Aqha.US.Equus.Logging;
    using System;
    #endregion

    /// <summary>
    /// Log Manager Class
    /// </summary>
    public static class LogManager
    {
        #region Variables
        /// <summary>
        /// Logger object
        /// </summary>
        private static ILogger logger;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the service log.
        /// </summary>
        /// <value>
        /// The service log.
        /// </value>
        public static ILogger ServiceLog
        {
            get
            {
                logger.InitializeSettings(LogConstants.ApplicaitonTrace);
                return logger;
            }
        }

        /// <summary>
        /// Gets the error log.
        /// </summary>
        /// <value>
        /// The error log.
        /// </value>
        public static ILogger ErrorLog
        {
            get
            {
                logger.InitializeSettings(LogConstants.ErrorTrace);
                return logger;
            }
        }

        /// <summary>
        /// Gets the debug log.
        /// </summary>
        /// <value>
        /// The debug log.
        /// </value>
        public static ILogger DebugLog
        {
            get
            {
                logger.InitializeSettings(LogConstants.DebugTrace);
                return logger;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Resolve logger
        /// </summary>
        /// <param name="loggerInjector">Logger injector</param>
        public static void ResolveLogger(ILogger loggerInjector)
        {
            logger = loggerInjector;
        }
        #endregion
    }
}
