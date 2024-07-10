using Solnet.Programs.Utilities;
using Solnet.Rpc.Models;
using Solnet.Wallet;

namespace Solnet.Moonshot
{

    public static class MoonshotProgram
    {
        public static PublicKey programId = new PublicKey("MoonCVVNZFSYkqNXP6bxHLPL6QQJiMagDL3qcqUQTrG");
        public static PublicKey helioFee = new PublicKey("5K5RtTWzzLp4P8Npi84ocf7F1vBsAu29N1irG4iiUnzt");
        public static PublicKey dexFee = new PublicKey("3udvfL24waJcLhskRAsStNMoNUvtyXdxrWQz4hgi953N");
        public static PublicKey configAccount = new PublicKey("36Eru7v11oU5Pfrojyn5oY3nETA1a1iqsw2WUu6afkM9");
        public static PublicKey systemProgram = new PublicKey("11111111111111111111111111111111");
        public static PublicKey tokenProgram = new PublicKey("TokenkegQfeZyiNwAJbNbGKPFXCWuBvf9Ss623VQ5DA");
        public static PublicKey associatedtokenProgram = new PublicKey("ATokenGPvbdGVxr1b2hvZbsiqW5xWH25efTNsLJA8knL");
        

        public static TransactionInstruction Buy(BuyAccounts accounts, TradeOrder data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Sender, true),  AccountMeta.Writable(accounts.SenderTokenAccount, false), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.Writable(dexFee, false), AccountMeta.Writable(helioFee, false), AccountMeta.ReadOnly(accounts.Mint, false), AccountMeta.ReadOnly(configAccount, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(16927863322537952870UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Sell(SellAccounts accounts, TradeOrder data)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Sender, true), AccountMeta.Writable(accounts.SenderTokenAccount, false), AccountMeta.Writable(accounts.CurveAccount, false), AccountMeta.Writable(accounts.CurveTokenAccount, false), AccountMeta.Writable(dexFee, false), AccountMeta.Writable(helioFee, false), AccountMeta.ReadOnly(accounts.Mint, false), AccountMeta.ReadOnly(configAccount, false), AccountMeta.ReadOnly(tokenProgram, false), AccountMeta.ReadOnly(associatedtokenProgram, false), AccountMeta.ReadOnly(systemProgram, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(12502976635542562355UL, offset);
            offset += 8;
            offset += data.Serialize(_data, offset);
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

       
    }
}
