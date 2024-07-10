using Solnet.Programs.Utilities;
using Solnet.Wallet;


namespace Solnet.Moonshot.Accounts
{
    public partial class CurveAccount
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 1655310924981164808UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 8, 91, 83, 28, 132, 216, 248, 22 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "2Q57E7FPa1b";
        public ulong TotalSupply { get; set; }

        public ulong CurveAmount { get; set; }

        public PublicKey Mint { get; set; }

        public byte Decimals { get; set; }

        public Currency CollateralCurrency { get; set; }

        public CurveType CurveType { get; set; }

        public ulong MarketcapThreshold { get; set; }

        public Currency MarketcapCurrency { get; set; }

        public ulong MigrationFee { get; set; }

        public uint CoefB { get; set; }

        public byte Bump { get; set; }

        public static CurveAccount Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            CurveAccount result = new CurveAccount();
            result.TotalSupply = _data.GetU64(offset);
            offset += 8;
            result.CurveAmount = _data.GetU64(offset);
            offset += 8;
            result.Mint = _data.GetPubKey(offset);
            offset += 32;
            result.Decimals = _data.GetU8(offset);
            offset += 1;
            result.CollateralCurrency = (Currency)_data.GetU8(offset);
            offset += 1;
            result.CurveType = (CurveType)_data.GetU8(offset);
            offset += 1;
            result.MarketcapThreshold = _data.GetU64(offset);
            offset += 8;
            result.MarketcapCurrency = (Currency)_data.GetU8(offset);
            offset += 1;
            result.MigrationFee = _data.GetU64(offset);
            offset += 8;
            result.CoefB = _data.GetU32(offset);
            offset += 4;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            return result;
        }
    }
}
