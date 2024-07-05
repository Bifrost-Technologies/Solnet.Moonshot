using Solnet.Programs.Utilities;
using Solnet.Rpc.Models;
using Solnet.Wallet;

namespace Solnet.Moonshot
{

    public static class MoonshotProgram
    {
        public static PublicKey programId = new PublicKey("MoonCVVNZFSYkqNXP6bxHLPL6QQJiMagDL3qcqUQTrG");
        public static TransactionInstruction TokenMint(TokenMintAccounts accounts, TokenMintParams mintParams)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Sender, true), AccountMeta.ReadOnly(accounts.BackendAuthority, true), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.Mint, true), AccountMeta.Writable(accounts.MintMetadata, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.ReadOnly(accounts.ConfigAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.MplTokenMetadata, false), AccountMeta.ReadOnly(accounts.SystemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(12967285527113116675UL, offset);
            offset += 8;
            offset += mintParams.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Buy(BuyAccounts accounts, TradeParams data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Sender, true),  AccountMeta.Writable(accounts.SenderTokenAccount, false), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.Writable(accounts.DexFee, false), AccountMeta.Writable(accounts.HelioFee, false), AccountMeta.ReadOnly(accounts.Mint, false), AccountMeta.ReadOnly(accounts.ConfigAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(16927863322537952870UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Sell(SellAccounts accounts, TradeParams data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Sender, true), AccountMeta.Writable(accounts.SenderTokenAccount, false), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.Writable(accounts.DexFee, false), AccountMeta.Writable(accounts.HelioFee, false), AccountMeta.ReadOnly(accounts.Mint, false), AccountMeta.ReadOnly(accounts.ConfigAccount, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(12502976635542562355UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction MigrateFunds(MigrateFundsAccounts accounts)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.BackendAuthority, true), AccountMeta.Writable(accounts.MigrationAuthority, true), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.Writable(accounts.MigrationAuthorityTokenAccount, false), AccountMeta.Writable(accounts.Mint, false), AccountMeta.ReadOnly(accounts.ConfigAccount, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.AssociatedTokenProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(12592415018450609450UL, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction ConfigInit(ConfigInitAccounts accounts, ConfigParams data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.ConfigAuthority, true), AccountMeta.Writable(accounts.ConfigAccount, false), AccountMeta.ReadOnly(accounts.SystemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(13377095427818843149UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction ConfigUpdate(ConfigUpdateAccounts accounts, ConfigParams data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.ConfigAuthority, true), AccountMeta.Writable(accounts.ConfigAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(17391080224613803344UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }
    }
}
