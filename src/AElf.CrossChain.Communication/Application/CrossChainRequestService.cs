using System;
using System.Linq;
using System.Threading.Tasks;
using Acs7;
using AElf.CrossChain.Communication.Exception;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace AElf.CrossChain.Communication.Application
{
    public class CrossChainRequestService : ICrossChainRequestService, ITransientDependency
    {
        private readonly ICrossChainClientService _crossChainClientService;
        private readonly ICrossChainService _crossChainService;

        public ILogger<CrossChainRequestService> Logger { get; set; }

        public CrossChainRequestService(ICrossChainService crossChainService, 
            ICrossChainClientService crossChainClientService)
        {
            _crossChainService = crossChainService;
            _crossChainClientService = crossChainClientService;
        }

        public async Task RequestCrossChainDataFromOtherChainsAsync()
        {
            var chainIdHeightDict = _crossChainService.GetNeededChainIdAndHeightPairs();
            
            foreach (var chainIdHeightPair in chainIdHeightDict)
            {
                Logger.LogTrace(
                    $"Try to request from chain {ChainHelper.ConvertChainIdToBase58(chainIdHeightPair.Key)}, from height {chainIdHeightPair.Value}");
                try
                {
                    await _crossChainClientService.RequestCrossChainDataAsync(chainIdHeightPair.Key, chainIdHeightPair.Value);
                }
                catch (CrossChainRequestException e)
                {
                    Logger.LogError(
                        $"Request chain {ChainHelper.ConvertChainIdToBase58(chainIdHeightPair.Key)} failed.", e);
                }
            }
        }

        public async Task<ChainInitializationData> RequestChainInitializationDataAsync(int chainId)
        {
            var chainInitializationData = await _crossChainClientService.RequestChainInitializationData(chainId);
            return chainInitializationData;
        }
    }
}