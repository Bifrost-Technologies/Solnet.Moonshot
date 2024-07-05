using Solnet.Moonshot.Accounts;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Programs.Models;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Rpc.Models;

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

        public async Task<ProgramAccountsResultWrapper<List<ConfigAccount>>> GetConfigAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = ConfigAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<ConfigAccount>>(res);
            List<ConfigAccount> resultingAccounts = new List<ConfigAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ConfigAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<ConfigAccount>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<CurveAccount>>> GetCurveAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = CurveAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<CurveAccount>>(res);
            List<CurveAccount> resultingAccounts = new List<CurveAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => CurveAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<CurveAccount>>(res, resultingAccounts);
        }

        public async Task<AccountResultWrapper<ConfigAccount>> GetConfigAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<ConfigAccount>(res);
            var resultingAccount = ConfigAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<ConfigAccount>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<CurveAccount>> GetCurveAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<CurveAccount>(res);
            var resultingAccount = CurveAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<CurveAccount>(res, resultingAccount);
        }

       

        public async Task<string> SendTokenMintAsync(TokenMintAccounts accounts, TokenMintParams mintParams, PublicKey feePayer,  Account botWalletAccount)
        {
            TransactionInstruction instr = MoonshotProgram.TokenMint(accounts, mintParams);
            TransactionBuilder tb = new TransactionBuilder();
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] { botWalletAccount });
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendBuyAsync(BuyAccounts accounts, TradeParams data, PublicKey feePayer, Account WalletAccount, ulong priorityfee = 0)
        {
            TransactionInstruction instr = MoonshotProgram.Buy(accounts, data);
            TransactionBuilder tb = new TransactionBuilder();
            if(priorityfee != 0)
            {
                TransactionInstruction priorityFee = ComputeBudgetProgram.SetComputeUnitPrice(priorityfee);
                tb.AddInstruction(priorityFee);
            }
            
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] {WalletAccount});
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendSellAsync(SellAccounts accounts, TradeParams data, PublicKey feePayer,  Account WalletAccount, ulong priorityfee = 0)
        {
            TransactionInstruction instr = MoonshotProgram.Sell(accounts, data);
            TransactionBuilder tb = new TransactionBuilder();
            if (priorityfee != 0)
            {
                TransactionInstruction priorityFee = ComputeBudgetProgram.SetComputeUnitPrice(priorityfee);
                tb.AddInstruction(priorityFee);
            }
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] { WalletAccount });
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendMigrateFundsAsync(MigrateFundsAccounts accounts, PublicKey feePayer,  Account WalletAccount)
        {
            TransactionInstruction instr = MoonshotProgram.MigrateFunds(accounts);
            TransactionBuilder tb = new TransactionBuilder();
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] { WalletAccount });
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendConfigInitAsync(ConfigInitAccounts accounts, ConfigParams data, PublicKey feePayer,  Account botWalletAccount)
        {
            TransactionInstruction instr = MoonshotProgram.ConfigInit(accounts, data);
            TransactionBuilder tb = new TransactionBuilder();
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] { botWalletAccount });
            return Convert.ToBase64String(signedtx);
        }

        public async Task<string> SendConfigUpdateAsync(ConfigUpdateAccounts accounts, ConfigParams data, PublicKey feePayer,  Account botWalletAccount)
        {
            TransactionInstruction instr = MoonshotProgram.ConfigUpdate(accounts, data);
            TransactionBuilder tb = new TransactionBuilder();
            tb.AddInstruction(instr);
            tb.SetRecentBlockHash((await RpcClient.GetLatestBlockHashAsync()).Result.Value.Blockhash);
            tb.SetFeePayer(feePayer);
            var signedtx = tb.Build(new Account[] { botWalletAccount });
            return Convert.ToBase64String(signedtx);
        }
    }
}
