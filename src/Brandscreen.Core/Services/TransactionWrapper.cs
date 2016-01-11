using System;
using System.Data.Entity;

namespace Brandscreen.Core.Services
{
    /// <summary>
    /// The transaction wrapper creates new transaction if there is no current transaction, and commits it when disposing.
    /// </summary>
    internal class TransactionWrapper : IDisposable
    {
        private readonly DbContextTransaction _transaction;

        private TransactionWrapper(DbContext dbContext)
        {
            if (dbContext.Database.CurrentTransaction == null) _transaction = dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Commit();
        }

        public static IDisposable Create(DbContext dbContext)
        {
            return new TransactionWrapper(dbContext);
        }
    }
}