using Solnet.Moonshot.Accounts;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Programs.Models;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Rpc.Models;
using Solnet.Moonshot.Utils;

namespace Solnet.Moonshot
{
    public partial class MoonshotClient 
    {
        public PublicKey programId = new PublicKey("MoonCVVNZFSYkqNXP6bxHLPL6QQJiMagDL3qcqUQTrG");
        public IRpcClient RpcClient { get; set; }
        public MoonshotClient(IRpcClient _rpcClient) 
        {
            RpcClient = _rpcClient;
        }

        public async Task<AccountResultWrapper<CurveAccount>> GetCurveAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<CurveAccount>(res);
            var resultingAccount = CurveAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<CurveAccount>(res, resultingAccount);
        }

        public async Task<string> SendBuyAsync(Account senderAccount, PublicKey tokenAddress, TradeOrder order,  ulong priorityfee = 0)
        {
            PublicKey curveAccount = PDALookup.FindCurvePDA(tokenAddress);
            BuyAccounts accounts = new BuyAccounts
            {
                CurveAccount = PDALookup.FindCurvePDA(tokenAddress),
                CurveTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(curveAccount, tokenAddress),
                Sender = senderAccount.PublicKey,
                SenderTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(senderAccount.PublicKey, tokenAddress)
            };
            TransactionInstruction instr = MoonshotProgram.Buy(accounts, order);
            TransactionBuilder tb = new TransactionBuilder();
            if(priorityfee != 0)
            {
                TransactionInstruction priorityFee = ComputeBudgetProgram.SetComputeUnitPrice(priorityfee);
                tb.AddInstruction(priorityFee);
            }
            
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(senderAccount);
            var signedtx = tb.Build(new Account[] {senderAccount});
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendSellAsync(Account senderAccount, PublicKey tokenAddress, TradeOrder order, ulong priorityfee = 0)
        {
            PublicKey curveAccount = PDALookup.FindCurvePDA(tokenAddress);
            SellAccounts accounts = new SellAccounts
            {
                CurveAccount = PDALookup.FindCurvePDA(tokenAddress),
                CurveTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(curveAccount, tokenAddress),
                Sender = senderAccount.PublicKey,
                SenderTokenAccount = AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(senderAccount.PublicKey, tokenAddress)
            };
            TransactionInstruction instr = MoonshotProgram.Sell(accounts, order);
            TransactionBuilder tb = new TransactionBuilder();
            if (priorityfee != 0)
            {
                TransactionInstruction priorityFee = ComputeBudgetProgram.SetComputeUnitPrice(priorityfee);
                tb.AddInstruction(priorityFee);
            }
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(senderAccount);
            var signedtx = tb.Build(new Account[] { senderAccount });
            return Convert.ToBase64String(signedtx);
        }

    }
}
