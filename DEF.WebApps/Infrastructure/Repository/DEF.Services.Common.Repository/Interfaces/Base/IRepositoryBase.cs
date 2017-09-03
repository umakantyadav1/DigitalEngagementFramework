// -----------------------------------------------------------------------------
// <copyright file="IRepositoryBase.cs" company="NTT DATA">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------
// File Description:
// =================  
// This interface file contains base methods for repository layer.
// ------------------------------------------------------------------------------
// Author: NTT DATA
// Date Created: 08/27/2017, 11:00 AM IST
// ------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace DEF.Services.Common.Repository.Interfaces.Base
{
    #region Imports
    using DEF.Services.Utilities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    #endregion

    /// <summary>
    /// Base interface for repository
    /// </summary>
    /// <typeparam name="T1">Type of context</typeparam>
    /// <typeparam name="T2">Type of entity</typeparam>
    public interface IRepositoryBase<T1, T2> : IContextBase<T1>
    {
        /// <summary>
        /// Get next sequence id of the table
        /// </summary>
        /// <typeparam name="E">Table Name</typeparam>
        /// <returns>Next sequence Id for a table</returns>
        decimal GetSequenceId<E>();

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>Query to get all entities</returns>
        IQueryable<T2> GetAll();

        /// <summary>
        /// Get entities by using predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <returns>Query to get entities</returns>
        IQueryable<T2> FindBy(Expression<Func<T2, bool>> predicate);

        /// <summary>
        /// Add entity to context
        /// </summary>
        /// <param name="entity">The entity</param>
        void Add(T2 entity);

        /// <summary>
        /// Remove entity to context
        /// </summary>
        /// <param name="entity">The entity</param>
        void Remove(T2 entity);

        /////// <summary>
        /////// Remove entity to context
        /////// </summary>
        /////// <typeparam name="R">Type of entity</typeparam>
        /////// <param name="entity">The entity</param>
        ////void Remove<R>(R entity);

        /// <summary>
        /// Update entity state in context
        /// </summary>
        /// <param name="entity">The entity</param>
        void Update(T2 entity);
    }
}
