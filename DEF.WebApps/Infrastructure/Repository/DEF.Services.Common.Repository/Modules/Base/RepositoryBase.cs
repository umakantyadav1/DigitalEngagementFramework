// -----------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains methods implemention of RepositoryBase inteface .
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/28/2017, 01:00 PM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Modules.Base
{
    #region Imports
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    using DEF.Services.Data;
    using System.Data.Entity;
    #endregion

    /// <summary>
    /// Base class for Repository layer
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public class RepositoryBase<T> where T : class
    {
        #region Properties
        /// <summary>
        /// The context
        /// </summary>
        protected EquusEntities context;

        /// <summary>
        /// DB set
        /// </summary>
        private IDbSet<T> dbSet;
        #endregion

        #region IBaseRepository Members
        /// <summary>
        /// Set context for the repository
        /// </summary>
        /// <param name="context">The context</param>
        public void SetContext(EquusEntities context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        /// <summary>
        /// Get next sequence id of the table
        /// </summary>
        /// <typeparam name="E">Table Name</typeparam>
        /// <returns>Next sequence Id for a table</returns>
        public decimal GetSequenceId<E>()
        {
            decimal id = 0;

            if (this.context.Database != null)
            {
                var query = "SELECT NEXT VALUE FOR [SEQUENCE_" + typeof(E).Name + "_ID]";
                id = this.context.Database.SqlQuery<long>(query).First();
            }

            return id;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>Query to get all entities</returns>
        public virtual IQueryable<T> GetAll()
        {
            return this.dbSet.AsQueryable<T>();
        }

        /// <summary>
        /// Get entities by using predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <returns>Query to get entities</returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate).AsQueryable<T>();
        }

        /// <summary>
        /// Add entity to context
        /// </summary>
        /// <param name="entity">The entity</param>
        public virtual void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        /// <summary>
        /// Remove entity to context
        /// </summary>
        /// <param name="entity">The entity</param>
        public virtual void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        /////// <summary>
        /////// Removes the specified entity.
        /////// </summary>
        /////// <typeparam name="R">Type of entity</typeparam>
        /////// <param name="entity">The entity.</param>
        ////public virtual void Remove<R>(R entity)
        ////{
        ////    this.context.Entry(entity).State = EntityState.Deleted;
        ////}

        /// <summary>
        /// Update entity state in context
        /// </summary>
        /// <param name="entity">The entity</param>
        public virtual void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
}
