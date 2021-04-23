﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DNTFrameworkCore.Cqrs.Commands;
using DNTFrameworkCore.EFCore.Context;
using DNTFrameworkCore.Functional;
using MediatR;

namespace DNTFrameworkCore.Cqrs.EFCore.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
        where TResponse : Result
    {
        private readonly IDbContext _dbContext;

        public TransactionBehavior(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            //If there is a running transaction, just run the method
            //if (!attribute.HasValue || _dbContext.HasTransaction)
            //            {
            //                return next();
            //            }
            //
            //            _dbContext.BeginTransaction(attribute.IsolationLevel);
            //
            //            try
            //            {
            //                return next();
            //            }
            //            catch (Exception)
            //            {
            //                _dbContext.RollbackTransaction();
            //                throw;
            //            }
            //
            //            var response = default(TResponse);
            //            var typeName = request.GetGenericTypeName();
            //
            //            try
            //            {
            //                if (_dbContext.HasTransaction)
            //                {
            //                    return await next();
            //                }
            //
            //                var strategy = _dbContext.Database.CreateExecutionStrategy();
            //
            //                await strategy.ExecuteAsync(async () =>
            //                {
            //                    Guid transactionId;
            //
            //                    using (var transaction = await _dbContext.BeginTransactionAsync())
            //                    using (LogContext.PushProperty("TransactionContext", transaction.TransactionId))
            //                    {
            //                        _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})",
            //                            transaction.TransactionId, typeName, request);
            //
            //                        response = await next();
            //
            //                        _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}",
            //                            transaction.TransactionId, typeName);
            //
            //                        await _dbContext.CommitTransactionAsync(transaction);
            //
            //                        transactionId = transaction.TransactionId;
            //                    }
            //
            //                    await _orderingIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);
            //                });
            //
            //                return response;
            //            }
            //            catch (Exception ex)
            //            {
            //                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);
            //
            //                throw;
            //            }
            throw new NotImplementedException();
        }
    }
}