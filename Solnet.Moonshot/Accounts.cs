using Solnet.Programs.Utilities;
using Solnet.Wallet;


namespace Solnet.Moonshot.Accounts
{
    public partial class ConfigAccount
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 7356838599052099517UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 189, 255, 97, 70, 186, 189, 24, 102 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "YnDSc4nTeAh";
        public PublicKey MigrationAuthority { get; set; }

        public PublicKey BackendAuthority { get; set; }

        public PublicKey ConfigAuthority { get; set; }

        public PublicKey HelioFee { get; set; }

        public PublicKey DexFee { get; set; }

        public ushort FeeBps { get; set; }

        public byte DexFeeShare { get; set; }

        public ulong MigrationFee { get; set; }

        public ulong MarketcapThreshold { get; set; }

        public Currency MarketcapCurrency { get; set; }

        public byte MinSupportedDecimalPlaces { get; set; }

        public byte MaxSupportedDecimalPlaces { get; set; }

        public ulong MinSupportedTokenSupply { get; set; }

        public ulong MaxSupportedTokenSupply { get; set; }

        public byte Bump { get; set; }

        public uint CoefB { get; set; }

        public static ConfigAccount Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            ConfigAccount result = new ConfigAccount();
            result.MigrationAuthority = _data.GetPubKey(offset);
            offset += 32;
            result.BackendAuthority = _data.GetPubKey(offset);
            offset += 32;
            result.ConfigAuthority = _data.GetPubKey(offset);
            offset += 32;
            result.HelioFee = _data.GetPubKey(offset);
            offset += 32;
            result.DexFee = _data.GetPubKey(offset);
            offset += 32;
            result.FeeBps = _data.GetU16(offset);
            offset += 2;
            result.DexFeeShare = _data.GetU8(offset);
            offset += 1;
            result.MigrationFee = _data.GetU64(offset);
            offset += 8;
            result.MarketcapThreshold = _data.GetU64(offset);
            offset += 8;
            result.MarketcapCurrency = (Currency)_data.GetU8(offset);
            offset += 1;
            result.MinSupportedDecimalPlaces = _data.GetU8(offset);
            offset += 1;
            result.MaxSupportedDecimalPlaces = _data.GetU8(offset);
            offset += 1;
            result.MinSupportedTokenSupply = _data.GetU64(offset);
            offset += 8;
            result.MaxSupportedTokenSupply = _data.GetU64(offset);
            offset += 8;
            result.Bump = _data.GetU8(offset);
            offset += 1;
            result.CoefB = _data.GetU32(offset);
            offset += 4;
            return result;
        }
    }

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
