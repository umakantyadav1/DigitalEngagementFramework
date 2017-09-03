// -----------------------------------------------------------------------
// <copyright file="EnterpriseLogger.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reseved.
// </copyright>
// -----------------------------------------------------------------------
namespace Aqha.US.Equus.Logging
{
    #region "Imports"
    using System.Diagnostics;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
    using DEF.Services.Logging;
    #endregion

    /// <summary>
    /// Logger Class
    /// </summary>
    public class EnterpriseLogger : ILogger
    {
        #region Private Variables

        /// <summary>
        /// The log factory
        /// </summary>
        private LogWriterFactory logFactory;

        /// <summary>
        /// The writer
        /// </summary>
        private LogWriter writer;

        /// <summary>
        /// The manager
        /// </summary>
        private TraceManager manager;

        #endregion

        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLogger"/> class.
        /// </summary>
        public EnterpriseLogger()
        {
            this.logFactory = new LogWriterFactory();
            this.writer = this.logFactory.Create();
            this.manager = new TraceManager(this.writer);
            this.CatFilter = this.writer.GetFilter<CategoryFilter>(LogConstants.LogCategoryFilter);
            this.CatFilter.CategoryFilterMode = LogConstants.IsLogEnabled == true ? CategoryFilterMode.DenyAllExceptAllowed : CategoryFilterMode.AllowAllExceptDenied;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        private string Category { get; set; }

        /// <summary>
        /// Gets or sets the cat filter.
        /// </summary>
        /// <value>
        /// The cat filter.
        /// </value>
        private CategoryFilter CatFilter { get; set; }
        #endregion

        #region ILogger Methods

        /// <summary>
        /// Initialize log specific settings
        /// </summary>
        /// <param name="logType">Log Type</param>
        public void InitializeSettings(string logType)
        {
            this.Category = logType;
        }

        /// <summary>
        /// Critical the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        public void Critical(string logMessage, params object[] args)
        {
            this.LogMessage(TraceEventType.Critical, logMessage, args);
        }

        /// <summary>
        /// Errors the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        public void Error(string logMessage, params object[] args)
        {
            this.LogMessage(TraceEventType.Error, logMessage, args);
        }

        /// <summary>
        /// Warnings the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        public void Warning(string logMessage, params object[] args)
        {
            this.LogMessage(TraceEventType.Warning, logMessage, args);
        }

        /// <summary>
        /// Information the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        public void Information(string logMessage, params object[] args)
        {
            this.LogMessage(TraceEventType.Information, logMessage, args);
        }

        /// <summary>
        /// Verbose the specified log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        public void Verbose(string logMessage, params object[] args)
        {
            this.LogMessage(TraceEventType.Verbose, logMessage, args);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="logMessage">The log message.</param>
        /// <param name="args">The arguments.</param>
        private void LogMessage(TraceEventType severity, string logMessage, params object[] args)
        {
            if (this.CatFilter == null || this.CatFilter.ShouldLog(this.Category))
            {
                if (this.writer.IsLoggingEnabled())
                {
                    StackFrame currentFrame = new StackFrame(2, true);
                    var methodName = currentFrame.GetMethod().DeclaringType + "." + currentFrame.GetMethod().Name;
                    LogEntry logEntry = new LogEntry();
                    logEntry.Severity = severity;
                    logEntry.Title = "DEF WEB Application";
                    logEntry.Categories.Add(this.Category);
                    logEntry.ExtendedProperties.Add("Line Number", string.Format("L {0} C {1}", currentFrame.GetFileLineNumber(), currentFrame.GetFileColumnNumber()));
                    logEntry.ExtendedProperties.Add("Method Name", methodName);
                    logEntry.Message = string.Format(logMessage, args);
                    this.writer.Write(logEntry);
                }
            }
        }
        #endregion
    }
}
