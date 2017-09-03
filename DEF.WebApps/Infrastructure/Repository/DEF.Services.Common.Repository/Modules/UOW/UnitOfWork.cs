// -----------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains the methods/properties of Equus unit of work.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/26/2017, 06:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Modules.UOW
{
    #region Imports
    using System.Diagnostics;
    using DEF.Services.Common.Repository.Interfaces.UOW;
    using DEF.Services.Data;

    #endregion

    /// <summary>
    /// EQUUS Unit of Work class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables
        /// <summary>
        /// EQUUS entities
        /// </summary>
        private EquusEntities equusEntities;

        /// <summary>
        /// Is context behavior is read/write
        /// </summary>
        private bool isReadOnly;
        #endregion

        #region Initializers
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="context">EQUUS Context</param>
        public UnitOfWork(EquusEntities context)
        {
            this.equusEntities = context;
        }
        #endregion

        #region IEquusUnitOfWork Members
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public long UserName { get; set; }

        /// <summary>
        /// Gets the EQUUS Context
        /// </summary>
        public EquusEntities Context
        {
            get { return this.equusEntities; }
        }

        /// <summary>
        /// Gets the get parallel context.
        /// </summary>
        /// <value>
        /// The get parallel context.
        /// </value>
        public EquusEntities GetParallelContext
        {
            get
            {
                var parallelContext = new EquusEntities();
                parallelContext.Configuration.AutoDetectChangesEnabled = false;
                return parallelContext;
            }
        }

        /// <summary>
        /// Save Changes on context
        /// </summary>
        /// <returns>Save Result</returns>
        public int Save()
        {
            if (!this.isReadOnly)
            {
                // Set audit properties
                StackFrame currentFrame = new StackFrame(1, true);
                //// user name  should  be  set by session
                this.equusEntities.UserName = this.UserName;

                // Save changes
                return this.equusEntities.SaveChanges();
            }

            return 0;
        }

        /// <summary>
        /// Set context behavior read/write
        /// </summary>
        /// <param name="readOnly">True if read only, otherwise false</param>
        public void SetContextBehaviour(bool readOnly)
        {
            this.isReadOnly = readOnly;
            this.equusEntities.Configuration.AutoDetectChangesEnabled = !readOnly;
        }
        #endregion
    }
}
