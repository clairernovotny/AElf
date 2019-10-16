using Acs1;
using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.ReferendumAuth
{
    public partial class ReferendumAuthContract
    {
        public override TokenAmounts GetMethodFee(MethodName input)
        {
            return State.TransactionFees[input.Name];
        }

        public override Empty SetMethodFee(TokenAmounts input)
        {
            if (State.ParliamentAuthContract.Value == null)
            {
                State.ParliamentAuthContract.Value =
                    Context.GetContractAddressByName(SmartContractConstants.ParliamentAuthContractSystemName);
            }

            Assert(Context.Sender == State.ParliamentAuthContract.GetGenesisOwnerAddress.Call(new Empty()));
            State.TransactionFees[input.Method] = input;

            return new Empty();
        }
    }
}