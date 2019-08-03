using System.Collections.Generic;
using System.Threading.Tasks;
using Acs7;
using AElf.CrossChain.Communication.Application;
using AElf.CrossChain.Communication.Grpc;
using AElf.CrossChain.Communication.Infrastructure;
using AElf.Kernel;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.SmartContract;
using AElf.Modularity;
using AElf.Types;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Volo.Abp.Modularity;

namespace AElf.CrossChain.Communication
{
    [DependsOn(typeof(CrossChainCommunicationModule),
        typeof(SmartContractAElfModule),
        typeof(KernelCoreTestAElfModule),
        typeof(GrpcCrossChainAElfModule))]
    public class CrossChainCommunicationTestModule : AElfModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            var dictionary = new Dictionary<long, Hash>
            {
                {1, Hash.FromString("1")},
                {2, Hash.FromString("2")},
                {3, Hash.FromString("3")}
            };

            Configure<GrpcCrossChainConfigOption>(option =>
            {
                option.ListeningHost = "127.0.0.1";
                option.LocalServerPort = 5001;
                option.LocalServerHost = "127.0.0.1";
                option.RemoteParentChainServerHost = "127.0.0.1";
                option.RemoteParentChainServerPort = 5000;
            });

            context.Services.AddTransient(provider =>
            {
                var kernelTestHelper = context.Services.GetRequiredServiceLazy<KernelTestHelper>();
                var mockBlockChainService = new Mock<IBlockchainService>();
                mockBlockChainService.Setup(m => m.GetChainAsync()).Returns(() =>
                {
                    var chain = new Chain {LastIrreversibleBlockHeight = 10};
                    return Task.FromResult(chain);
                });
                mockBlockChainService.Setup(m =>
                        m.GetBlockHashByHeightAsync(It.IsAny<Chain>(), It.IsAny<long>(), It.IsAny<Hash>()))
                    .Returns<Chain, long, Hash>((chain, height, hash) =>
                    {
                        if (height > 0 && height <= 3)
                            return Task.FromResult(dictionary[height]);
                        return Task.FromResult<Hash>(null);
                    });
                mockBlockChainService.Setup(m => m.GetBlockByHashAsync(It.IsAny<Hash>())).Returns<Hash>(hash =>
                {
                    foreach (var kv in dictionary)
                    {
                        if (kv.Value.Equals(hash))
                        {
                            var block = kernelTestHelper.Value.GenerateBlock(kv.Key - 1, dictionary[kv.Key - 1]);
                            return Task.FromResult(block);
                        }
                    }
                    return Task.FromResult<Block>(null);
                });
                return mockBlockChainService.Object;
            });

            context.Services.AddTransient(provider =>
            {
                var mockBlockExtraDataService = new Mock<IBlockExtraDataService>();
                mockBlockExtraDataService
                    .Setup(m => m.GetExtraDataFromBlockHeader(It.IsAny<string>(), It.IsAny<BlockHeader>())).Returns(
                        () =>
                        {
                            var crossExtraData = new CrossChainExtraData
                            {
                                SideChainBlockHeadersRoot = Hash.FromString("SideChainBlockHeadersRoot"),
                                SideChainTransactionsRoot = Hash.FromString("SideChainTransactionsRoot")
                            };
                            return ByteString.CopyFrom(crossExtraData.ToByteArray());
                        });
                return mockBlockExtraDataService.Object;
            });

            context.Services.AddTransient(provider =>
            {
                var mockCrossChainIndexingDataService = new Mock<ICrossChainIndexingDataService>();
                mockCrossChainIndexingDataService
                    .Setup(m => m.GetIndexedCrossChainBlockDataAsync(It.IsAny<Hash>(), It.IsAny<long>()))
                    .Returns(() =>
                    {
                        var crossChainBlockData = new CrossChainBlockData
                        {
                            SideChainBlockData = {new SideChainBlockData{ChainId = 123, Height = 1,TransactionMerkleTreeRoot = Hash.FromString("fakeTransactionMerkleTree")}}
                        };
                        return Task.FromResult(crossChainBlockData);
                    });
                return mockCrossChainIndexingDataService.Object;
            });
            
            context.Services.AddTransient(provider =>
            {
                var mockCrossChainClientService = new Mock<ICrossChainClientService>();
                mockCrossChainClientService.Setup(m => m.GetClientAsync(It.IsAny<int>())).Returns(() =>
                {
                    var crossChainClientProvider =
                        context.Services.GetRequiredServiceLazy<ICrossChainClientProvider>().Value;
                    var crossChainClientDto = new CrossChainClientDto
                    {
                        IsClientToParentChain = true,
                        RemoteServerHost = "127.0.0.1",
                        RemoteServerPort = 5000
                    };
                    var client = crossChainClientProvider.CreateCrossChainClient(crossChainClientDto);
                    return Task.FromResult(client);
                });
                mockCrossChainClientService.Setup(m => m.CreateClientForChainInitializationData(It.IsAny<int>()))
                    .Returns(() =>
                    {
                        var mockClient = new Mock<ICrossChainClient>();
                        mockClient.Setup(m => m.RequestChainInitializationDataAsync(It.IsAny<int>())).Returns(() =>
                        {
                            var chainInitialization = new ChainInitializationData
                            {
                                CreationHeightOnParentChain = 1
                            };
                            return Task.FromResult(chainInitialization);
                        });
                        return mockClient.Object;
                    });
                return mockCrossChainClientService.Object;
            });

            context.Services.AddSingleton<CrossChainPlugin>();
        }
    }
}