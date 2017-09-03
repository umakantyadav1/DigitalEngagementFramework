// -----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
namespace Aqha.US.Equus.Logging
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Critical the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        void Critical(string logMessage, params object[] args);

        /// <summary>
        /// Errors the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        void Error(string logMessage, params object[] args);

        /// <summary>
        /// Warnings the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        void Warning(string logMessage, params object[] args);

        /// <summary>
        /// Information the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        void Information(string logMessage, params object[] args);

        /// <summary>
        /// Verbose the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        void Verbose(string logMessage, params object[] args);

        /// <summary>
        /// Initialize log specific settings
        /// </summary>
        /// <param name="logType">Log Type</param>
        void InitializeSettings(string logType);
    }
}
