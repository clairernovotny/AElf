﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Blockchain.Events;
using AElf.Kernel.SmartContract.Application;
using AElf.Kernel.SmartContract.Infrastructure;
using AElf.Types;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace AElf.Kernel.SmartContract.Parallel
{
    public class ResourceExtractionService : IResourceExtractionService, ISingletonDependency
    {
        private readonly IBlockchainService _blockchainService;
        private readonly ISmartContractExecutiveService _smartContractExecutiveService;
        public ILogger<TransactionGrouper> Logger { get; set; }

        private readonly ConcurrentDictionary<Hash, TransactionResourceInfo> _resourceCache = 
            new ConcurrentDictionary<Hash, TransactionResourceInfo>();

        public ResourceExtractionService(IBlockchainService blockchainService, 
            ISmartContractExecutiveService smartContractExecutiveService)
        {
            _smartContractExecutiveService = smartContractExecutiveService;
            _blockchainService = blockchainService;
        }

        public async Task<IEnumerable<(Transaction, TransactionResourceInfo)>> GetResourcesAsync(IChainContext chainContext,
            IEnumerable<Transaction> transactions, CancellationToken ct)
        {
            // Parallel processing below (adding AsParallel) causes ReflectionTypeLoadException
            var tasks = transactions.Select(t => GetResourcesForOneWithCacheAsync(chainContext, t, ct));
            return await Task.WhenAll(tasks);
        }

        private async Task<(Transaction, TransactionResourceInfo)> GetResourcesForOneWithCacheAsync(IChainContext chainContext,
            Transaction transaction, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                return (transaction, new TransactionResourceInfo()
                {
                    TransactionId = transaction.GetHash(),
                    NonParallelizable = true
                });

            if (_resourceCache.TryGetValue(transaction.GetHash(), out var resourceInfo))
                return (transaction, resourceInfo);

            return (transaction, await GetResourcesForOneAsync(chainContext, transaction, ct));
        }
        
        private async Task<TransactionResourceInfo> GetResourcesForOneAsync(IChainContext chainContext,
            Transaction transaction, CancellationToken ct)
        {
            IExecutive executive = null;
            var address = transaction.To;
            
            try
            {
                executive = await _smartContractExecutiveService.GetExecutiveAsync(chainContext, address);
                var resourceInfo = await executive.GetTransactionResourceInfoAsync(chainContext, transaction);
                
                _resourceCache.TryAdd(transaction.GetHash(), resourceInfo);
                
                return resourceInfo;
            }
            finally
            {
                if (executive != null)
                {
                    await _smartContractExecutiveService.PutExecutiveAsync(address, executive);
                }
            }
        }

        #region Event Handler Methods
        
        public async Task HandleTxResourcesNeededAsync(TxResourcesNeededEvent eventData)
        {
            var chainContext = await GetChainContextAsync();

            var tasks = eventData.Transactions.Select(
                tx => GetResourcesForOneAsync(chainContext, tx, CancellationToken.None));
            
            await Task.WhenAll(tasks);
            
            Logger.LogTrace($"Resource cache size: {_resourceCache.Count}");
        }

        public async Task HandleTxResourcesNoLongerNeededAsync(TxResourcesNoLongerNeededEvent eventData)
        {
            foreach (var txId in eventData.TxIds)
            {
                _resourceCache.TryRemove(txId, out _);
            }
        }
        #endregion
        
        private async Task<ChainContext> GetChainContextAsync()
        {
            var chain = await _blockchainService.GetChainAsync();
            if (chain == null)
            {
                return null;
            }

            var chainContext = new ChainContext()
            {
                BlockHash = chain.BestChainHash,
                BlockHeight = chain.BestChainHeight
            };
            return chainContext;
        }
    }
}