﻿using Acs2;
using AElf.Sdk.CSharp;
using AElf.Types;

namespace AElf.Contracts.MultiToken
{
    public partial class TokenContract
    {
        public override ResourceInfo GetResourceInfo(Transaction txn)
        {
            switch (txn.MethodName)
            {
                case nameof(Transfer):
                {
                    var args = TransferInput.Parser.ParseFrom(txn.Params);
                    return new ResourceInfo
                    {
                        Paths =
                        {
                            GetPath(nameof(TokenContractState.Balances), txn.From.ToString(), args.Symbol),
                            GetPath(nameof(TokenContractState.Balances), args.To.ToString(), args.Symbol),
                            GetPath(nameof(TokenContractState.ChargedFees),txn.From.ToString())
                        }
                    };
                }

                case nameof(TransferFrom):
                {
                    var args = TransferFromInput.Parser.ParseFrom(txn.Params);
                    return new ResourceInfo
                    {
                        Paths =
                        {
                            GetPath(nameof(TokenContractState.Allowances), args.From.ToString(), txn.From.ToString(),
                                args.Symbol),
                            GetPath(nameof(TokenContractState.Balances), args.From.ToString(), args.Symbol),
                            GetPath(nameof(TokenContractState.Balances), args.To.ToString(), args.Symbol),
                            GetPath(nameof(TokenContractState.Balances), txn.From.ToString(), args.Symbol),
                            GetPath(nameof(TokenContractState.LockWhiteLists), args.Symbol, txn.From.ToString()),
                            GetPath(nameof(TokenContractState.ChargedFees), txn.From.ToString())
                        }
                    };
                }

                // TODO: Support more methods
                default:
                    return new ResourceInfo();
            }
        }

        private ScopedStatePath GetPath(params string[] parts)
        {
            return new ScopedStatePath
            {
                Address = Context.Self,
                Path = new StatePath
                {
                    Parts =
                    {
                        parts
                    }
                }
            };
        }
    }
}