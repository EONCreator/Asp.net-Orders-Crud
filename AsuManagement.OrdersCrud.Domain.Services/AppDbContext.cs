using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;

namespace AsuManagement.OrdersCrud.Domain.Services
{
    public class AppDbContext : DbContext, IEntityRepository
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TEntity> Entity<TEntity>() where TEntity : class => Set<TEntity>();

        public IEntityRepositoryUnitOfWork CreateUnitOfWork()
        {
            if (Database.CurrentTransaction != null)
                return new UnitOfWorkStub();

            return new UnitOfWork(this, Database.BeginTransaction());
        }

        public Task SaveChanges()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        private class UnitOfWorkStub : IEntityRepositoryUnitOfWork
        {
            public ValueTask DisposeAsync()
            {
                return ValueTask.CompletedTask;
            }

            public Task Commit()
            {
                return Task.CompletedTask;
            }

            public Task Rollback()
            {
                return Task.CompletedTask;
            }
        }

        private class UnitOfWork : IEntityRepositoryUnitOfWork
        {
            private const string SavepointName = "savepoint";

            private readonly AppDbContext _dbContext;
            private readonly IDbContextTransaction _transaction;

            public UnitOfWork(AppDbContext dbContext, IDbContextTransaction transaction)
            {
                _dbContext = dbContext;
                _transaction = transaction;
            }

            public ValueTask DisposeAsync()
            {
                return _transaction.DisposeAsync();
            }

            public async Task Commit()
            {
                await SaveInternal();
                await _transaction.CommitAsync();
            }

            public Task Rollback()
            {
                return _transaction.RollbackAsync();
            }

            private async Task SetTransactionSavepoint()
            {
                var txn = (NpgsqlTransaction)_transaction.GetDbTransaction();
                await txn.SaveAsync(SavepointName);
            }

            private async Task RollbackToSavepoint()
            {
                var txn = (NpgsqlTransaction)_transaction.GetDbTransaction();
                await txn.RollbackAsync(SavepointName);
            }

            private async Task SaveInternal()
            {
                await SetTransactionSavepoint();
                try
                {
                    // if some of the next methods throws, just skip saving changes
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    await RollbackToSavepoint();
                    throw;
                }
            }
        }
    }
}
